using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.NursingCare
{
    public class NursingCarePackageReclaimControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;

        public NursingCarePackageReclaimControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldCreateNursingPackageReclaim()
        {
            var package = await _fixture.Generator.NursingCare.CreatePackage().ConfigureAwait(false);

            var request = new NursingCarePackageClaimCreationRequest
            {
                NursingCarePackageId = package.Id,
                Amount = 123.5m,
                Notes = "Hello world",
                ReclaimCategoryId = 1,
                ReclaimFromId = 1,
                ReclaimAmountOptionId = 1
            };

            var response = await _fixture.RestClient
                .PostAsync<NursingCarePackageClaimResponse>($"api/v1/nursing-care-packages/{package.Id}/package-reclaim", request)
                .ConfigureAwait(false);

            var reclaim = await _fixture.DatabaseContext.NursingCarePackageReclaims
                .Where(r => r.NursingCarePackageId == package.Id)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            reclaim.Should().BeEquivalentTo(request);
        }
    }
}
