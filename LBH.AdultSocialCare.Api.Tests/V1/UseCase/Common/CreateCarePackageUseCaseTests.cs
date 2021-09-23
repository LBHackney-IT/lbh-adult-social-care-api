using LBH.AdultSocialCare.Api.Tests.V1.Constants;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Common
{
    public class CreateCarePackageUseCaseTests : BaseTest
    {
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly Mock<ICarePackageGateway> _carePackageGateway;
        private readonly Mock<IClientsGateway> _clientsGateway;

        private readonly DateTimeOffset _today = DateTimeOffset.Now;

        public CreateCarePackageUseCaseTests()
        {
            _dbManager = new Mock<IDatabaseManager>();
            _carePackageGateway = new Mock<ICarePackageGateway>();
            _clientsGateway = new Mock<IClientsGateway>();

            _carePackageGateway.Setup(x => x.Create(It.IsAny<CarePackage>())).Verifiable();
            _dbManager.Setup(x => x.SaveAsync(It.IsAny<string>())).Returns(() => Task.Run(() => 1));
        }

        [Fact]
        public async Task ShouldCreateResidentialCarePackageIfDomainIsValid()
        {
            // Arrange
            _clientsGateway.Setup(x => x.GetRandomAsync()).ReturnsAsync(new ClientsDomain { Id = Guid.Parse(UserConstants.DefaultApiUserId) });
            var useCase =
                new CreateCarePackageUseCase(_dbManager.Object, _carePackageGateway.Object, _clientsGateway.Object);
            var packageCreationRequest = TestDataHelper
                .ResidentialCarePackageCreationRequest(serviceUserId: Guid.Parse(UserConstants.DefaultApiUserId),
                    startDate: _today, endDate: _today.AddDays(30), packageType: PackageType.ResidentialCare,
                    packageScheduling: nameof(PackageScheduling.Interim));
            var packageCreationDomain = packageCreationRequest.ToDomain();

            //Act
            await useCase.ResidentialAsync(packageCreationDomain).ConfigureAwait(false);

            // Assert
            _carePackageGateway.Verify(x => x.Create(It.IsAny<CarePackage>()), Times.Once());
            _clientsGateway.Verify(x => x.GetRandomAsync(), Times.Once());
            _dbManager.Verify(x => x.SaveAsync(It.IsAny<string>()), Times.Once());
        }
    }
}
