using AutoFixture;
using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.TestFramework.Extensions;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Payments
{
    public class ApprovePayRunUseCaseTests : BaseInMemoryDatabaseTest
    {
        private readonly ApprovePayRunUseCase _useCase;
        private readonly Mock<IPayRunGateway> _payRunGateway;
        private readonly Mock<IDatabaseManager> _dbManager;

        private readonly Payrun _payrun;
        private const string ApprovalNotes = "Approve pay-run";

        public ApprovePayRunUseCaseTests()
        {
            _payrun = TestDataHelper.CreatePayRun(type: PayrunType.ResidentialRecurring, status: PayrunStatus.Approved);
            var fixture = new Fixture();
            var payRunInvoices = fixture.Build<PayrunInvoice>()
                .OmitAutoProperties()
                .With(pi => pi.PayrunId, _payrun.Id)
                .With(pi => pi.InvoiceStatus, InvoiceStatus.Accepted)
                .CreateMany(5).ToList();
            _payrun.PayrunInvoices = payRunInvoices;

            _payRunGateway = new Mock<IPayRunGateway>();
            _dbManager = new Mock<IDatabaseManager>();

            _payRunGateway.Setup(g => g.GetPayRunAsync(It.IsAny<Guid>(), It.IsAny<PayRunFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_payrun);

            _useCase = new ApprovePayRunUseCase(_payRunGateway.Object, _dbManager.Object);
        }

        [Fact]
        public async void ShouldApprovePayRun()
        {
            _payrun.Status = PayrunStatus.WaitingForApproval;
            await _useCase.ExecuteAsync(_payrun.Id, ApprovalNotes);
            _payrun.Status.Should().Be(PayrunStatus.Approved);
            _dbManager.VerifySaved();
        }

        [Fact]
        public void ShouldRaiseExceptionIfPayRunDoesNotExist()
        {
            _payRunGateway.Setup(g => g.GetPayRunAsync(It.IsAny<Guid>(), It.IsAny<PayRunFields>(), It.IsAny<bool>()))
                .ReturnsAsync((Payrun) null);

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_payrun.Id, ApprovalNotes))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status404NotFound);

            _payRunGateway.VerifyGetPayRun();
            _payRunGateway.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldFailIfAnyInvoiceIsStillInDraft()
        {
            _payrun.PayrunInvoices.Add(new PayrunInvoice()
            {
                InvoiceStatus = InvoiceStatus.Draft
            });

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_payrun.Id, ApprovalNotes))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status400BadRequest);

            _payRunGateway.VerifyGetPayRun();
            _payRunGateway.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(PayrunStatus.Draft)]
        [InlineData(PayrunStatus.InProgress)]
        [InlineData(PayrunStatus.Approved)]
        [InlineData(PayrunStatus.Paid)]
        [InlineData(PayrunStatus.PaidWithHold)]
        [InlineData(PayrunStatus.Archived)]
        public void ShouldFailIfPayrunNotInReviewOrWaitingForApproval(PayrunStatus status)
        {
            _payrun.Status = status;

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_payrun.Id, ApprovalNotes))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status400BadRequest);

            _payRunGateway.VerifyGetPayRun();
            _payRunGateway.VerifyNoOtherCalls();
        }

        [Fact]
        public async void ShouldCreateHistoryRecordForApproval()
        {
            _payrun.Status = PayrunStatus.WaitingForApproval;
            await _useCase.ExecuteAsync(_payrun.Id, ApprovalNotes);

            _payrun.Histories.Count.Should().Be(1);

            _payrun.Histories.Should().ContainSingle(h =>
                h.Status == PayrunStatus.Approved &&
                h.Notes == ApprovalNotes);

            _dbManager.VerifySaved();
        }
    }
}
