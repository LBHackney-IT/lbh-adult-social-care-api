using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class UpdateCarePackageUseCaseTests : BaseTest
    {
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly Mock<ICarePackageGateway> _carePackageGateway;
        private readonly Mock<ICarePackageSettingsGateway> _carePackageSettingsGateway;
        private readonly UpdateCarePackageUseCase _useCase;
        private readonly Mock<ICreatePackageResourceUseCase> _createPackageResourceUseCase;

        public UpdateCarePackageUseCaseTests()
        {
            _dbManager = new Mock<IDatabaseManager>();
            _carePackageGateway = new Mock<ICarePackageGateway>();
            _carePackageSettingsGateway = new Mock<ICarePackageSettingsGateway>();
            _createPackageResourceUseCase = new Mock<ICreatePackageResourceUseCase>();

            _carePackageGateway.Setup(cp => cp.GetPackagePlainAsync(It.IsAny<Guid>(), It.IsAny<bool>())).ReturnsAsync(() => null);
            _carePackageSettingsGateway.Setup(cps => cps.GetPackageSettingsPlainAsync(It.IsAny<Guid>(), It.IsAny<bool>())).ReturnsAsync(() => null);

            var ensureSingleActivePackageTypePerUserUseCase = new EnsureSingleActivePackageTypePerUserUseCase(_carePackageGateway.Object);

            _useCase = new UpdateCarePackageUseCase(
                Mapper, _dbManager.Object, _carePackageGateway.Object,
                _carePackageSettingsGateway.Object, ensureSingleActivePackageTypePerUserUseCase, _createPackageResourceUseCase.Object);
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
        public async Task ShouldCreatePackageSettingsIfNotFound()
        {
            var carePackage = TestDataHelper.CreateCarePackage();
            carePackage.Settings = TestDataHelper.CreateCarePackageSettings();
            _dbManager.Setup(dm => dm.SaveAsync(It.IsAny<string>())).Returns(() => Task.FromResult(carePackage));

            _carePackageGateway.Setup(cp => cp.GetPackagePlainAsync(It.IsAny<Guid>(), It.IsAny<bool>())).ReturnsAsync(() => carePackage);

            var updateRequest = TestDataHelper.CarePackageUpdateRequest(carePackage,
                carePackage.Settings);

            await _useCase.UpdateAsync(carePackage.Id, updateRequest.ToDomain());

            carePackage.Settings.Should().BeEquivalentTo(carePackage.Settings, opt => opt.ExcludingMissingMembers().ExcludingNestedObjects());

            _carePackageGateway.Verify(x => x.GetPackagePlainAsync(It.IsAny<Guid>(), It.IsAny<bool>()), Times.Once);
            _carePackageSettingsGateway.Verify(x => x.GetPackageSettingsPlainAsync(It.IsAny<Guid>(), It.IsAny<bool>()), Times.Once);
            _dbManager.Verify(x => x.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ShouldFailWhenUserHaveActivePackageOfSameType()
        {
            var package = TestDataHelper.CreateCarePackage();
            package.Settings = TestDataHelper.CreateCarePackageSettings();

            _carePackageGateway
                .Setup(g => g.GetPackagePlainAsync(package.Id, It.IsAny<bool>()))
                .ReturnsAsync(package);
            _carePackageGateway
                .Setup(g => g.GetServiceUserActivePackagesCount(package.ServiceUserId, package.PackageType, package.Id))
                .ReturnsAsync(1);

            var updateRequest = TestDataHelper.CarePackageUpdateRequest(package, package.Settings);

            _useCase
                .Invoking(useCase => useCase.UpdateAsync(package.Id, updateRequest.ToDomain()))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status500InternalServerError);

            _dbManager.Verify(mock => mock.SaveAsync(It.IsAny<string>()), Times.Never);
        }
    }
}
