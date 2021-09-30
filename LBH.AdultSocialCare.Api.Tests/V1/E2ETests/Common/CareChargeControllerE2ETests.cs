using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
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
            var careCharge = await _fixture.Generator.CareCharge
                .GetCareCharge(PackageTypesConstants.NursingCarePackageId, Guid.NewGuid())
                .ConfigureAwait(false);

            var request = RandomizeElementCreationRequests(careCharge.Id, 1).First();
            var response = await _fixture.RestClient
                .PostAsync<CareChargeElementCreationResponse>("api/v1/care-charges/elements", request)
                .ConfigureAwait(false);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().BeEquivalentTo(request, opt => opt.Excluding(e => e.StatusId));

            response.Content.Id.Should().NotBe(Guid.Empty);
            response.Content.StatusId.Should().Be((int) ReclaimStatus.Active);
        }

        [Fact]
        public async Task ShouldAddFinancialAssessment()
        {
            var careCharge = await _fixture.Generator.CareCharge
                .GetCareCharge(PackageTypesConstants.NursingCarePackageId, Guid.Empty)
                .ConfigureAwait(false);

            var request = RandomizeElementCreationRequests(careCharge.Id, 5);
            var response = await _fixture.RestClient
                .PostAsync<IEnumerable<CareChargeElementCreationResponse>>("api/v1/care-charges/financial-assessment", request)
                .ConfigureAwait(false);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            foreach (var requestElement in request)
            {
                response.Content.Should().Contain(e => e.StartDate == requestElement.StartDate);
                response.Content.Should().Contain(e => e.EndDate == requestElement.EndDate);
                response.Content.Should().Contain(e => e.TypeId == requestElement.TypeId);
                response.Content.Should().Contain(e => e.ClaimCollectorId == requestElement.ClaimCollectorId);
            }

            response.Content.Should().OnlyContain(e => e.StatusId == (int) ReclaimStatus.Active);
            response.Content.Should().OnlyContain(e => e.Id != Guid.Empty);
        }

        private static List<CareChargeElementCreationRequest> RandomizeElementCreationRequests(Guid careChargeId, int requestsCount)
        {
            return new Faker<CareChargeElementCreationRequest>()
                .RuleFor(e => e.CareChargeId, careChargeId)
                .RuleFor(e => e.StartDate, f => f.Date.Past())
                .RuleFor(e => e.EndDate, f => f.Date.Future())
                .RuleFor(e => e.TypeId, f => (int) f.PickRandom<CareChargeElementTypeEnum>())
                .RuleFor(e => e.ClaimCollectorId, f => f.PickRandom(PackageCostClaimersConstants.Hackney, PackageCostClaimersConstants.Supplier))
                .Generate(requestsCount);
        }
    }
}
