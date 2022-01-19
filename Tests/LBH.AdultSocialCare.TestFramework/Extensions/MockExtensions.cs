using LBH.AdultSocialCare.Api.V1.Gateways;
using Moq;

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
    }
}
