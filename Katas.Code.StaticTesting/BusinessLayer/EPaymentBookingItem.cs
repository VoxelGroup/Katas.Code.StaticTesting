using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Voxel.BusinessLayer.Users.Registered.ePaymentsSync
{

    /// <summary>
    /// class EPaymentBooking
    /// </summary>
    [DataContract(Namespace = "http://www.voxelgroup.net/Services/Models", Name = "EPaymentBookingItem")]
    public class EPaymentBookingItem
    {
        //[DataMember] readonly long m_vcId;
        [DataMember]
        readonly string m_reference;
        [DataMember]
        readonly DateTime m_CheckInDate;
        [DataMember]
        readonly DateTime m_CheckOutDate;
        [DataMember]
        readonly List<EPaymentBookingGuestItem> m_Guests;

        ///// <summary>Identificador de la VC.</summary>
        //public long VCId { get { return m_vcId; } }

        /// <summary>Referencia de la VC.</summary>
        public string Reference { get { return m_reference; } }

        /// <summary>Inicio de la reserva.</summary>
        public DateTime CheckInDate { get { return m_CheckInDate; } }

        /// <summary>Final de la reserva.</summary>
        public DateTime CheckOutDate { get { return m_CheckOutDate; } }

        /// <summary>Guests.</summary>
        public List<EPaymentBookingGuestItem> Guests { get { return m_Guests; } }

        /// <summary>
        /// Constructor EPaymentBooking
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="checkInDate"></param>
        /// <param name="checkOutDate"></param>
        public EPaymentBookingItem(string reference, DateTime checkInDate, DateTime checkOutDate, List<EPaymentBookingGuestItem> guests)
        {
            if (string.IsNullOrWhiteSpace(reference))
                throw new Exception("Argument reference null on constructor of VirtualCardBooking class.");

            this.m_reference = reference;
            this.m_CheckInDate = checkInDate;
            this.m_CheckOutDate = checkOutDate;
            this.m_Guests = guests;
        }
    }
}
