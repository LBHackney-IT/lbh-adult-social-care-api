using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Extensions;
using FluentAssertions;
using HttpServices.Helpers;
using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.Tests.V1.DataGenerators;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.Payments
{
    public class PayRunsControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;
        private readonly DatabaseTestDataGenerator _generator;

        private readonly DateTimeOffset _periodFrom = DateTimeOffset.UtcNow.AddDays(-7).Date;
        private readonly DateTimeOffset _periodTo = DateTimeOffset.UtcNow.Date;

        public PayRunsControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
            _generator = _fixture.Generator;
        }

        [Fact]
        public async Task ShouldGetPayRunDetails()
        {
            var payrun = CreateFullPayRun();
            var parameters = new PayRunDetailsQueryParameters { PageNumber = 1, PageSize = 10 };
            var url = new UrlFormatter()
                .SetBaseUrl($"api/v1/payruns/{payrun.Id}")
                .AddParameter("pageNumber", parameters.PageNumber)
                .AddParameter("pageSize", parameters.PageSize)
                .ToString();

            var response = await _fixture.RestClient
                .GetAsync<PayRunDetailsViewResponse>(url);

            Assert.NotNull(response);
            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ShouldGetHeldInvoices()
        {
            var payRun = CreateFullPayRun(true);
            var parameters = new PayRunDetailsQueryParameters { PageNumber = 1, PageSize = 10 };
            var url = new UrlFormatter()
                .SetBaseUrl("api/v1/payruns/held-invoices")
                .AddParameter("pageNumber", parameters.PageNumber)
                .AddParameter("pageSize", parameters.PageSize)
                .ToString();
            var response = await _fixture.RestClient
                .GetAsync<PagedResponse<HeldInvoiceDetailsResponse>>(url);

            Assert.NotNull(response);
            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Data.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void ShouldGetPayRunList()
        {
        }

        [Fact]
        public void ShouldCreateDraftPayRun()
        {
        }

        [Fact]
        public async Task ShouldGetPayRunInsights()
        {
            var payRun = CreateFullPayRun(true);
            var url = new UrlFormatter()
                .SetBaseUrl($"api/v1/payruns/{payRun.Id}/insights")
                .ToString();
            var response = await _fixture.RestClient
                .GetAsync<PayRunInsightsResponse>(url);

            Assert.NotNull(response);
            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.HoldsCount.Should().Be(5);
            response.Content.ServiceUserCount.Should().Be(5);
            response.Content.SupplierCount.Should().Be(5);
            response.Content.TotalInvoiceAmount.Should().Be(50M);
            response.Content.TotalHeldAmount.Should().Be(50M);
            response.Content.PayRunStatus.Should().Be(payRun.Status);
            response.Content.TotalDifferenceFromLastCycle.Should().Be(50M);
        }

        [Fact]
        public async Task ShouldGetReleasedInvoiceCount()
        {
            var payRun = CreateFullPayRun(false, true);
            var url = new UrlFormatter()
                .SetBaseUrl($"api/v1/payruns/released-invoice-count")
                .ToString();
            var response = await _fixture.RestClient
                .GetAsync<int>(url);

            Assert.NotNull(response);
            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().Be(5);
        }

        [Fact]
        public async Task ShouldGetPreviousPayRunEndDate()
        {
            ClearDatabase();
            var payRun = TestDataHelper.CreatePayRun(PayrunType.ResidentialRecurring, PayrunStatus.Approved,
                startDate: _periodFrom, endDate: _periodTo, paidUpToDate:_periodTo);
            _generator.CreatePayRun(payRun);

            var url = new UrlFormatter()
                .SetBaseUrl($"api/v1/payruns/{payRun.Type}/previous-pay-run-end-date")
                .ToString();
            var response = await _fixture.RestClient
                .GetAsync<DateTimeOffset>(url);

            Assert.NotNull(response);
            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            Assert.Equal(payRun.EndDate, response.Content);
        }

        [Fact]
        public void ShouldGetPayRunInvoiceDetails()
        {
        }

        private void ClearDatabase()
        {
            _fixture.DatabaseContext.PayrunInvoices.ClearData();
            _fixture.DatabaseContext.InvoiceItems.ClearData();
            _fixture.DatabaseContext.Invoices.ClearData();
            _fixture.DatabaseContext.Payruns.ClearData();
            _fixture.DatabaseContext.CarePackages.ClearData();
            _fixture.DatabaseContext.Suppliers.ClearData();
            _fixture.DatabaseContext.ServiceUsers.ClearData();
            _fixture.DatabaseContext.SaveChanges();
        }

        private Payrun CreateFullPayRun(bool hasHeldInvoices = false, bool hasReleasedInvoices = false)
        {
            ClearDatabase();
            var packages = CreateCarePackages();
            var invoices = CreateInvoices(packages);

            // Create pay run with 10 items
            var payRun = TestDataHelper.CreatePayRun(PayrunType.ResidentialRecurring,
                PayrunStatus.Approved, startDate: _periodFrom, endDate: _periodTo, paidUpToDate: _periodTo);
            payRun.PayrunInvoices = CreatePayRunInvoices(payRun, invoices, hasHeldInvoices, hasReleasedInvoices);
            return _generator.CreatePayRun(payRun);
        }

        private IList<Invoice> CreateInvoices(IList<CarePackage> carePackages)
        {
            var invoices = new List<Invoice>();
            foreach (var carePackage in carePackages)
            {
                var invoice = TestDataHelper.CreateInvoice(carePackage, 10m, 10m, 10m);
                invoice.Items = 5.ItemsOf(() => TestDataHelper.CreateInvoiceItem(invoice, _periodFrom, _periodTo));
                invoices.Add(invoice);
            }

            return _generator.CreateInvoices(invoices);
        }

        private static IList<PayrunInvoice> CreatePayRunInvoices(Payrun payrun, IList<Invoice> invoices,
            bool hasHeldInvoices, bool hasReleasedInvoices)
        {
            if (!hasHeldInvoices && !hasReleasedInvoices)
                return invoices.Select(invoice => TestDataHelper.CreatePayrunInvoice(payrun.Id, invoice)).ToList();

            var payrunInvoices = new List<PayrunInvoice>();
            var half = invoices.Count / 2;
            if (hasHeldInvoices)
            {
                payrunInvoices.AddRange(invoices.GetPage(1, half).ToList()
                    .Select(invoice => TestDataHelper.CreatePayrunInvoice(payrun.Id, invoice, InvoiceStatus.Held)));
            }
            if (hasReleasedInvoices)
            {
                payrunInvoices.AddRange(invoices.GetPage(1, half).ToList()
                    .Select(invoice => TestDataHelper.CreatePayrunInvoice(payrun.Id, invoice, InvoiceStatus.Released)));
            }
            payrunInvoices.AddRange(invoices.GetPage(2, half).ToList()
                .Select(invoice => TestDataHelper.CreatePayrunInvoice(payrun.Id, invoice)));
            return payrunInvoices;
        }

        private IList<CarePackage> CreateCarePackages()
        {
            // Create 10 service users
            var serviceUsers = _generator.CreateServiceUsers(10.ItemsOf(TestDataHelper.CreateServiceUser));

            // Create 10 suppliers
            var suppliers = _generator.CreateSuppliers(10.ItemsOf(TestDataHelper.CreateSupplier));

            // Create a package for each service user
            var carePackages = Enumerable.Range(1, 10).ToArray().Select(item =>
                CreateSinglePackage(PackageType.ResidentialCare, PackageStatus.Approved, serviceUsers[item - 1],
                    suppliers[item - 1])).ToList();

            return _generator.CreateCarePackages(carePackages);
        }

        private static CarePackage CreateSinglePackage(PackageType type, PackageStatus status, ServiceUser client,
            Supplier supplier)
        {
            return TestDataHelper.CreateCarePackage(type, status, client.Id, supplier.Id);
        }
    }
}
