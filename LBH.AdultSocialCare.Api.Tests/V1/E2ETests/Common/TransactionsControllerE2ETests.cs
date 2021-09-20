using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
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
            var nursingCarePackages = await CreateNursingCarePackages().ConfigureAwait(false);
            var residentialCarePackages = await CreateResidentialCarePackages().ConfigureAwait(false);

            var request = new PayRunForCreationRequest();
            var invoices = new List<InvoiceForCreationRequest>();

            _fixture.TransactionalApi.SetupPostRequestInterceptor<IEnumerable<InvoiceResponse>>(
                "api/v1/invoices/batch",
                req => invoices.AddRange((IEnumerable<InvoiceForCreationRequest>) req));

            var response = await _fixture.RestClient
                .PostAsync<Guid?>("api/v1/transactions/pay-runs/ResidentialRecurring", request)
                .ConfigureAwait(false);

            invoices.Count.Should().BePositive();
            invoices.Count.Should().Be(nursingCarePackages.Count + residentialCarePackages.Count);

            response.Message.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        private async Task<List<NursingCarePackage>> CreateNursingCarePackages()
        {
            var nursingCarePackages = await _fixture.DataGenerator.NursingCare.GetPackages(10).ConfigureAwait(false);

            foreach (var package in nursingCarePackages)
            {
                var additionalNeeds = await _fixture.DataGenerator.NursingCare.GetAdditionalNeeds(package.Id).ConfigureAwait(false);
                var brokerage = await _fixture.DataGenerator.NursingCare.GetBrokerageInfo(package.Id).ConfigureAwait(false);
                var careCharge = await _fixture.DataGenerator.CareCharge.GetCareCharge(PackageTypesConstants.NursingCarePackageId, package.Id).ConfigureAwait(false);

                await _fixture.DataGenerator.NursingCare.GetAdditionalNeedsCost(brokerage.NursingCareBrokerageId, additionalNeeds.Id, 1).ConfigureAwait(false);
                await _fixture.DataGenerator.CareCharge.GetElements(careCharge.Id, 5).ConfigureAwait(false);
            }

            return nursingCarePackages;
        }

        private async Task<List<ResidentialCarePackage>> CreateResidentialCarePackages()
        {
            var residentialCarePackages = await _fixture.DataGenerator.ResidentialCare.GetPackages(10).ConfigureAwait(false);

            foreach (var package in residentialCarePackages)
            {
                var additionalNeeds = await _fixture.DataGenerator.ResidentialCare.GetAdditionalNeeds(package.Id).ConfigureAwait(false);
                var brokerage = await _fixture.DataGenerator.ResidentialCare.GetBrokerageInfo(package.Id).ConfigureAwait(false);
                var careCharge = await _fixture.DataGenerator.CareCharge.GetCareCharge(PackageTypesConstants.NursingCarePackageId, package.Id).ConfigureAwait(false);

                await _fixture.DataGenerator.ResidentialCare.GetAdditionalNeedsCost(brokerage.Id, additionalNeeds.Id, 1).ConfigureAwait(false);
                await _fixture.DataGenerator.CareCharge.GetElements(careCharge.Id, 5).ConfigureAwait(false);
            }

            return residentialCarePackages;
        }
    }
}
