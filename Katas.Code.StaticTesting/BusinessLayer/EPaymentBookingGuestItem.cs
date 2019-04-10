using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Voxel.BusinessLayer.Users.Registered.ePaymentsSync
{
    /// <summary>
    /// EPaymentBookingGuest
    /// </summary>
    [DataContract(Namespace = "http://www.voxelgroup.net/Services/Models", Name = "EPaymentBookingGuestItem")]
    public class EPaymentBookingGuestItem
    {

        [DataMember]
        readonly string m_firstName;
        [DataMember]
        readonly string m_lastName;
        [DataMember]
        readonly string m_title;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="title"></param>
        public EPaymentBookingGuestItem(string firstName, 
            string lastName, string title)
        {            
            this.m_firstName = firstName;
            this.m_lastName = lastName;
            this.m_title = title;
        }

        /// <summary>Nombre</summary>
        public string FirstName { get { return this.m_firstName; } }

        /// <summary>Apellidos.</summary>
        public string LastName { get { return this.m_lastName; } }

        /// <summary>Posición</summary>
        public string Title { get { return this.m_title; } }


    }
}
