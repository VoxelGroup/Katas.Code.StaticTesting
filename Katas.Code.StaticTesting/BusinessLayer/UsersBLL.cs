using System;
using System.Collections.Generic;
using Katas.Code.StaticTesting;

namespace Voxel.BusinessLayer.Users.Registered.ePaymentsSync
{
    public class UsersBLL
    {
        public static KeyValuePair<long, ServiceSector>? GetClientIdAndSectorIdFromPaymentReference(DatabaseTransaction trans, string clientSenderReference)
        {
            throw new NotImplementedException();
        }
    }
}