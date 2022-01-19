using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.TestFramework.Extensions;
using Moq;
using System;
using Common.Exceptions.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Payments
{
    public class MakePayRunPaymentUseCaseTests
    {
        private readonly Mock<IPayRunGateway> _payRunGateway;
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly MakePayRunPaymentUseCase _useCase;

        private readonly Payrun _payrun;
        private readonly PayRunInsightsDomain _payRunInsights;

        public MakePayRunPaymentUseCaseTests()
        {
            _payrun = TestDataHelper.CreatePayRun(type: PayrunType.ResidentialRecurring, status: PayrunStatus.Approved);
            _payRunInsights = new PayRunInsightsDomain
            {
                TotalInvoiceAmount = 1000M,
                HoldsCount = 5,
                TotalHeldAmount = 100M
            };

            var payRunInvoiceGateway = new Mock<IPayRunInvoiceGateway>();

            _payRunGateway = new Mock<IPayRunGateway>();
            _dbManager = new Mock<IDatabaseManager>();

            _payRunGateway.Setup(g => g.GetPayRunAsync(It.IsAny<Guid>(), It.IsAny<PayRunFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_payrun);

            payRunInvoiceGateway.Setup(g => g.GetPayRunInsightsAsync(It.IsAny<Guid>())).ReturnsAsync(_payRunInsights);

            _useCase = new MakePayRunPaymentUseCase(_payRunGateway.Object, _dbManager.Object,
                payRunInvoiceGateway.Object);
        }

        [Fact]
        public void ShouldRaiseExceptionIfPayRunDoesNotExist()
        {
            _payRunGateway.Setup(g => g.GetPayRunAsync(It.IsAny<Guid>(), It.IsAny<PayRunFields>(), It.IsAny<bool>()))
                .ReturnsAsync((Payrun) null);

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_payrun.Id))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status404NotFound);

            _payRunGateway.VerifyGetPayRun();
            _payRunGateway.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(PayrunStatus.Draft)]
        [InlineData(PayrunStatus.InProgress)]
        [InlineData(PayrunStatus.WaitingForReview)]
        [InlineData(PayrunStatus.WaitingForApproval)]
        [InlineData(PayrunStatus.Paid)]
        [InlineData(PayrunStatus.PaidWithHold)]
        [InlineData(PayrunStatus.Archived)]
        public void ShouldRaiseExceptionIfPayRunIsNotApproved(PayrunStatus status)
        {
            _payrun.Status = status;

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_payrun.Id))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status400BadRequest);

            _payRunGateway.VerifyGetPayRun();
            _payRunGateway.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(1, 100, PayrunStatus.PaidWithHold)]
        [InlineData(0, 0, PayrunStatus.Paid)]
        public async void ShouldMarkPayRunAsPaid(int holdsCount, decimal heldAmount, PayrunStatus paidStatus)
        {
            _payRunInsights.HoldsCount = holdsCount;
            _payRunInsights.TotalHeldAmount = heldAmount;
            await _useCase.ExecuteAsync(_payrun.Id);

            _payrun.Status.Should().Be(paidStatus);
            _payrun.Paid.Should().Be(_payRunInsights.TotalInvoiceAmount);
            _payrun.Held.Should().Be(_payRunInsights.TotalHeldAmount);
            _dbManager.VerifySaved();
        }

        [Fact]
        public async void ShouldCreateHistoryRecordForPayRunPayment()
        {
            _payrun.Status = PayrunStatus.Approved;
            await _useCase.ExecuteAsync(_payrun.Id);

            _payrun.Histories.Count.Should().Be(1);

            _payrun.Histories.Should().ContainSingle(h =>
                h.Type == PayRunHistoryType.PaidPayrun);

            _dbManager.VerifySaved();
        }
    }
}
