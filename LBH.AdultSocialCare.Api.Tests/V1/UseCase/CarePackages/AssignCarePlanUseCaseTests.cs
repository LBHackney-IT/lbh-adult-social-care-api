using System;
using System.Linq;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.Constants;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.Services.IO;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class AssignCarePlanUseCaseTests : BaseTest
    {
        private readonly Mock<ICarePackageGateway> _carePackageGatewayMock;
        private readonly Mock<IDatabaseManager> _dbManagerMock;
        private readonly AssignCarePlanUseCase _useCase;

        public AssignCarePlanUseCaseTests()
        {
            var getServiceUseUseCaseMock = new Mock<IGetServiceUserUseCase>();

            getServiceUseUseCaseMock
                .Setup(uc => uc.GetServiceUserInformation(It.IsAny<int>()))
                .ReturnsAsync(() => new ServiceUserResponse
                {
                    Id = UserConstants.DefaultApiUserGuid
                });

            _carePackageGatewayMock = new Mock<ICarePackageGateway>();
            _dbManagerMock = new Mock<IDatabaseManager>();

            var fileStorageMock = new Mock<IFileStorage>();
            var ensureSingleActivePackageTypePerUserUseCase = new EnsureSingleActivePackageTypePerUserUseCase(_carePackageGatewayMock.Object);

            _useCase = new AssignCarePlanUseCase(
                getServiceUseUseCaseMock.Object, _carePackageGatewayMock.Object,
                ensureSingleActivePackageTypePerUserUseCase,
                _dbManagerMock.Object, fileStorageMock.Object);
        }

        [Fact]
        public void ShouldCreateNewPackage()
        {
            var newPackage = new CarePackage();

            _carePackageGatewayMock
                .Setup(g => g.GetServiceUserActivePackagesCount(UserConstants.DefaultApiUserGuid, PackageType.NursingCare, null))
                .ReturnsAsync(0);
            _carePackageGatewayMock
                .Setup(g => g.Create(It.IsAny<CarePackage>()))
                .Callback<CarePackage>(package => newPackage = package);

            var assignment = new CarePlanAssignmentDomain
            {
                HackneyUserId = 1,
                BrokerId = Guid.NewGuid(),
                PackageType = PackageType.NursingCare,
                Notes = "Hello world"
            };

            _useCase.ExecuteAsync(assignment);

            newPackage.BrokerId.Should().Be(assignment.BrokerId);
            newPackage.PackageType.Should().Be(assignment.PackageType);
            newPackage.ServiceUserId.Should().Be(UserConstants.DefaultApiUserGuid);
            newPackage.Status.Should().Be(PackageStatus.New);

            newPackage.Histories.Count.Should().Be(1);
            newPackage.Histories.First().Status.Should().Be(HistoryStatus.NewPackage);
            newPackage.Histories.First().Description.Should().Be(HistoryStatus.NewPackage.GetDisplayName());
            newPackage.Histories.First().RequestMoreInformation.Should().Be(assignment.Notes);

            _dbManagerMock.Verify(mock => mock.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ShouldFailWhenUserHaveActivePackageOfSameType()
        {
            _carePackageGatewayMock
                .Setup(g => g.GetServiceUserActivePackagesCount(UserConstants.DefaultApiUserGuid, PackageType.NursingCare, null))
                .ReturnsAsync(1);

            var assignment = new CarePlanAssignmentDomain
            {
                HackneyUserId = 1,
                BrokerId = Guid.NewGuid(),
                PackageType = PackageType.NursingCare
            };

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(assignment))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status500InternalServerError);

            _dbManagerMock.Verify(mock => mock.SaveAsync(It.IsAny<string>()), Times.Never);
        }
    }
}
