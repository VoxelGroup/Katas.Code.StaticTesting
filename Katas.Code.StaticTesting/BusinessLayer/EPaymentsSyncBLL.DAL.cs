using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Katas.Code.StaticTesting;

namespace Voxel.BusinessLayer.Users.Registered.ePaymentsSync
{
    public static partial class EPaymentsSyncBLL
    {
        private static class DAL
        {
            internal static FormOfPayment GetFOPFromEpayment(DatabaseConnection conn, string epaymentReference)
            {
                throw new Exception();
            }

            internal static void AddEPayment(DatabaseTransaction trans,
                                                string reference,
                                                FormOfPayment fop,
                                                EPaymentStatus status,
                                                EpaymentCreationTool epaymentCreationTool,
                                                ServiceSector sector,
                                                long? supplierId,
                                                Voxel.Users.UserRole supplierRoleId,
                                                string clientSenderReference,
                                                string clientPayerReference,
                                                long clientSenderId,
                                                long clientPayerId,
                                                string expectedCurrency,
                                                decimal expectedAmount,
                                                string services,
                                                string restrictions,
                                                EPaymentRefType supplierReferenceType,
                                                string supplierReference,
                                                string supplierName,
                                                string supplierAddress,
                                                string supplierZip,
                                                string supplierCity,
                                                string supplierRegion,
                                                string supplierCountry,
                                                string supplierEmail,
                                                DateTime startChargeDate,
                                                DateTime endChargeDate,
                                                bool? invoiceRequired,
                                                bool? fullCredit,
                                                string billtoTaxId,
                                                string billtoName,
                                                string billtoAddress,
                                                string billtoZip,
                                                string billtoCity,
                                                string billtoRegion,
                                                string billtoCountry,
                                                string billtoEmail,
                                                DateTime creation,
                                                List<KeyValuePair<string, string>> extendendProperties,
                                                string comments,
                                                string authorizedCharges,
                                                short? primaryErrorCode,
                                                short? seconaryErrorCode,
                                                string errorMessage)
            {
                throw new Exception();

            }


            internal static void UpdateEPayment(DatabaseTransaction trans, 
                string epaymentReference, 
                decimal? expectetAmount, 
                DateTime startChargeDate, 
                DateTime endChargeDate, 
                EPaymentStatus status,
                string comments,
                short? primaryErrorCode,
                short? secondaryErrorCode,
                string errorMessage)
            {
                throw new Exception();

            }

            internal static void AddEPaymentVCard(DatabaseTransaction trans,
                                                  string ePaymentReference,
                                                  string vCReference,
                                                  VirtualCardScheme scheme,
                                                  VirtualCardType type,
                                                  List<KeyValuePair<string, string>> extendendProperties
                                                  )
            {
                throw new Exception();

            }

            internal static void AddEPymntBooking(DatabaseTransaction trans,
                                                 string ePaymentReference,
                                                 List<EPaymentBookingItem> bookings
                                                 )
            {
                throw new Exception();

            }

            internal static void AddEPymntInvoice(DatabaseTransaction trans,
                                                 string ePaymentReference,
                                                 List<EPaymentInvoiceItem> invoices
                                                 )
            {
                throw new Exception();

            }

            internal static void AddEPymntDeliveryNote(DatabaseTransaction trans,
                                                 string ePaymentReference,
                                                 List<EPaymentDeliveryNoteItem> deliveryNotes
                                                 )
            {
                throw new Exception();

            }

            internal static void AddEPymntSelfDeliveryNote(DatabaseTransaction trans,
                                                 string ePaymentReference,
                                                 List<EPaymentSelfDeliveryNoteItem> selfDeliveryNotes
                                                 )
            {
                throw new Exception();

            }

            internal static void AddEPymntPurchaseOrder(DatabaseTransaction trans,
                                                 string ePaymentReference,
                                                 List<EPaymentPurchaseOrderItem> purchaseOrders
                                                 )
            {
                throw new Exception();

            }
            internal static void AddEPymntBookingGuest(DatabaseTransaction trans,
                                                 string ePaymentReference,
                                                 string bookingRef,
                                                 List<EPaymentBookingGuestItem> guests
                                                 )
            {
                throw new Exception();

            }

            internal static IEnumerable<EPaymentBookingGuestItem> LstGuests(DatabaseConnection conn, string ePaymentReference, string booking_reference)
            {
                throw new Exception();

            }

            internal static IEnumerable<EPaymentBookingItem> LstBookings(DatabaseConnection conn, string ePaymentReference)
            {
                throw new Exception();

            }

            internal static IEnumerable<EPaymentInvoiceItem> LstInvoices(DatabaseConnection conn, string ePaymentReference)
            {
                throw new Exception();

            }

            internal static IEnumerable<EPaymentDeliveryNoteItem> LstDeliveryNotes(DatabaseConnection conn, string ePaymentReference)
            {
                throw new Exception();

            }

            internal static IEnumerable<EPaymentPurchaseOrderItem> LstPurchaseOrders(DatabaseConnection conn, string ePaymentReference)
            {
                throw new Exception();

            }

            internal static IEnumerable<EPaymentSelfDeliveryNoteItem> LstSelfDeliveryNotes(DatabaseConnection conn, string ePaymentReference)
            {
                throw new Exception();

            }

            internal static void GetEPaymentVCard(DatabaseConnection conn,
                                                 string ePaymentReference, 
                                                 out VirtualCardScheme scheme,
                                                 out VirtualCardType type)
            {

                throw new Exception();


            }

            internal static EPaymentItem GetEPayment(DatabaseConnection conn,
                                                 string ePaymentReference)
            {
                throw new Exception();
            }
        }
        
    }
}
