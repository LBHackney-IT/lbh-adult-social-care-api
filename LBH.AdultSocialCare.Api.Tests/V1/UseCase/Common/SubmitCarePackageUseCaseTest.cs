using System;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.Constants;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Common
{
    public class SubmitCarePackageUseCaseTest : BaseTest
    {
        private readonly Mock<ICarePackageGateway> _gatewayMock;
        private readonly Mock<IDatabaseManager> _dbManagerMock;
        private readonly SubmitCarePackageUseCase _useCase;
        private readonly CarePackage _package;

        public SubmitCarePackageUseCaseTest()
        {
            _package = new CarePackage
            {
                Id = Guid.NewGuid(),
                SupplierId = 1
            };

            _gatewayMock = new Mock<ICarePackageGateway>();
            _dbManagerMock = new Mock<IDatabaseManager>();

            _gatewayMock
                .Setup(mock => mock.GetPackageAsync(_package.Id, PackageFields.None))
                .ReturnsAsync(_package);

            _useCase = new SubmitCarePackageUseCase(_gatewayMock.Object, _dbManagerMock.Object);
        }

        [Fact]
        public async Task ShouldUpdatePackageStatus()
        {
            var submissionInfo = new CarePackageSubmissionDomain
            {
                ApproverId = UserConstants.DefaultApiUserGuid,
                Notes = "Hello world"
            };

            await _useCase.ExecuteAsync(_package.Id, submissionInfo);

            _package.Status.Should().Be(PackageStatus.SubmittedForApproval);
            _package.ApproverId.Should().Be(submissionInfo.ApproverId);

            _package.Histories.Should().ContainSingle(h =>
                h.Description == submissionInfo.Notes &&
                h.Status == HistoryStatus.SubmittedForApproval);

            _dbManagerMock.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ShouldFailOnMissingPackage()
        {
            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(Guid.NewGuid(), It.IsAny<CarePackageSubmissionDomain>()))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status404NotFound);

            _dbManagerMock.Verify(mock => mock.SaveAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void ShouldFailOnMissingSupplier()
        {
            _package.SupplierId = null;

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_package.Id, It.IsAny<CarePackageSubmissionDomain>()))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status500InternalServerError);

            _dbManagerMock.Verify(mock => mock.SaveAsync(It.IsAny<string>()), Times.Never);
        }
    }
}
