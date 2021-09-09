using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.Common
{
    public class CareChargeControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;

        public CareChargeControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldCreateNewCareChargeElement()
        {
            var startDate = DateTimeOffset.Now.AddDays(-20);
            var endDate = startDate.AddDays(30);

            var careCharge = await _fixture.DataGenerator.CareCharge.GetCareCharge().ConfigureAwait(false);

            var request = new CareChargeElementCreationRequest
            {
                StartDate = startDate,
                EndDate = endDate,
                TypeId = CareChargeTypeConstants.WithoutProperty13WeeksPlus,
                CareChargeId = careCharge.Id,
                ClaimCollectorId = PackageCostClaimersConstants.Hackney
            };

            var response = await _fixture.RestClient
                .PostAsync<CareChargeElementCreationResponse>("api/v1/care-charges/elements", request)
                .ConfigureAwait(false);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().BeEquivalentTo(request, opt => opt.Excluding(e => e.StatusId));
            response.Content.StatusId.Should().Be(CareChargeStatusConstants.Active);
        }
    }
}
