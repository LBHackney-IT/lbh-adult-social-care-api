using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
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
            var nursingCarePackages = CreatePackages(PackageType.NursingCare);
            var residentialCarePackages = CreatePackages(PackageType.ResidentialCare);

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

        private List<CarePackage> CreatePackages(PackageType type)
        {
            var packages = 5.ItemsOf(() => _fixture.Generator.CreateCarePackage(type)).ToList();

            foreach (var package in packages)
            {
                _fixture.Generator.CreateCarePackageDetails(package, 1, PackageDetailType.CoreCost);
                _fixture.Generator.CreateCarePackageDetails(package, 2, PackageDetailType.AdditionalNeed);
                _fixture.Generator.CreateCarePackageReclaim(package, ReclaimType.CareCharge, ClaimCollector.Hackney);
            }

            return packages;
        }
    }
}
