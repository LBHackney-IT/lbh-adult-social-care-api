using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.Tests.V1.DataGenerators;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Entities.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using HttpServices.Helpers;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;
using Xunit;
using Xunit.Abstractions;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.Payments
{
    public class PayRunsControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;
        private readonly ITestOutputHelper _output;
        private readonly DatabaseTestDataGenerator _generator;

        private readonly DateTimeOffset _periodFrom = DateTimeOffset.UtcNow.AddDays(-7);
        private readonly DateTimeOffset _periodTo = DateTimeOffset.UtcNow;

        private readonly Payrun _payrun;

        public PayRunsControllerE2ETests(MockWebApplicationFactory fixture, ITestOutputHelper output)
        {
            _fixture = fixture;
            _output = output;
            _generator = _fixture.Generator;
            _payrun = CreateFullPayRun();
        }

        [Fact]
        public async Task ShouldGetPayRunDetails()
        {
            _output.WriteLine(_payrun.Id.ToString());
            var parameters = new PayRunDetailsQueryParameters
            {
                PageNumber = 1,
                PageSize = 10
            };
            var url = new UrlFormatter()
                .SetBaseUrl($"api/v1/payruns/{_payrun.Id}")
                .AddParameter("pageNumber", parameters.PageNumber)
                .AddParameter("pageSize", parameters.PageSize)
                .ToString();

            var response = await _fixture.RestClient
                .GetAsync<PayRunDetailsViewResponse>(url);

            Assert.NotNull(response);
            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            _output.WriteLine(_fixture.DatabaseContext.Payruns.Count().ToString());
        }

        [Fact]
        public void SampleTest()
        {
            _output.WriteLine(_payrun.Id.ToString());
            _output.WriteLine(_fixture.DatabaseContext.Payruns.Count().ToString());
        }

        private Payrun CreateFullPayRun()
        {
            var packages = CreateCarePackages();
            var invoices = CreateInvoices(packages);

            // Create pay run with 10 items
            var payRun = TestDataHelper.CreatePayRun(type: PayrunType.ResidentialRecurring,
                status: PayrunStatus.Approved, startDate: _periodFrom, endDate: _periodTo, paidUpToDate: _periodTo);
            payRun.PayrunInvoices = CreatePayRunInvoices(payRun, invoices);
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

        private static IList<PayrunInvoice> CreatePayRunInvoices(Payrun payrun, IList<Invoice> invoices)
        {
            return invoices.Select(invoice => TestDataHelper.CreatePayrunInvoice(payrun.Id, invoice)).ToList();
        }

        private IList<CarePackage> CreateCarePackages()
        {
            // Create 10 service users
            var serviceUsers = _generator.CreateServiceUsers(10.ItemsOf(TestDataHelper.CreateServiceUser));

            // Create 10 suppliers
            var suppliers = _generator.CreateSuppliers(10.ItemsOf(TestDataHelper.CreateSupplier));

            // Create a package for each service user
            var carePackages = Enumerable.Range(1, 10).ToArray().Select(item => CreateSinglePackage(PackageType.ResidentialCare, PackageStatus.Approved, serviceUsers[item - 1], suppliers[item - 1])).ToList();

            return _generator.CreateCarePackages(carePackages);
        }

        private static CarePackage CreateSinglePackage(PackageType type, PackageStatus status, ServiceUser client, Supplier supplier)
        {
            return TestDataHelper.CreateCarePackage(type, status, client.Id, supplier.Id);
        }
    }
}
