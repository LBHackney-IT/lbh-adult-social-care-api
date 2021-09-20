using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.NursingCare
{
    public class NursingCareApproverPackageControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;

        public NursingCareApproverPackageControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldGetNursingCareApproverPackageContent()
        {
            var package = await _fixture.DataGenerator.NursingCare.GetPackage().ConfigureAwait(false);
            var additionalNeeds = await _fixture.DataGenerator.NursingCare.GetAdditionalNeeds(package.Id).ConfigureAwait(false);
            var brokerage = await _fixture.DataGenerator.NursingCare.GetBrokerageInfo(package.Id).ConfigureAwait(false);

            var costs = await GenerateAdditionalNeedsCosts(brokerage.NursingCareBrokerageId,
                additionalNeeds.Id,
                AdditionalNeedPaymentTypesConstants.WeeklyCost, AdditionalNeedPaymentTypesConstants.WeeklyCost,
                AdditionalNeedPaymentTypesConstants.OneOff, AdditionalNeedPaymentTypesConstants.OneOff)
                .ConfigureAwait(false);

            var response = await _fixture.RestClient
                .GetAsync<NursingCareApprovePackageResponse>($"api/v1/nursing-care-packages/{package.Id}/approve-package-contents")
                .ConfigureAwait(false);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            var costOneOff = Math.Round(costs
                .Where(c => c.AdditionalNeedsPaymentTypeId == AdditionalNeedPaymentTypesConstants.OneOff)
                .Average(c => c.AdditionalNeedsCost), 2);
            var costOfAdditionalNeeds = Math.Round(costs
                .Where(c => c.AdditionalNeedsPaymentTypeId == AdditionalNeedPaymentTypesConstants.WeeklyCost)
                .Average(c => c.AdditionalNeedsCost), 2);

            response.Content.CostOfCare.Should().Be(brokerage.NursingCore);
            //response.Content.CostOfOneOff.Should().Be(costOneOff);
            //response.Content.CostOfAdditionalNeeds.Should().Be(costOfAdditionalNeeds);
            //response.Content.TotalPerWeek.Should().Be(brokerage.NursingCore + costOfAdditionalNeeds);
        }

        [Fact]
        public async Task ShouldApprovePackage()
        {
            var package = await _fixture.DataGenerator.NursingCare.GetPackage().ConfigureAwait(false);

            var response = await _fixture.RestClient
                .PutAsync<NursingCarePackageResponse>($"api/v1/nursing-care-packages/{package.Id}/approve-package-contents")
                .ConfigureAwait(false);

            var updatedPackage = await _fixture.DatabaseContext.NursingCarePackages
                .Where(p => p.Id == package.Id)
                .FirstAsync()
                .ConfigureAwait(false);

            var approvalHistory = await _fixture.DatabaseContext.NursingCareApprovalHistories
                .Where(h => h.NursingCarePackageId == package.Id)
                .FirstAsync()
                .ConfigureAwait(false);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            updatedPackage.StatusId.Should().Be(ApprovalHistoryConstants.PackageApprovedId);
            approvalHistory.StatusId.Should().Be(ApprovalHistoryConstants.PackageApprovedId);
        }

        private async Task<List<NursingCareAdditionalNeedsCost>> GenerateAdditionalNeedsCosts(Guid brokerageId,Guid additionalNeedsId, params int[] types)
        {
            var result = new List<NursingCareAdditionalNeedsCost>();

            foreach (var costType in types)
            {
                result.Add(await _fixture.DataGenerator.NursingCare
                    .GetAdditionalNeedsCost(brokerageId, additionalNeedsId, costType)
                    .ConfigureAwait(false));

            }

            return result;
        }
    }
}
