using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Voxel.BusinessLayer.Users.Registered.ePaymentsSync
{
    /// <summary>
    /// EPaymentsVCardItem
    /// </summary>
    [DataContract(Namespace = "http://www.voxelgroup.net/Services/Models", Name = "EPaymentsVCardItem")]
    public class EPaymentsVCardItem : EPaymentItem
    {
        [DataMember]
        readonly private string vCReference;
        [DataMember]
        readonly private VirtualCardScheme scheme;
        [DataMember]
        readonly private VirtualCardType type;
        [DataMember]
        readonly private List<KeyValuePair<string, string>> vCExtendendProperties;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="epayment"></param>
        /// <param name="vCReference"></param>
        /// <param name="scheme"></param>
        /// <param name="type"></param>
        /// <param name="vCExtendendProperties"></param>
        public EPaymentsVCardItem(EPaymentItem epayment,
            string vCReference, VirtualCardScheme scheme, VirtualCardType type,
            List<KeyValuePair<string, string>> vCExtendendProperties) : base (
                                epayment.Reference, epayment.Status, epayment.EpaymentCreationTool, epayment.ClientSenderReference, epayment.ClientPayerReference,
                                epayment.ExpectedCurrency, epayment.ExpectedAmount,
                                epayment.Services, epayment.Restrictions, epayment.SupplierReferenceType, epayment.SupplierReference,
                                epayment.SupplierName, epayment.SupplierAddress, epayment.SupplierZip, epayment.SupplierCity,
                                epayment.SupplierRegion, epayment.SupplierCountry, epayment.SupplierEmail, epayment.StartChargeDate,
                                epayment.EndChargeDate, epayment.InvoiceRequired, epayment.FullCredit, epayment.BilltoTaxId,
                                epayment.BilltoName, epayment.BilltoAddress, epayment.BilltoZip, epayment.BilltoCity,
                                epayment.BilltoRegion, epayment.BilltoCountry, epayment.BilltoEmail, epayment.DistributePayment, epayment.Creation,
                                epayment.ExtendendProperties, epayment.Bookings, epayment.Invoices, epayment.DeliveryNotes, epayment.PurchaseOrders, epayment.SelfDeliveryNotes, 
                                epayment.Comments, epayment.AuthorizedCharges, epayment.PrimaryErrorCode, epayment.SecondaryErrorCode, epayment.ErrorMessage)
        {
            this.vCReference = vCReference;
            this.scheme = scheme;
            this.type = type;
            this.vCExtendendProperties = vCExtendendProperties;
        }

        /// <summary>
        /// VCreference
        /// </summary>
        public string VCreference
        {
            get
            {
                return vCReference;
            }
        }

        /// <summary>
        /// Scheme
        /// </summary>
        public VirtualCardScheme Scheme
        {
            get
            {
                return scheme;
            }
        }

        /// <summary>
        /// Type
        /// </summary>
        public VirtualCardType Type
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// VCExtendendProperties
        /// </summary>
        public List<KeyValuePair<string, string>> VCExtendendProperties
        {
            get
            {
                return vCExtendendProperties;
            }
        }
    }
}
