using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.Gateways.Common
{
    public class CarePackageGatewayTests : BaseInMemoryDatabaseTest
    {
        private readonly ICarePackageGateway _carePackageGateway;

        public CarePackageGatewayTests()
        {
            _carePackageGateway = new CarePackageGateway(Context);
        }

        [Fact]
        public void CreateShouldAddCarePackage()
        {
            var mockSet = new Mock<DbSet<CarePackage>>();
            Context.CarePackages = mockSet.Object;
            var carePackage = TestDataHelper.CreateCarePackage();

            _carePackageGateway.Create(carePackage);

            // Check add was called only once
            mockSet.Verify(x => x.Add(It.IsAny<CarePackage>()), Times.Once());
        }
    }
}
