using Katas.Code.StaticTesting;
using Moq;
using System;
using System.Collections.Generic;
using Voxel.BusinessLayer.Users.Registered.ePaymentsSync;
using Xunit;

namespace UnitTests
{
    public class EPaymentsSyncBLLShoud
    {
        [Fact]
        public void EPaymentIsNull()
        {

            DatabaseTransaction trans = new DatabaseTransaction();

            Assert.Throws<ArgumentNullException>(() => new EPaymentSyncBLL2().AddEPayment(trans, null));
        }

        [Fact]
        public void EPaymentIsNotNullAndGetClientSenderIdAndSectorIdRetunrsNull()
        {
            EPaymentItem paym = new EPaymentItem("", null, null, "", "", "", 0, "", "", null, "", "", "", "", "", "", "", "", DateTime.Now, DateTime.Now, null, null, "", "", "", "", "", "", "", "", null, DateTime.Now, null, null, null, null, null, null, "", null, null, null, "");
            DatabaseTransaction trans = new DatabaseTransaction();

            Assert.Throws<Exception>(() => new TesteableEpayments().AddEPayment(trans, paym));
        }

    }

    public class TesteableEpayments : EPaymentSyncBLL2
    {

        protected override KeyValuePair<long, ServiceSector>? GetClientSenderIdAndSectorId(DatabaseTransaction trans, EPaymentItem epayment)
        {
            return null;
        }
    }
}
