using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Voxel.BusinessLayer.Users.Registered.ePaymentsSync
{
    /// <summary>
    /// EPaymentPurchaseOrder
    /// </summary>
    [DataContract(Namespace = "http://www.voxelgroup.net/Services/Models", Name = "EPaymentPurchaseOrderItem")]
    public class EPaymentPurchaseOrderItem
    {
        [DataMember]
        readonly string m_reference;
        [DataMember]
        readonly DateTime m_purchaseOrderDate;
        [DataMember]
        readonly decimal? m_amount;
        [DataMember]
        readonly string m_description;

        /// <summary>Referencia de la orden de compra.</summary>
        public string Reference { get { return this.m_reference; } }

        /// <summary>Fecha de la nota de entrega.</summary>
        public DateTime PurchaseOrderDate { get { return this.m_purchaseOrderDate; } }

        /// <summary>Amount de la nota de entrega.</summary>
        public decimal? Amount { get { return this.m_amount; } }

        /// <summary>Descripcion de la nota de entrega.</summary>
        public string Description { get { return this.m_description; } }

        /// <summary>
        /// Constructor EPaymentPurchaseOrder
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="purchaseOrderDate"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        public EPaymentPurchaseOrderItem(string reference, DateTime purchaseOrderDate, decimal? amount, string description)
        {
            if (string.IsNullOrWhiteSpace(reference))
                throw new Exception("Null reference argument on constructor of EPaymentPurchaseOrderItem class.");

            this.m_reference = reference;
            this.m_purchaseOrderDate = purchaseOrderDate;
            this.m_amount = amount;
            this.m_description = description;
        }
    }
}
