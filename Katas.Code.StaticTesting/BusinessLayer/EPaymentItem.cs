using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Voxel.BusinessLayer.Users.Registered.ePaymentsSync
{
    /// <summary>
    /// ePaymentItem
    /// </summary>
    [DataContract(Namespace="http://www.voxelgroup.net/Services/Models", Name = "EPaymentItem"),
        KnownType(typeof(EPaymentsVCardItem)),
        KnownType(typeof(EPaymentBTGItem)),
        KnownType(typeof(EPaymentCCardItem))]
    public class EPaymentItem
    {
        [DataMember] readonly private string reference;
        [DataMember] readonly private EPaymentStatus status;
        [DataMember] readonly private EpaymentCreationTool epaymentCreationTool;
        [DataMember] readonly private string clientSenderReference;
        [DataMember] readonly private string clientPayerReference;
        [DataMember] readonly private string expectedCurrency;
        [DataMember] readonly private decimal expectedAmount;
        [DataMember] readonly private string services;
        [DataMember] readonly private string restrictions;
        [DataMember] readonly private EPaymentRefType supplierReferenceType;
        [DataMember] readonly private string supplierReference;
        [DataMember] readonly private string supplierName;
        [DataMember] readonly private string supplierAddress;
        [DataMember] readonly private string supplierZip;
        [DataMember] readonly private string supplierCity;
        [DataMember] readonly private string supplierRegion;
        [DataMember] readonly private string supplierCountry;
        [DataMember] readonly private string supplierEmail;
        [DataMember] readonly private DateTime startChargeDate;
        [DataMember] readonly private DateTime endChargeDate;
        [DataMember] readonly private bool? invoiceRequired;
        [DataMember] readonly private bool? fullCredit;
        [DataMember] readonly private string billtoTaxId;
        [DataMember] readonly private string billtoName;
        [DataMember] readonly private string billtoAddress;
        [DataMember] readonly private string billtoZip;
        [DataMember] readonly private string billtoCity;
        [DataMember] readonly private string billtoRegion;
        [DataMember] readonly private string billtoCountry;
        [DataMember] readonly private string billtoEmail;
        [DataMember] readonly private bool? distributePayment;
        [DataMember] readonly private DateTime creation;
        [DataMember] readonly private List<KeyValuePair<string, string>> extendendProperties;
        [DataMember] readonly private List<EPaymentBookingItem> bookings;
        [DataMember] readonly private List<EPaymentInvoiceItem> invoices;
        [DataMember] readonly private List<EPaymentDeliveryNoteItem> deliveryNotes;
        [DataMember] readonly private List<EPaymentPurchaseOrderItem> purchaseOrders;
        [DataMember] readonly private List<EPaymentSelfDeliveryNoteItem> selfDeliveryNotes;
        [DataMember] readonly private string comments;
        [DataMember] readonly private List<string> authorizedCharges;
        [DataMember] readonly private short? primaryErrorCode;
        [DataMember] readonly private short? secondaryErrorCode;
        [DataMember] readonly private string errorMessage;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="status"></param>
        /// <param name="epaymentCreationTool"></param>
        /// <param name="clientSenderReference"></param>
        /// <param name="clientPayerReference"></param>
        /// <param name="expectedCurrency"></param>
        /// <param name="expectedAmount"></param>
        /// <param name="services"></param>
        /// <param name="restrictions"></param>
        /// <param name="supplierReferenceType"></param>
        /// <param name="supplierReference"></param>
        /// <param name="supplierName"></param>
        /// <param name="supplierAddress"></param>
        /// <param name="supplierZip"></param>
        /// <param name="supplierCity"></param>
        /// <param name="supplierRegion"></param>
        /// <param name="supplierCountry"></param>
        /// <param name="supplierEmail"></param>
        /// <param name="startChargeDate"></param>
        /// <param name="endChargeDate"></param>
        /// <param name="invoiceRequired"></param>
        /// <param name="fullCredit"></param>
        /// <param name="billtoTaxId"></param>
        /// <param name="billtoName"></param>
        /// <param name="billtoAddress"></param>
        /// <param name="billtoZip"></param>
        /// <param name="billtoCity"></param>
        /// <param name="billtoRegion"></param>
        /// <param name="billtoCountry"></param>
        /// <param name="billtoEmail"></param>
        /// <param name="distributePayment"></param>
        /// <param name="creation"></param>
        /// <param name="extendendProperties"></param>
        /// <param name="bookings"></param>
        /// <param name="invoices"></param>
        /// <param name="deliveryNotes"></param>
        /// <param name="purchaseOrders"></param>
        /// <param name="selfDeliveryNotes"></param>
        /// <param name="comments"></param>
        /// <param name="authorizedCharges"></param>
        /// <param name="primaryErrorCode"></param>
        /// <param name="secondaryErrorCode"></param>
        /// <param name="errorMessage"></param>
        public EPaymentItem(string reference, EPaymentStatus status, EpaymentCreationTool epaymentCreationTool,
            string clientSenderReference, string clientPayerReference, string expectedCurrency, decimal expectedAmount,
            string services, string restrictions, EPaymentRefType supplierReferenceType, string supplierReference,
            string supplierName, string supplierAddress, string supplierZip, string supplierCity,
            string supplierRegion, string supplierCountry, string supplierEmail, DateTime startChargeDate,
            DateTime endChargeDate, bool? invoiceRequired, bool? fullCredit, string billtoTaxId,
            string billtoName, string billtoAddress, string billtoZip, string billtoCity,
            string billtoRegion, string billtoCountry, string billtoEmail, bool? distributePayment, DateTime creation,
            List<KeyValuePair<string, string>> extendendProperties,
            List<EPaymentBookingItem> bookings,
            List<EPaymentInvoiceItem> invoices,
            List<EPaymentDeliveryNoteItem> deliveryNotes,
            List<EPaymentPurchaseOrderItem> purchaseOrders,
            List<EPaymentSelfDeliveryNoteItem> selfDeliveryNotes,
            string comments,
            List<string> authorizedCharges,
            short? primaryErrorCode, short? secondaryErrorCode, string errorMessage)
        {
            this.reference = reference;
            this.status = status;
            this.epaymentCreationTool = epaymentCreationTool;
            this.clientSenderReference = clientSenderReference;
            this.clientPayerReference = clientPayerReference;
            this.expectedCurrency = expectedCurrency;
            this.expectedAmount = expectedAmount;
            this.services = services;
            this.restrictions = restrictions;
            this.supplierReferenceType = supplierReferenceType;
            this.supplierReference = supplierReference;
            this.supplierName = supplierName;
            this.supplierAddress = supplierAddress;
            this.supplierZip = supplierZip;
            this.supplierCity = supplierCity;
            this.supplierRegion = supplierRegion;
            this.supplierCountry = supplierCountry;
            this.supplierEmail = supplierEmail;
            this.startChargeDate = startChargeDate;
            this.endChargeDate = endChargeDate;
            this.invoiceRequired = invoiceRequired;
            this.fullCredit = fullCredit;
            this.billtoTaxId = billtoTaxId;
            this.billtoName = billtoName;
            this.billtoAddress = billtoAddress;
            this.billtoZip = billtoZip;
            this.billtoCity = billtoCity;
            this.billtoRegion = billtoRegion;
            this.billtoCountry = billtoCountry;
            this.billtoEmail = billtoEmail;
            this.distributePayment = distributePayment;
            this.creation = creation;
            this.extendendProperties = extendendProperties;
            this.bookings = bookings;
            this.invoices = invoices;
            this.deliveryNotes = deliveryNotes;
            this.purchaseOrders = purchaseOrders;
            this.selfDeliveryNotes = selfDeliveryNotes;
            this.comments = comments;
            this.authorizedCharges = authorizedCharges;
            this.primaryErrorCode = primaryErrorCode;
            this.secondaryErrorCode = secondaryErrorCode;
            this.errorMessage = errorMessage;
        }

        /// <summary>
        /// Referenvia de pago
        /// </summary>
        public string Reference
        {
            get
            {
                return reference;
            }
        }

        /// <summary>
        /// Status
        /// </summary>
        public EPaymentStatus Status
        {
            get
            {
                return status;
            }
        }

        /// <summary>
        /// Creation tool
        /// </summary>
        public EpaymentCreationTool EpaymentCreationTool
        {
            get
            {
                return epaymentCreationTool;
            }
        }
        /// <summary>
        /// Client Sender Reference
        /// </summary>
        public string ClientSenderReference
        {
            get
            {
                return clientSenderReference;
            }
        }

        /// <summary>
        /// Client Payer Reference
        /// </summary>
        public string ClientPayerReference
        {
            get
            {
                return clientPayerReference;
            }
        }

        /// <summary>
        /// Expected Currency
        /// </summary>
        public string ExpectedCurrency
        {
            get
            {
                return expectedCurrency;
            }
        }

        /// <summary>
        /// Expected Amount
        /// </summary>
        public decimal ExpectedAmount
        {
            get
            {
                return expectedAmount;
            }
        }

        /// <summary>
        /// Services
        /// </summary>
        public string Services
        {
            get
            {
                return services;
            }
        }

        /// <summary>
        /// Restrictions
        /// </summary>
        public string Restrictions
        {
            get
            {
                return restrictions;
            }
        }

        /// <summary>
        /// Supplier Reference Type
        /// </summary>
        public EPaymentRefType SupplierReferenceType
        {
            get
            {
                return supplierReferenceType;
            }
        }

        /// <summary>
        /// Supplier Reference
        /// </summary>
        public string SupplierReference
        {
            get
            {
                return supplierReference;
            }
        }

        /// <summary>
        /// Supplier Name
        /// </summary>
        public string SupplierName
        {
            get
            {
                return supplierName;
            }
        }

        /// <summary>
        /// Supplier Address
        /// </summary>
        public string SupplierAddress
        {
            get
            {
                return supplierAddress;
            }
        }

        /// <summary>
        /// Supplier Zip
        /// </summary>
        public string SupplierZip
        {
            get
            {
                return supplierZip;
            }
        }

        /// <summary>
        /// Supplier City
        /// </summary>
        public string SupplierCity
        {
            get
            {
                return supplierCity;
            }
        }

        /// <summary>
        /// Supplier Region
        /// </summary>
        public string SupplierRegion
        {
            get
            {
                return supplierRegion;
            }
        }

        /// <summary>
        /// Supplier Country
        /// </summary>
        public string SupplierCountry
        {
            get
            {
                return supplierCountry;
            }
        }

        /// <summary>
        /// Supplier Email
        /// </summary>
        public string SupplierEmail
        {
            get
            {
                return supplierEmail;
            }
        }

        /// <summary>
        /// Start Charge Date
        /// </summary>
        public DateTime StartChargeDate
        {
            get
            {
                return startChargeDate;
            }
        }

        /// <summary>
        /// End Charge Date
        /// </summary>
        public DateTime EndChargeDate
        {
            get
            {
                return endChargeDate;
            }
        }

        /// <summary>
        /// Invoice Required
        /// </summary>
        public bool? InvoiceRequired
        {
            get
            {
                return invoiceRequired;
            }
        }

        /// <summary>
        /// Full Credit
        /// </summary>
        public bool? FullCredit
        {
            get
            {
                return fullCredit;
            }
        }

        /// <summary>
        /// Billto Tax Id
        /// </summary>
        public string BilltoTaxId
        {
            get
            {
                return billtoTaxId;
            }
        }

        /// <summary>
        /// Billto Name
        /// </summary>
        public string BilltoName
        {
            get
            {
                return billtoName;
            }
        }

        /// <summary>
        /// Billto Address
        /// </summary>
        public string BilltoAddress
        {
            get
            {
                return billtoAddress;
            }
        }

        /// <summary>
        /// Billto Zip
        /// </summary>
        public string BilltoZip
        {
            get
            {
                return billtoZip;
            }
        }

        /// <summary>
        /// Billto City
        /// </summary>
        public string BilltoCity
        {
            get
            {
                return billtoCity;
            }
        }

        /// <summary>
        /// Billto Region
        /// </summary>
        public string BilltoRegion
        {
            get
            {
                return billtoRegion;
            }
        }

        /// <summary>
        /// Billto Country
        /// </summary>
        public string BilltoCountry
        {
            get
            {
                return billtoCountry;
            }
        }

        /// <summary>
        /// BilltoEmail
        /// </summary>
        public string BilltoEmail
        {
            get
            {
                return billtoEmail;
            }
        }

        /// <summary>
        /// DistributePayment
        /// </summary>
        public bool? DistributePayment
        {
            get
            {
                return distributePayment;
            }
        }

        /// <summary>
        /// Creation
        /// </summary>
        public DateTime Creation
        {
            get
            {
                return creation;
            }
        }

        /// <summary>
        /// Extendend Properties
        /// </summary>
        public List<KeyValuePair<string, string>> ExtendendProperties
        {
            get
            {
                return extendendProperties;
            }
        }

        /// <summary>
        /// Bookings
        /// </summary>
        public List<EPaymentBookingItem> Bookings
        {
            get
            {
                return bookings;
            }
        }

        /// <summary>
        /// Invoices
        /// </summary>
        public List<EPaymentInvoiceItem> Invoices
        {
            get
            {
                return invoices;
            }
        }

        /// <summary>
        /// DeliveryNotes
        /// </summary>
        public List<EPaymentDeliveryNoteItem> DeliveryNotes
        {
            get
            {
                return deliveryNotes;
            }
        }

        /// <summary>
        /// PurchaseOrders
        /// </summary>
        public List<EPaymentPurchaseOrderItem> PurchaseOrders
        {
            get
            {
                return purchaseOrders;
            }
        }

        /// <summary>
        /// SelfDeliveryNotes
        /// </summary>
        public List<EPaymentSelfDeliveryNoteItem> SelfDeliveryNotes
        {
            get
            {
                return selfDeliveryNotes;
            }
        }

        /// <summary>
        /// Comments
        /// </summary>
        public string Comments
        {
            get
            {
                return comments;
            }
        }

        /// <summary>
        /// Authorized Charges
        /// </summary>
        public List<string> AuthorizedCharges
        {
            get { return authorizedCharges; }
        }

        /// <summary>
        /// Primary error code, indicated the module where the error is generated.
        /// </summary>
        public short? PrimaryErrorCode
        {
            get
            {
                return primaryErrorCode;
            }
        }

        /// <summary>
        /// Secondary error code, indicates issues reported, specific to each of the gateway APIs.
        /// </summary>
        public short? SecondaryErrorCode
        {
            get
            {
                return secondaryErrorCode;
            }
        }

        /// <summary>
        /// Message defined by ePayments system, sumarizes the errors from epayments and the gateways.
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
        }
    }
}
