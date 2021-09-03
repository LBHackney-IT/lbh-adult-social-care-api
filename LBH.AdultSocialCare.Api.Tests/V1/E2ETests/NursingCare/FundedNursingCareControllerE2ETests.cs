using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.NursingCare
{
    public class FundedNursingCareControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;

        public FundedNursingCareControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldReturnCollectorsList()
        {
            var collector1 = new FundedNursingCareCollector { OptionName = "Hackney", ClaimedBy = PackageCostClaimersConstants.Hackney };
            var collector2 = new FundedNursingCareCollector { OptionName = "Supplier", ClaimedBy = PackageCostClaimersConstants.Supplier };

            _fixture.DatabaseContext.FundedNursingCareCollectors.ClearData();
            _fixture.DatabaseContext.FundedNursingCareCollectors.AddRange(collector1, collector2);
            _fixture.DatabaseContext.SaveChanges();

            var response = await _fixture.RestClient
                .GetAsync<IEnumerable<FundedNursingCareCollectorResponse>>("api/v1/funded-nursing-care/collectors")
                .ConfigureAwait(false);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            response.Content.Count().Should().Be(2);
            response.Content.Should().ContainSingle(c => c.OptionName == collector1.OptionName);
            response.Content.Should().ContainSingle(c => c.OptionName == collector2.OptionName);
        }
    }
}
