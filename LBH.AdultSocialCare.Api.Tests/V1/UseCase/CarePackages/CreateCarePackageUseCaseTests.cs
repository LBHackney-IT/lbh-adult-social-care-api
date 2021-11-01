using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.Constants;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class CreateCarePackageUseCaseTests : BaseTest
    {
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly Mock<ICarePackageGateway> _carePackageGateway;
        private readonly Mock<IServiceUserGateway> _serviceUserGateway;
        private readonly CreateCarePackageUseCase _useCase;

        public CreateCarePackageUseCaseTests()
        {
            _dbManager = new Mock<IDatabaseManager>();
            _carePackageGateway = new Mock<ICarePackageGateway>();
            _serviceUserGateway = new Mock<IServiceUserGateway>();

            _carePackageGateway.Setup(x => x.Create(It.IsAny<CarePackage>())).Verifiable();
            _dbManager.Setup(x => x.SaveAsync(It.IsAny<string>())).Returns(() => Task.Run(() => 1));
            _serviceUserGateway.Setup(x => x.GetRandomAsync()).ReturnsAsync(new ServiceUserDomain { Id = Guid.Parse(UserConstants.DefaultApiUserId) });

            _useCase =
                new CreateCarePackageUseCase(_dbManager.Object, _carePackageGateway.Object, _serviceUserGateway.Object);
        }

        [Theory]
        [MemberData(nameof(ValidCarePackageTestData))]
        public async Task ShouldCreateCarePackageIfDomainIsValid(CarePackageForCreationRequest packageCreationRequest)
        {
            // Arrange
            var packageCreationDomain = packageCreationRequest.ToDomain();

            //Act
            await _useCase.CreateAsync(packageCreationDomain);

            // Assert
            _carePackageGateway.Verify(x => x.Create(It.IsAny<CarePackage>()), Times.Once());
            _serviceUserGateway.Verify(x => x.GetRandomAsync(), Times.Once());
            _dbManager.Verify(x => x.SaveAsync(It.IsAny<string>()), Times.Once());
        }

        [Theory]
        [MemberData(nameof(InvalidCarePackageTestData))]
        public async Task ShouldThrowExceptionIfCarePackageDomainIsInvalid(CarePackageForCreationRequest packageCreationRequest)
        {
            var packageCreationDomain = packageCreationRequest.ToDomain();
            Func<Task> action = () => _useCase.CreateAsync(packageCreationDomain);

            await action.Should().ThrowAsync<ApiException>();

            _carePackageGateway.Verify(x => x.Create(It.IsAny<CarePackage>()), Times.Never);
            _dbManager.Verify(x => x.SaveAsync(It.IsAny<string>()), Times.Never);
        }

        public static IEnumerable<object[]> ValidCarePackageTestData()
        {
            yield return new object[] { TestDataHelper.CarePackageCreationRequest(serviceUserId: Guid.Parse(UserConstants.DefaultApiUserId), packageType: PackageType.ResidentialCare) };
            yield return new object[] { TestDataHelper.CarePackageCreationRequest(serviceUserId: Guid.Parse(UserConstants.DefaultApiUserId), packageType: PackageType.NursingCare) };
        }

        public static IEnumerable<object[]> InvalidCarePackageTestData()
        {
            yield return new object[] { TestDataHelper.CarePackageCreationRequest(serviceUserId: Guid.Parse(UserConstants.DefaultApiUserId), packageType: 0) };
            yield return new object[] { TestDataHelper.CarePackageCreationRequest(serviceUserId: Guid.Parse(UserConstants.DefaultApiUserId), packageType: (PackageType) 123465) };
        }
    }
}
