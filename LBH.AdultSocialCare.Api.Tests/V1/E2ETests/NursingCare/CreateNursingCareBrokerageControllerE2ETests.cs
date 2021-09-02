using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.NursingCare
{
    public class CreateNursingCareBrokerageControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;

        public CreateNursingCareBrokerageControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldCreateBrokerageInfo()
        {
            var package = await _fixture.DataGenerator.GenerateNursingCarePackage().ConfigureAwait(false);

            var request = new NursingCareBrokerageCreationRequest
            {
                StartDate = DateTimeOffset.Now,
                EndDate = DateTimeOffset.Now.AddDays(30),
                SupplierId = 1,
                StageId = 1,
                NursingCarePackageId = package.Id,
                FundedNursingCareCollectorId = 1,
                NursingCore = 123.45m
            };

            var response = await _fixture.RestClient
                .PostAsync<NursingCareBrokerageInfoResponse>($"api/v1/nursing-care-packages/{package.Id}/brokerage", request)
                .ConfigureAwait(false);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.NursingCarePackageId.Should().Be(package.Id);
            response.Content.NursingCareBrokerageId.Should().NotBeEmpty();
        }
    }
}
