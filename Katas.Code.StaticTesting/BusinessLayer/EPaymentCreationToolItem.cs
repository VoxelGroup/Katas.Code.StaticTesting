using System.Runtime.Serialization;

namespace Voxel.BusinessLayer.Users.Registered.ePaymentsSync
{
    [DataContract]
    public enum EpaymentCreationTool
    {
        [EnumMember]
        NotDefined = 0,
        [EnumMember]
        EPayments = 1,
        [EnumMember]
        Extranet = 2
    }
}
