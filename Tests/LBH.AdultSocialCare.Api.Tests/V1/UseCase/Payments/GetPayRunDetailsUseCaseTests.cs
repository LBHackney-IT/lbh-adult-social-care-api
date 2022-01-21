using AutoFixture;
using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Core;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Data.Extensions;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Payments
{
    public class GetPayRunDetailsUseCaseTests : BaseTest
    {
        private readonly GetPayRunDetailsUseCase _useCase;
        private readonly Mock<IPayRunGateway> _payRunGateway;
        private readonly Mock<IPayRunInvoiceGateway> _payRunInvoiceGateway;

        private readonly Payrun _payrun;
        private readonly Fixture _fixture;

        public GetPayRunDetailsUseCaseTests()
        {
            _payrun = TestDataHelper.CreatePayRun();
            _fixture = new Fixture();

            _payRunGateway = new Mock<IPayRunGateway>();
            _payRunInvoiceGateway = new Mock<IPayRunInvoiceGateway>();

            _useCase = new GetPayRunDetailsUseCase(_payRunGateway.Object, _payRunInvoiceGateway.Object);
        }

        [Fact]
        public void ShouldRaiseExceptionIfPayrunDoesNotExist()
        {
            _payRunGateway.Setup(g => g.GetPayRunAsync(It.IsAny<Guid>(), It.IsAny<PayRunFields>(), It.IsAny<bool>()))
                .ReturnsAsync((Payrun) null);

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_payrun.Id, new PayRunDetailsQueryParameters()))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task ShouldReturnPayRunDetails()
        {
            _payRunGateway.Setup(g => g.GetPayRunAsync(It.IsAny<Guid>(), It.IsAny<PayRunFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_payrun);
            var pagedInvoices = _fixture.Build<PagedList<PayRunInvoiceDomain>>()
                .Without(p => p.Capacity)
                .Create();
            _payRunInvoiceGateway
                .Setup(g => g.GetPayRunInvoicesSummaryAsync(It.IsAny<Guid>(), It.IsAny<PayRunDetailsQueryParameters>()))
                .ReturnsAsync(pagedInvoices);

            var requestParam = new PayRunDetailsQueryParameters() { PageNumber = 1, PageSize = 11 };
            var expectedResponse = PayrunExtensions.CreateDetailsViewResponse(_payrun, pagedInvoices, pagedInvoices.PagingMetaData);
            var response = await _useCase.ExecuteAsync(_payrun.Id, requestParam).ConfigureAwait(false);

            _payRunGateway.Verify(x => x.GetPayRunAsync
                (_payrun.Id, It.IsAny<PayRunFields>(), It.IsAny<bool>()), Times.Once);

            _payRunInvoiceGateway.Verify(x => x.GetPayRunInvoicesSummaryAsync
                (_payrun.Id, It.Is<PayRunDetailsQueryParameters>(d => d.PageSize == 11 && d.PageNumber == 1)), Times.Once);

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
