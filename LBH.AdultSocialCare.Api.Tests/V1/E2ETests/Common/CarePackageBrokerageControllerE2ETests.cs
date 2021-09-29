using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.DataGenerators;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.Common
{
    public class CarePackageBrokerageControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;
        private readonly CarePackageGenerator _generator;

        public CarePackageBrokerageControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
            _generator = _fixture.DataGenerator.CarePackages;
        }

        [Fact]
        public async Task ShouldReturnPackageBrokerageInfo()
        {
            var package = await _generator.CreatePackage(PackageType.NursingCare);

            var coreCost = (await _generator.CreatePackageDetails(package, 1, PackageDetailType.CoreCost)).First();
            var details = await _generator.CreatePackageDetails(package, 3, PackageDetailType.AdditionalNeed);

            var response = await _fixture.RestClient
                .GetAsync<CarePackageBrokerageResponse>($"api/v1/care-packages/{package.Id}/details");

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            response.Content.CoreCost.Should().Be(coreCost.Cost);
            response.Content.StartDate.Should().Be(coreCost.StartDate);
            response.Content.EndDate.Should().Be(coreCost.EndDate);
            response.Content.SupplierId.Should().Be(package.SupplierId);
            response.Content.Details.Should().BeEquivalentTo(details, opt => opt.ExcludingMissingMembers());
        }

        [Fact]
        public async Task ShouldUpdateCarePackageDetails()
        {
            var package = await _generator.CreatePackage(PackageType.NursingCare);
            var details = await _generator.CreatePackageDetails(package, 5, PackageDetailType.AdditionalNeed);

            var request = new CarePackageBrokerageCreationRequest
            {
                CoreCost = 123.45m,
                StartDate = DateTimeOffset.Now.Date.AddDays(-100),
                SupplierId = 2,
                Details = details.ToRequest().ToList()
            };

            // Imitate remove, create and update at once
            request.Details.RemoveAt(1);
            request.Details.RemoveAt(2);
            request.Details.Add(TestDataHelper.CreateCarePackageDetailDomainList(1, PackageDetailType.AdditionalNeed).First().ToRequest());

            foreach (var detail in request.Details)
            {
                detail.Cost += 1.0m;
                detail.StartDate = detail.StartDate?.AddDays(-100) ?? DateTimeOffset.Now.Date.AddDays(-100);
                detail.EndDate = detail.EndDate?.AddDays(-100) ?? DateTimeOffset.Now.Date.AddDays(-100);
            }

            var response = await _fixture.RestClient
                .PutAsync<object>($"api/v1/care-packages/{package.Id}/details", request);

            package = await _fixture.DatabaseContext.CarePackages
                .Include(p => p.Details)
                .FirstAsync(p => p.Id == package.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            VerifyPackageDetails(package, request);
        }

        private static void VerifyPackageDetails(CarePackage package, CarePackageBrokerageCreationRequest request)
        {
            package.SupplierId.Should().Be(request.SupplierId);
            package.Details.Count.Should().Be(request.Details.Count + 1); // +1 for core cost detail

            var coreCostDetail = package.Details.FirstOrDefault(d => d.Type is PackageDetailType.CoreCost);

            coreCostDetail.Should().NotBeNull();
            coreCostDetail?.Cost.Should().Be(request.CoreCost);
            coreCostDetail?.CostPeriod.Should().Be(PaymentPeriod.Weekly);
            coreCostDetail?.StartDate.Should().Be(request.StartDate.Value);
            coreCostDetail?.EndDate.Should().Be(request.EndDate);

            foreach (var requestedDetail in request.Details)
            {
                package.Details.Should().ContainEquivalentOf(requestedDetail, opt => opt.Excluding(d => d.Id));
            }
        }
    }
}
