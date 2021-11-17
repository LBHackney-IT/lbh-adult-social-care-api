using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using LBH.AdultSocialCare.Data.Constants.Enums;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class EnsureSingleActivePackageTypePerUserUseCaseTests : BaseTest
    {
        private readonly Mock<ICarePackageGateway> _carePackageGateway;

        public EnsureSingleActivePackageTypePerUserUseCaseTests()
        {
            _carePackageGateway = new Mock<ICarePackageGateway>();
        }

        [Fact]
        public void ShouldNotFailWhenUserDoesNotHaveActivePackage()
        {
            var packageId = Guid.NewGuid();
            var serviceUserId = Guid.NewGuid();
            var packageType = PackageType.NursingCare;

            _carePackageGateway
                .Setup(g => g.GetServiceUserActivePackagesCount(serviceUserId, packageType, packageId))
                .ReturnsAsync(0);

            var useCase = new EnsureSingleActivePackageTypePerUserUseCase(_carePackageGateway.Object);

            useCase
                .Invoking(uc => uc.ExecuteAsync(serviceUserId, packageType, packageId))
                .Should().NotThrow();
        }

        [Fact]
        public void ShouldFailWhenUserHasActivePackage()
        {
            var packageId = Guid.NewGuid();
            var serviceUserId = Guid.NewGuid();
            var packageType = PackageType.NursingCare;

            _carePackageGateway
                .Setup(g => g.GetServiceUserActivePackagesCount(serviceUserId, packageType, packageId))
                .ReturnsAsync(1);

            var useCase = new EnsureSingleActivePackageTypePerUserUseCase(_carePackageGateway.Object);

            useCase
                .Invoking(uc => uc.ExecuteAsync(serviceUserId, packageType, packageId))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status500InternalServerError);
        }
    }
}
