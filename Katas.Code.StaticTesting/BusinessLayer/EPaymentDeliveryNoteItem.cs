using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Voxel.BusinessLayer.Users.Registered.ePaymentsSync
{
    /// <summary>
    /// EPaymentDeliveryNote
    /// </summary>
    [DataContract(Namespace = "http://www.voxelgroup.net/Services/Models", Name = "EPaymentDeliveryNoteItem")]
    public class EPaymentDeliveryNoteItem
    {
        [DataMember]
        readonly string m_reference;
        [DataMember]
        readonly DateTime m_deliveryNoteDate;
        [DataMember]
        readonly decimal? m_amount;
        [DataMember]
        readonly string m_description;

        /// <summary>Referencia de la nota de entrega.</summary>
        public string Reference { get { return this.m_reference; } }

        /// <summary>Fecha de la nota de entrega.</summary>
        public DateTime DeliveryNoteDate { get { return this.m_deliveryNoteDate; } }

        /// <summary>Amount de la nota de entrega.</summary>
        public decimal? Amount { get { return this.m_amount; } }

        /// <summary>Descripcion de la nota de entrega.</summary>
        public string Description { get { return this.m_description; } }

        /// <summary>
        /// Constructor EPaymentDeliveryNote
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="deliveryNoteDate"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        public EPaymentDeliveryNoteItem(string reference, DateTime deliveryNoteDate, decimal? amount, string description)
        {
            if (string.IsNullOrWhiteSpace(reference))
                throw new Exception("Null reference argument on constructor of EPaymentDeliveryNoteItem class.");

            this.m_reference = reference;
            this.m_deliveryNoteDate = deliveryNoteDate;
            this.m_amount = amount;
            this.m_description = description;
        }
    }
}
