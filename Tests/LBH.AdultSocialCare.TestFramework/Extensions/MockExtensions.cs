using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using Moq;
using System;

namespace LBH.AdultSocialCare.TestFramework.Extensions
{
    public static class MockExtensions
    {
        public static void VerifySaved(this Mock<IDatabaseManager> dbManager)
        {
            dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        public static void VerifyNotSaved(this Mock<IDatabaseManager> dbManager)
        {
            dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Never);
        }

        public static void VerifyGetPayRun(this Mock<IPayRunGateway> payRunGateway)
        {
            payRunGateway.Verify(pr => pr.GetPayRunAsync(It.IsAny<Guid>(), It.IsAny<PayRunFields>(), It.IsAny<bool>()), Times.Once);
        }
    }
}
