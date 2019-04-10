using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Voxel.BusinessLayer.Users.Registered.ePaymentsSync
{
    /// <summary>
    /// EPaymentInvoice
    /// </summary>
    [DataContract(Namespace = "http://www.voxelgroup.net/Services/Models", Name = "EPaymentInvoiceItem")]
    public class EPaymentInvoiceItem
    {
        [DataMember]
        readonly string m_reference;
        [DataMember]
        readonly DateTime m_invoiceDate;
        [DataMember]
        readonly decimal? m_amount;
        [DataMember]
        readonly string m_description;

        /// <summary>Referencia de la factura.</summary>
        public string Reference { get { return this.m_reference; } }

        /// <summary>Fecha de la factura.</summary>
        public DateTime InvoiceDate { get { return this.m_invoiceDate; } }

        /// <summary>Amount de la factura.</summary>
        public decimal? Amount { get { return this.m_amount; } }

        /// <summary>Descripcion de la factura.</summary>
        public string Description { get { return this.m_description; } }

        /// <summary>
        /// Constructor EPaymentInvoice
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="invoiceDate"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        public EPaymentInvoiceItem(string reference, DateTime invoiceDate, decimal? amount, string description)
        {
            if (string.IsNullOrWhiteSpace(reference))
                throw new Exception("Null reference argument on constructor of EPaymentInvoiceItem class.");

            this.m_reference = reference;
            this.m_invoiceDate = invoiceDate;
            this.m_amount = amount;
            this.m_description = description;
        }
    }
}
