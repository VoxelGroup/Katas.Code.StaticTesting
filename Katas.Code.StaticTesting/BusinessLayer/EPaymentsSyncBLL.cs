using Katas.Code.StaticTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using static Voxel.Users;

namespace Voxel.BusinessLayer.Users.Registered.ePaymentsSync
{
    /// <summary>
    /// epayment
    /// </summary>
    public static partial class EPaymentsSyncBLL
    {


        /// <summary>
        /// AddEPayment
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="epayment"></param>
        public static void AddEPayment(DatabaseTransaction trans, EPaymentItem epayment)
        {
          

            if (epayment == null)
                throw new ArgumentNullException("epaymentVC");

            long clientSenderId, clientPayerId;
            ServiceSector sectorClientSender, sectorClientPayer;

            // Extraemos datos del cliente (sender)
            KeyValuePair<long, ServiceSector>? clientSenderIdAndSectorId = UsersBLL.GetClientIdAndSectorIdFromPaymentReference(trans, epayment.ClientSenderReference);

            if (clientSenderIdAndSectorId.HasValue)
            {
                clientSenderId = clientSenderIdAndSectorId.Value.Key;
                sectorClientSender = clientSenderIdAndSectorId.Value.Value;
            }
            else
            {
                Exception ex = new Exception("This SenderId doesn't exist");
                ex.Data.Add(nameof(epayment.ClientSenderReference), epayment.ClientSenderReference);
                throw ex;
            }

            // Extraemos datos del cliente (payer)
            KeyValuePair<long, ServiceSector>? clientPayerIdAndSectorId = UsersBLL.GetClientIdAndSectorIdFromPaymentReference(trans, epayment.ClientPayerReference);

            if (clientPayerIdAndSectorId.HasValue)
            {
                clientPayerId = clientPayerIdAndSectorId.Value.Key;
                sectorClientPayer = clientPayerIdAndSectorId.Value.Value;
            }
            else
            {
                Exception ex = new Exception("This PayerId doesn't exist");
                ex.Data.Add(nameof(epayment.ClientPayerReference), epayment.ClientPayerReference);
                throw ex;
            }

            if (sectorClientSender != sectorClientPayer)
            {
                Exception ex = new Exception("Sender and payer are configured with references in different sectors");
                ex.Data.Add(nameof(epayment.ClientSenderReference), epayment.ClientSenderReference);
                ex.Data.Add(nameof(epayment.ClientPayerReference), epayment.ClientPayerReference);
                throw ex;
            }

            // Extraemos datos de establecimiento
            long? supplierId = null;
            if (epayment.SupplierReferenceType == EPaymentRefType.BAVELID)
            {
                if (!long.TryParse(epayment.SupplierReference, out long supplierIdTmp))
                    throw new Exception("The supplier reference is indicated as bavelID and can not be converted to LONG");
                else
                    supplierId = supplierIdTmp;
            }
            else if ((epayment.DistributePayment.HasValue && epayment.DistributePayment.Value == true) || epayment.EpaymentCreationTool == EpaymentCreationTool.Extranet)
            {
                long? supplierTmp = null;

                // Si el pago viene con referencia de proveedor respecto al cliente debe existir un rollout (el rollout ha de ser del sender)
                if (sectorClientSender == ServiceSector.Travel)
                    supplierTmp = TravelSupplierRolloutsBLL.GetEstabIdFromEstabRef(trans, clientSenderId, epayment.SupplierReference);
                else if (sectorClientSender == ServiceSector.Horeca)
                    supplierTmp = EProcurementSupplierRolloutsBLL.GetSupplierIdFromSupplierRef(trans, clientSenderId, epayment.SupplierReference);

                if (supplierTmp == null)
                {
                    Exception ex = new Exception("This supplier doesn't exist in a rollout with that supplier reference for the customer");
                    ex.Data.Add(nameof(epayment.SupplierReference), epayment.SupplierReference);
                    ex.Data.Add(nameof(clientSenderId), clientSenderId);
                    throw ex;
                }
                else
                {
                    supplierId = supplierTmp.Value;
                }
            }

            if (epayment.EpaymentCreationTool == EpaymentCreationTool.EPayments && !epayment.DistributePayment.HasValue)
            {
                Exception ex = new Exception("The DistributePayment field is required");
                ex.Data.Add(nameof(epayment.SupplierReference), epayment.SupplierReference);
                ex.Data.Add(nameof(clientSenderId), clientSenderId);
                throw ex;
            }

            if (epayment.DistributePayment.HasValue && epayment.DistributePayment.Value == true && string.IsNullOrWhiteSpace(epayment.SupplierEmail))
            {
                Exception ex = new Exception("The SupplierEmail field is required");
                ex.Data.Add(nameof(epayment.SupplierReference), epayment.SupplierReference);
                ex.Data.Add(nameof(clientSenderId), clientSenderId);
                throw ex;
            }

            // Extraemos datos del FOP
            FormOfPayment fop = GetFOPFromEpayment(epayment);

            //Calculamos AuthorizedCharges
            string authorizedCharges = null;
            if (epayment.AuthorizedCharges != null && epayment.AuthorizedCharges.Count > 0)
            {
                authorizedCharges = string.Join(",", epayment.AuthorizedCharges);
            }

            Voxel.Users.UserRole supplierRoleId = null;

            if (supplierId.HasValue)
            {
                //Si es travel 31 y horeca 1
                if (sectorClientSender == ServiceSector.Travel)
                    supplierRoleId = Voxel.Users.UserRole.SupplierEstablishment;
                else if (sectorClientSender == ServiceSector.Horeca)
                    supplierRoleId = Voxel.Users.UserRole.Supplier;
            }

            MailUrn email;
            if (!string.IsNullOrWhiteSpace(epayment.SupplierEmail))
                email = new MailUrn(epayment.SupplierEmail);
            else
                email = null;

            //Si es EPayments hacemos Update
            if (epayment.EpaymentCreationTool == EpaymentCreationTool.EPayments)
            {
                EPaymentItem existingPayment = GetEPayment(trans, epayment.Reference);
                if (existingPayment != null)
                {
                    // Insertamos la cabecera de pago si es de Extranet
                    DAL.UpdateEPayment(trans, epayment.Reference, epayment.ExpectedAmount, epayment.StartChargeDate, epayment.EndChargeDate, epayment.Status, epayment.Comments, epayment.PrimaryErrorCode, epayment.SecondaryErrorCode, epayment.ErrorMessage);
                    if (fop != FormOfPayment.BankTransfer)
                    {
                        SendSettledPaymentNotification(trans, clientSenderId, epayment.Invoices, supplierId ?? null, epayment.SupplierName, email, epayment.Status, sectorClientSender, existingPayment.Status);
                    }
                }
                else
                {
                    // Insertamos la cabecera de pago si es de Extranet
                    DAL.AddEPayment(trans, epayment.Reference, fop, epayment.Status, epayment.EpaymentCreationTool, sectorClientSender, supplierId, supplierRoleId, epayment.ClientSenderReference, epayment.ClientPayerReference,
                        clientSenderId, clientPayerId, epayment.ExpectedCurrency, epayment.ExpectedAmount, epayment.Services, epayment.Restrictions,
                        epayment.SupplierReferenceType, epayment.SupplierReference, epayment.SupplierName, epayment.SupplierAddress, epayment.SupplierZip,
                        epayment.SupplierCity, epayment.SupplierRegion, epayment.SupplierCountry, epayment.SupplierEmail, epayment.StartChargeDate, epayment.EndChargeDate,
                        epayment.InvoiceRequired, epayment.FullCredit, epayment.BilltoTaxId, epayment.BilltoName, epayment.BilltoAddress, epayment.BilltoZip,
                        epayment.BilltoCity, epayment.BilltoRegion, epayment.BilltoCountry, epayment.BilltoEmail, epayment.Creation,
                        epayment.ExtendendProperties, epayment.Comments, authorizedCharges, epayment.PrimaryErrorCode, epayment.SecondaryErrorCode, epayment.ErrorMessage);
                    if (fop != FormOfPayment.BankTransfer)
                    {
                        SendSettledPaymentNotification(trans, clientSenderId, epayment.Invoices, supplierId ?? null, epayment.SupplierName, email, epayment.Status, sectorClientSender, null);
                    }
                }

            }
            else if (epayment.EpaymentCreationTool == EpaymentCreationTool.Extranet)
            {
                // Insertamos la cabecera de pago si es de Extranet
                DAL.AddEPayment(trans, epayment.Reference, fop, epayment.Status, epayment.EpaymentCreationTool, sectorClientSender, supplierId, supplierRoleId, epayment.ClientSenderReference, epayment.ClientPayerReference,
                    clientSenderId, clientPayerId, epayment.ExpectedCurrency, epayment.ExpectedAmount, epayment.Services, epayment.Restrictions,
                    epayment.SupplierReferenceType, epayment.SupplierReference, epayment.SupplierName, epayment.SupplierAddress, epayment.SupplierZip,
                    epayment.SupplierCity, epayment.SupplierRegion, epayment.SupplierCountry, epayment.SupplierEmail, epayment.StartChargeDate, epayment.EndChargeDate,
                    epayment.InvoiceRequired, epayment.FullCredit, epayment.BilltoTaxId, epayment.BilltoName, epayment.BilltoAddress, epayment.BilltoZip,
                    epayment.BilltoCity, epayment.BilltoRegion, epayment.BilltoCountry, epayment.BilltoEmail, epayment.Creation,
                    epayment.ExtendendProperties, epayment.Comments, authorizedCharges, epayment.PrimaryErrorCode, epayment.SecondaryErrorCode, epayment.ErrorMessage);
                if (fop != FormOfPayment.BankTransfer)
                {
                    SendSettledPaymentNotification(trans, clientSenderId, epayment.Invoices, supplierId ?? null, epayment.SupplierName, email, epayment.Status, sectorClientSender, null);
                }
            }
            else
            {
                Exception ex = new Exception("The origin of the payment or creationTool hasn't been defined.");
                ex.Data.Add(nameof(epayment.SupplierReference), epayment.SupplierReference);
                ex.Data.Add(nameof(clientSenderId), clientSenderId);
                throw ex;
            }

            // Insertamos los datos específicos del FOP
            if (fop == FormOfPayment.VirtualCard)
            {
                EPaymentsVCardItem epaymentVc = epayment as EPaymentsVCardItem;
                DAL.AddEPaymentVCard(trans, epayment.Reference, epaymentVc.VCreference, epaymentVc.Scheme, epaymentVc.Type, epaymentVc.VCExtendendProperties);
            }

            // Insertamos bookings
            if (epayment.Bookings != null && epayment.Bookings.Count() > 0)
            {
                DAL.AddEPymntBooking(trans, epayment.Reference, epayment.Bookings);

                // Insertmamos guests de los bookings
                foreach (EPaymentBookingItem booking in epayment.Bookings)
                {
                    if (booking.Guests != null && booking.Guests.Count() > 0)
                        DAL.AddEPymntBookingGuest(trans, epayment.Reference, booking.Reference, booking.Guests);
                }
            }

            // Insertamos facturas
            if (epayment.Invoices != null && epayment.Invoices.Count() > 0)
                DAL.AddEPymntInvoice(trans, epayment.Reference, epayment.Invoices);

            // Insertamos albaranes
            if (epayment.DeliveryNotes != null && epayment.DeliveryNotes.Count() > 0)
                DAL.AddEPymntDeliveryNote(trans, epayment.Reference, epayment.DeliveryNotes);

            // Insertamos autoalbaranes
            if (epayment.SelfDeliveryNotes != null && epayment.SelfDeliveryNotes.Count() > 0)
                DAL.AddEPymntSelfDeliveryNote(trans, epayment.Reference, epayment.SelfDeliveryNotes);

            // Insertamos órdenes de compra
            if (epayment.PurchaseOrders != null && epayment.PurchaseOrders.Count() > 0)
                DAL.AddEPymntPurchaseOrder(trans, epayment.Reference, epayment.PurchaseOrders);

            //Si el sector del sender es travel y tiene distribución
            if (sectorClientSender == ServiceSector.Travel && epayment.DistributePayment.HasValue && epayment.DistributePayment == true)
            {
                // Extraemos la alienet ascendiente del cliente
                long? alienetId = AlienetBLL.GetAlienIdFromUserId(trans, clientSenderId);
                long? rolloutItemId = RolloutsBLL.ExistEstabInRollout(trans, alienetId.Value, supplierId.Value, sectorClientSender, supplierRoleId.Value);
                
                if (alienetId.HasValue && rolloutItemId.HasValue && fop!=FormOfPayment.BankTransfer)
                    SentNotificationNewEPaymentReceived(
                        trans,
                        sectorClientSender,
                        alienetId.Value,
                        clientSenderId,
                        (UserRole)supplierRoleId,
                        (long)supplierId,
                        epayment.SupplierName,
                        email,
                        fop,
                        epayment.Bookings,
                        epayment.Invoices,
                        rolloutItemId.Value);
            }

            try
            {
                //Enviamos notificación de mail si el pago contiene errores
                if (epayment.DistributePayment.HasValue && epayment.DistributePayment == true)
                {
                    if (!String.IsNullOrWhiteSpace(epayment.ErrorMessage) || epayment.PrimaryErrorCode != null || epayment.SecondaryErrorCode != null)
                    {
                        string emailList = IntegratedBLL.GetNotificationEmails(trans, clientSenderId, sectorClientSender, UserRole.Client);
                        string epayInvoice = "";

                        if (epayment.Invoices.Count > 0)
                            epayInvoice = epayment.Invoices[0].Reference;

                        if (!String.IsNullOrWhiteSpace(emailList))
                            SentNotificationErrorInPayment(trans, (long)supplierId, clientSenderId, epayment.Reference, epayInvoice, epayment.SupplierName, Convert.ToString(epayment.PrimaryErrorCode), Convert.ToString(epayment.SecondaryErrorCode), emailList);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("ErrorInPaymentNotification", "Failed to complete the error in payment notification sent");
                throw ex;
            }
        }

        private static void SentNotificationErrorInPayment(DatabaseTransaction trans, long supplierId, long clientSenderId, string reference, string epayInvoice, string supplierName, string v1, string v2, string emailList)
        {
            throw new NotImplementedException();
        }

        private static void SentNotificationNewEPaymentReceived(DatabaseTransaction trans, ServiceSector sectorClientSender, long value1, long clientSenderId, UserRole supplierRoleId, long supplierId, string supplierName, MailUrn email, FormOfPayment fop, List<EPaymentBookingItem> bookings, List<EPaymentInvoiceItem> invoices, long value2)
        {
            throw new NotImplementedException();
        }

        private static EPaymentItem GetEPayment(DatabaseTransaction trans, string reference)
        {
            throw new NotImplementedException();
        }

        private static void SendSettledPaymentNotification(DatabaseTransaction trans, long clientSenderId, List<EPaymentInvoiceItem> invoices, long? v, string supplierName, MailUrn email, EPaymentStatus status1, ServiceSector sectorClientSender, object status2)
        {
            throw new NotImplementedException();
        }

        private static FormOfPayment GetFOPFromEpayment(EPaymentItem epayment)
        {
            throw new NotImplementedException();
        }
    }
}