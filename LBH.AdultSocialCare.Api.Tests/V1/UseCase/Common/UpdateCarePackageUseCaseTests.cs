using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Common
{
    public class UpdateCarePackageUseCaseTests : BaseTest
    {
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly Mock<ICarePackageGateway> _carePackageGateway;
        private readonly Mock<ICarePackageSettingsGateway> _carePackageSettingsGateway;
        private readonly UpdateCarePackageUseCase _useCase;

        public UpdateCarePackageUseCaseTests()
        {
            _dbManager = new Mock<IDatabaseManager>();
            _carePackageGateway = new Mock<ICarePackageGateway>();
            _carePackageSettingsGateway = new Mock<ICarePackageSettingsGateway>();

            _carePackageGateway.Setup(cp => cp.GetPackagePlainAsync(It.IsAny<Guid>(), It.IsAny<bool>())).ReturnsAsync(() => null);
            _carePackageSettingsGateway.Setup(cps => cps.GetPackageSettingsPlainAsync(It.IsAny<Guid>(), It.IsAny<bool>())).ReturnsAsync(() => null);

            _useCase = new UpdateCarePackageUseCase(Mapper, _dbManager.Object, _carePackageGateway.Object,
                _carePackageSettingsGateway.Object);
        }

        [Fact]
        public async Task ShouldThrowExceptionIfPackageNotFound()
        {
            var carePackage = TestDataHelper.CreateCarePackage();
            var updateRequest = TestDataHelper.CarePackageUpdateRequest(carePackage,
                TestDataHelper.CreateCarePackageSettings());

            Func<Task> action = () => _useCase.UpdateAsync(carePackage.Id, updateRequest.ToDomain());

            await action.Should().ThrowAsync<ApiException>();

            _carePackageGateway.Verify(x => x.GetPackagePlainAsync(It.IsAny<Guid>(), It.IsAny<bool>()), Times.Once);
            _carePackageSettingsGateway.Verify(x => x.GetPackageSettingsPlainAsync(It.IsAny<Guid>(), It.IsAny<bool>()), Times.Never);
            _dbManager.Verify(x => x.SaveAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task ShouldThrowExceptionIfPackageSettingsNotFound()
        {
            var carePackage = TestDataHelper.CreateCarePackage();

            _carePackageGateway.Setup(cp => cp.GetPackagePlainAsync(It.IsAny<Guid>(), It.IsAny<bool>())).ReturnsAsync(() => carePackage);

            var updateRequest = TestDataHelper.CarePackageUpdateRequest(carePackage,
                TestDataHelper.CreateCarePackageSettings());

            Func<Task> action = () => _useCase.UpdateAsync(carePackage.Id, updateRequest.ToDomain());

            await action.Should().ThrowAsync<ApiException>();

            _carePackageGateway.Verify(x => x.GetPackagePlainAsync(It.IsAny<Guid>(), It.IsAny<bool>()), Times.Once);
            _carePackageSettingsGateway.Verify(x => x.GetPackageSettingsPlainAsync(It.IsAny<Guid>(), It.IsAny<bool>()), Times.Once);
            _dbManager.Verify(x => x.SaveAsync(It.IsAny<string>()), Times.Never);
        }
    }
}
