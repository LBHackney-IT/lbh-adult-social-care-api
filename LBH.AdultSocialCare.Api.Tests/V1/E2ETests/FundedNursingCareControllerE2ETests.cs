using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HttpServices.Services.Concrete;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests
{
    public class FundedNursingCareControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;

        public FundedNursingCareControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Test()
        {
            var collector1 = new FundedNursingCareCollector { OptionName = "Hackney" };
            var collector2 = new FundedNursingCareCollector { OptionName = "Supplier" };

            _fixture.Database.FundedNursingCareCollectors.AddRange(collector1, collector2);
            _fixture.Database.SaveChanges();

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
