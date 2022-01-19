using AutoFixture;
using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;
using LBH.AdultSocialCare.TestFramework.Extensions;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Payments
{
    public class GetPackagePaymentHistoryUseCaseTests : BaseTest
    {
        private readonly Mock<ICarePackageGateway> _carePackageGateway;
        private readonly Mock<IPayRunInvoiceGateway> _payRunInvoiceGateway;
        private readonly Mock<IPayRunGateway> _payRunGateway;
        private readonly GetPackagePaymentHistoryUseCase _useCase;

        public GetPackagePaymentHistoryUseCaseTests()
        {
            _carePackageGateway = new Mock<ICarePackageGateway>();
            _payRunInvoiceGateway = new Mock<IPayRunInvoiceGateway>();
            _payRunGateway = new Mock<IPayRunGateway>();
            _useCase = new GetPackagePaymentHistoryUseCase(_carePackageGateway.Object, _payRunInvoiceGateway.Object,
                _payRunGateway.Object);
        }

        [Fact]
        public void ShouldRaiseExceptionIfPackageDoesNotExist()
        {
            _carePackageGateway
                .Setup(g => g.GetPackageAsync(It.IsAny<Guid>(), It.IsAny<PackageFields>(), It.IsAny<bool>()))
                .ReturnsAsync((CarePackage) null);
            _useCase
                .Invoking(useCase => useCase.GetAsync(Guid.NewGuid(), new RequestParameters()))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status404NotFound);

            _carePackageGateway.VerifyGetPackage(Times.Once());
            _carePackageGateway.VerifyNoOtherCalls();
        }

        [Fact]
        public async void ShouldGetAcceptedInvoicesForPackage()
        {
            var fixture = new Fixture();
            var package = TestDataHelper.CreateCarePackage();
            package.ServiceUser = TestDataHelper.CreateServiceUser();
            package.Supplier = TestDataHelper.CreateSupplier();
            var invoice = fixture.Build<Invoice>()
                .OmitAutoProperties()
                .With(i => i.PackageId, package.Id)
                .With(i => i.GrossTotal, 5m)
                .With(i => i.TotalCost, 5m)
                .With(i => i.NetTotal, 5m);
            var periodFrom = DateTimeOffset.UtcNow.Date.AddDays(-300);
            var periodTo = DateTimeOffset.UtcNow.Date;
            var payRun = TestDataHelper.CreatePayRun(type: PayrunType.ResidentialRecurring, startDate: periodFrom,
                paidUpToDate: periodTo, endDate: periodTo, status: PayrunStatus.Paid);

            var payRunInvoices = fixture.Build<PayrunInvoice>()
                .OmitAutoProperties()
                .With(pi => pi.Invoice, invoice.Create())
                .With(pi => pi.Payrun, payRun)
                .With(pi => pi.PayrunId, payRun.Id)
                .CreateMany(100).ToList();

            _carePackageGateway
                .Setup(g => g.GetPackageAsync(It.IsAny<Guid>(), It.IsAny<PackageFields>(), It.IsAny<bool>()))
                .ReturnsAsync(package);

            _payRunGateway
                .Setup(g => g.GetPackageLatestPayRunAsync(It.IsAny<Guid>(), It.IsAny<PayrunStatus[]>(),
                    It.IsAny<InvoiceStatus[]>())).ReturnsAsync(payRun);

            _payRunInvoiceGateway.Setup(g => g.GetPackageInvoicesAsync(It.IsAny<Guid>(), It.IsAny<PayrunStatus[]>(),
                    It.IsAny<InvoiceStatus[]>(), It.IsAny<PayRunInvoiceFields>(), It.IsAny<bool>()))
                .ReturnsAsync(payRunInvoices);

            var requestParams = new RequestParameters { PageNumber = 1, PageSize = 20 };

            var result = await _useCase.GetAsync(package.Id, requestParams);

            result.Payments.PagingMetaData.Should().BeEquivalentTo(requestParams, options => options.ExcludingMissingMembers());
            result.Payments.Data.Count().Should().Be(requestParams.PageSize);
            result.PackagePayment.DateTo.Should().Be(periodTo);
            result.PackagePayment.PackageId.Should().Be(package.Id);
            result.PackagePayment.TotalPaid.Should().Be(500M);
            result.PackageType.Should().Be(package.PackageType);
            result.CedarId.Should().Be(package.Supplier.CedarId);
        }
    }
}
