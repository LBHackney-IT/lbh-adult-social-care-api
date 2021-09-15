using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using HttpServices.Models.Requests;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.Common
{
    public class TransactionsControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;

        public TransactionsControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldCreatePayRun()
        {
            await CreateNursingCarePackages().ConfigureAwait(false);
            await CreateResidentialCarePackages().ConfigureAwait(false);

            var request = new PayRunForCreationRequest
            {
                DateTo = DateTimeOffset.Now
            };

            var response = await _fixture.RestClient
                .PostAsync<Guid?>("api/v1/transactions/pay-runs/ResidentialRecurring", request)
                .ConfigureAwait(false);

            // _fixture.TransactionalApi
            //     .Setup(api => api.PostAsync<Guid?>(
            //         It.IsAny<string>(),
            //         It.IsAny<PayRunForCreationRequest>(),
            //         It.IsAny<string>())).Callback(() => Console.Beep());

            // TODO: VK: Add checks
            response.Message.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        private async Task CreateNursingCarePackages()
        {
            var nursingCarePackages = await _fixture.DataGenerator.NursingCare.GetPackages(10).ConfigureAwait(false);

            foreach (var package in nursingCarePackages)
            {
                var brokerage = await _fixture.DataGenerator.NursingCare.GetBrokerageInfo(package.Id).ConfigureAwait(false);
                await _fixture.DataGenerator.NursingCare.GetAdditionalNeedsCost(brokerage.NursingCareBrokerageId, 1).ConfigureAwait(false);
            }
        }

        private async Task CreateResidentialCarePackages()
        {
            var residentialCarePackages = await _fixture.DataGenerator.ResidentialCare.GetPackages(10).ConfigureAwait(false);

            foreach (var package in residentialCarePackages)
            {
                var brokerage = await _fixture.DataGenerator.ResidentialCare.GetBrokerageInfo(package.Id).ConfigureAwait(false);
                await _fixture.DataGenerator.ResidentialCare.GetAdditionalNeedsCost(brokerage.Id, 1).ConfigureAwait(false);
            }
        }
    }
}
