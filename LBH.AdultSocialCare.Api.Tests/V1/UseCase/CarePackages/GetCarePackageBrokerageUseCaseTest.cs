using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class GetCarePackageBrokerageUseCaseTest : BaseTest
    {
        private readonly Mock<ICarePackageGateway> _gatewayMock;
        private readonly GetCarePackageBrokerageUseCase _useCase;
        private readonly CarePackage _package;

        public GetCarePackageBrokerageUseCaseTest()
        {
            _package = new CarePackage
            {
                Id = Guid.NewGuid(),
                Details =
                    TestDataHelper.CreateCarePackageDetails(1, PackageDetailType.CoreCost).Concat(
                    TestDataHelper.CreateCarePackageDetails(3, PackageDetailType.AdditionalNeed)).ToList()
            };

            _gatewayMock = new Mock<ICarePackageGateway>();
            _gatewayMock
                .Setup(mock => mock.GetPackageAsync(_package.Id, PackageFields.Details, false))
                .ReturnsAsync(_package);

            _useCase = new GetCarePackageBrokerageUseCase(_gatewayMock.Object);
        }

        [Fact]
        public async Task ShouldReturnPackageBrokerage()
        {
            var result = await _useCase.ExecuteAsync(_package.Id);

            VerifyPackageDetails(result);
        }

        [Fact]
        public void ShouldFailOnUnknownPackage()
        {
            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(Guid.NewGuid()))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status404NotFound);
        }

        [Fact]
        public void ShouldFailOnMissedCoreCost()
        {
            _package.Details.Remove(_package.Details.First(d => d.Type is PackageDetailType.CoreCost));

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_package.Id))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status204NoContent);
        }

        private void VerifyPackageDetails(CarePackageBrokerageDomain brokerageInfo)
        {
            _package.Details.Count.Should().Be(brokerageInfo.Details.Count + 1); // +1 for core cost detail

            var coreCostDetail = _package.Details.FirstOrDefault(d => d.Type is PackageDetailType.CoreCost);

            coreCostDetail.Should().NotBeNull();
            coreCostDetail?.Cost.Should().Be(brokerageInfo.CoreCost);
            coreCostDetail?.CostPeriod.Should().Be(PaymentPeriod.Weekly);
            coreCostDetail?.StartDate.Should().Be(brokerageInfo.StartDate);
            coreCostDetail?.EndDate.Should().Be(brokerageInfo.EndDate);

            foreach (var requestedDetail in brokerageInfo.Details)
            {
                _package.Details.Should().ContainEquivalentOf(requestedDetail, opt => opt.Excluding(d => d.Id));
            }
        }
    }
}
