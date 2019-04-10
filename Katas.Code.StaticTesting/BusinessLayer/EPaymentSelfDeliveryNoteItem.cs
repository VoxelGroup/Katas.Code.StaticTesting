using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Voxel.BusinessLayer.Users.Registered.ePaymentsSync
{
    /// <summary>
    /// EPaymentSelfDeliveryNote
    /// </summary>
    [DataContract(Namespace = "http://www.voxelgroup.net/Services/Models", Name = "EPaymentSelfDeliveryNoteItem")]
    public class EPaymentSelfDeliveryNoteItem
    {
        [DataMember]
        readonly string m_reference;
        [DataMember]
        readonly DateTime m_selfDeliveryNoteDate;
        [DataMember]
        readonly decimal? m_amount;
        [DataMember]
        readonly string m_description;

        /// <summary>Referencia de la auto nota de entrega.</summary>
        public string Reference { get { return this.m_reference; } }

        /// <summary>Fecha de la auto nota de entrega.</summary>
        public DateTime SelfDeliveryNoteDate { get { return this.m_selfDeliveryNoteDate; } }

        /// <summary>Amount de la auto nota de entrega.</summary>
        public decimal? Amount { get { return this.m_amount; } }

        /// <summary>Descripcion de la auto nota de entrega.</summary>
        public string Description { get { return this.m_description; } }

        /// <summary>
        /// Constructor EPaymentSelfDeliveryNote
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="selfDeliveryNoteDate"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        public EPaymentSelfDeliveryNoteItem(string reference, DateTime selfDeliveryNoteDate, decimal? amount, string description)
        {
            if (string.IsNullOrWhiteSpace(reference))
                throw new Exception("Null reference argument on constructor of EPaymentSelfDeliveryNoteItem class.");

            this.m_reference = reference;
            this.m_selfDeliveryNoteDate = selfDeliveryNoteDate;
            this.m_amount = amount;
            this.m_description = description;
        }
    }
}
