using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using Microsoft.EntityFrameworkCore;
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

        [Fact]
        public async Task ShouldGetNursingCareBrokerage()
        {
            var package = await _fixture.DataGenerator.GenerateNursingCarePackage().ConfigureAwait(false);
            var brokerage = await _fixture.DataGenerator.GenerateNursingCareBrokerageInfo(package.Id).ConfigureAwait(false);

            var response = await _fixture.RestClient
                .GetAsync<NursingCareBrokerageInfoResponse>($"api/v1/nursing-care-packages/{package.Id}/brokerage")
                .ConfigureAwait(false);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.NursingCarePackageId.Should().Be(package.Id);
            response.Content.NursingCareBrokerageId.Should().Be(brokerage.NursingCareBrokerageId);
        }

        [Fact]
        public async Task ShouldApprovePackage()
        {
            var moreInformationTest = "someLongText";
            var package = await _fixture.DataGenerator.GenerateNursingCarePackage().ConfigureAwait(false);

            var response = await _fixture.RestClient
                .PostAsync<NursingCarePackageResponse>($"api/v1/nursing-care-packages/{package.Id}/brokerage/clarifying-commercials?requestMoreInformationText={moreInformationTest}", package.Id)
                .ConfigureAwait(false);

            var updatedPackage = await _fixture.Database.NursingCarePackages
                .Where(p => p.Id == package.Id)
                .FirstAsync()
                .ConfigureAwait(false);

            var approvalHistory = await _fixture.Database.NursingCareApprovalHistories
                .Where(h => h.NursingCarePackageId == package.Id)
                .FirstAsync()
                .ConfigureAwait(false);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            updatedPackage.StatusId.Should().Be(ApprovalHistoryConstants.ClarifyingCommercialsId);
            approvalHistory.LogSubText.Should().Be(moreInformationTest);
        }

        [Fact]
        public async Task ShouldSetStageToPackage()
        {
            var package = await _fixture.DataGenerator.GenerateNursingCarePackage().ConfigureAwait(false);
            var newStageId = package.StageId + 1;

            var response = await _fixture.RestClient
                .PutAsync<bool>($"api/v1/nursing-care-packages/{package.Id}/brokerage/stage/{newStageId}", package.Id)
                .ConfigureAwait(false);

            var updatedPackage = await _fixture.Database.NursingCarePackages
                .Where(p => p.Id == package.Id)
                .FirstAsync()
                .ConfigureAwait(false);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            updatedPackage.StageId.Should().Be(newStageId);
        }
    }
}
