using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.CarePackage
{
    public class CarePackageBrokerageControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;

        public CarePackageBrokerageControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldBrokerPackage()
        {
            var package = await _fixture.DataGenerator.CarePackages.CreatePackage(PackageType.ResidentialCare);

            const decimal coreCost = 12.34m;
            const decimal additionalOneOffCost = 34.56m;
            const decimal additionalWeeklyCost = 56.78m;

            var request = new CarePackageBrokerageRequest
            {
                Details = new List<CarePackageDetailRequest>
                {
                    new CarePackageDetailRequest
                    {
                        Type = PackageDetailType.CoreCost,
                        Cost = coreCost,
                        StartDate = DateTimeOffset.Now.AddDays(-100),
                        ServiceUserNeeds = "Need 1"
                    },
                    new CarePackageDetailRequest
                    {
                        Type = PackageDetailType.AdditionalNeedOneOff,
                        Cost = additionalOneOffCost,
                        StartDate = DateTimeOffset.Now.AddDays(-100),
                        ServiceUserNeeds = "Need 2"
                    },
                    new CarePackageDetailRequest
                    {
                        Type = PackageDetailType.AdditionalNeedWeekly,
                        Cost = additionalWeeklyCost,
                        StartDate = DateTimeOffset.Now.AddDays(-100),
                        EndDate = DateTimeOffset.Now.AddDays(100),
                        ServiceUserNeeds = "Need 3"
                    }
                }
            };

            var response = await _fixture.RestClient
                .PostAsync<object>($"api/v1/care-packages/{package.Id}/details", request)
                .ConfigureAwait(false);

            var packageDetails = _fixture.DatabaseContext.CarePackageDetails.ToList();

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            packageDetails.Count.Should().Be(request.Details.Count);
            packageDetails.Should().ContainSingle(d => d.Type == PackageDetailType.CoreCost && d.Cost == coreCost);
            packageDetails.Should().ContainSingle(d => d.Type == PackageDetailType.AdditionalNeedOneOff && d.Cost == additionalOneOffCost);
            packageDetails.Should().ContainSingle(d => d.Type == PackageDetailType.AdditionalNeedWeekly && d.Cost == additionalWeeklyCost);
        }
    }
}
