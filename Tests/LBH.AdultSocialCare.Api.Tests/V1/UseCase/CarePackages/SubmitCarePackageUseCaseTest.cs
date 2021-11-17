using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.Constants;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
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
                Status = PackageStatus.New,
                SupplierId = 1
            };

            _gatewayMock = new Mock<ICarePackageGateway>();
            _dbManagerMock = new Mock<IDatabaseManager>();

            _gatewayMock
                .Setup(mock => mock.GetPackageAsync(_package.Id, PackageFields.None, true))
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
                h.RequestMoreInformation == submissionInfo.Notes &&
                h.Description == HistoryStatus.SubmittedForApproval.GetDisplayName() &&
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

        [Theory]
        [InlineData(PackageStatus.New)]
        [InlineData(PackageStatus.InProgress)]
        public void ShouldAllowSubmissionOfNonSubmittedPackages(PackageStatus packageStatus)
        {
            _package.Status = packageStatus;

            var submissionInfo = new CarePackageSubmissionDomain
            {
                ApproverId = UserConstants.DefaultApiUserGuid,
                Notes = "Hello world"
            };

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_package.Id, submissionInfo))
                .Should().NotThrow();

            _dbManagerMock.Verify(mock => mock.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ShouldFailOnSecondarySubmission()
        {
            var statuses = Enum
                .GetValues(typeof(PackageStatus))
                .Cast<PackageStatus>()
                .Where(s => s.NotIn(PackageStatus.New, PackageStatus.InProgress));

            foreach (var packageStatus in statuses)
            {
                _package.Status = packageStatus;

                _useCase
                    .Invoking(useCase => useCase.ExecuteAsync(_package.Id, It.IsAny<CarePackageSubmissionDomain>()))
                    .Should().Throw<ApiException>()
                    .Where(ex => ex.StatusCode == StatusCodes.Status500InternalServerError);

                _dbManagerMock.Verify(mock => mock.SaveAsync(It.IsAny<string>()), Times.Never);
            }
        }
    }
}
