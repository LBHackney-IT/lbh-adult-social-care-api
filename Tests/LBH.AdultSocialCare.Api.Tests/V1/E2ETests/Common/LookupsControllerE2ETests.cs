using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Data.Constants.Enums;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.Common
{
    public class LookupsControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;

        public LookupsControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldReturnValidLookup()
        {
            var response = await _fixture.RestClient
                .GetAsync<IEnumerable<LookupItemResponse>>($"api/v1/lookups?name={nameof(PackageType)}");

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeEmpty();
        }

        [Fact]
        public async Task ShouldNotReturnNonLookupEnum()
        {
            var response = await _fixture.RestClient
                .GetAsync<object>($"api/v1/lookups?name={nameof(PackageFields)}");

            response.Message.StatusCode.Should().Be(HttpStatusCode.NotFound);
            response.Content.Should().NotBeAssignableTo<IEnumerable<LookupItemResponse>>();
        }

        [Fact]
        public async Task ShouldNotReturnNonExistentLookup()
        {
            var response = await _fixture.RestClient
                .GetAsync<object>("api/v1/lookups?name=bcz0l8wAQmb3VvCEWBF0");

            response.Message.StatusCode.Should().Be(HttpStatusCode.NotFound);
            response.Content.Should().NotBeAssignableTo<IEnumerable<LookupItemResponse>>();
        }
    }
}
