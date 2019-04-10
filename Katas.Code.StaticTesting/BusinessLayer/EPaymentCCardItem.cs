using System.Runtime.Serialization;

namespace Voxel.BusinessLayer.Users.Registered.ePaymentsSync
{
    /// <summary>EPaymentCCardItem</summary>

    [DataContract(Namespace = "http://www.voxelgroup.net/Services/Models", Name = "EPaymentCCardItem")]
    public class EPaymentCCardItem : EPaymentItem
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="epayment"></param>
        public EPaymentCCardItem(EPaymentItem epayment) : base(
            epayment.Reference, epayment.Status, epayment.EpaymentCreationTool, epayment.ClientSenderReference, epayment.ClientPayerReference,
            epayment.ExpectedCurrency, epayment.ExpectedAmount,
            epayment.Services, epayment.Restrictions, epayment.SupplierReferenceType, epayment.SupplierReference,
            epayment.SupplierName, epayment.SupplierAddress, epayment.SupplierZip, epayment.SupplierCity,
            epayment.SupplierRegion, epayment.SupplierCountry, epayment.SupplierEmail, epayment.StartChargeDate,
            epayment.EndChargeDate, epayment.InvoiceRequired, epayment.FullCredit, epayment.BilltoTaxId,
            epayment.BilltoName, epayment.BilltoAddress, epayment.BilltoZip, epayment.BilltoCity,
            epayment.BilltoRegion, epayment.BilltoCountry, epayment.BilltoEmail, epayment.DistributePayment, epayment.Creation,
            epayment.ExtendendProperties, epayment.Bookings, epayment.Invoices, epayment.DeliveryNotes, epayment.PurchaseOrders, epayment.SelfDeliveryNotes, epayment.Comments,
            epayment.AuthorizedCharges, epayment.PrimaryErrorCode, epayment.SecondaryErrorCode, epayment.ErrorMessage)
        {
        }
    }
}
