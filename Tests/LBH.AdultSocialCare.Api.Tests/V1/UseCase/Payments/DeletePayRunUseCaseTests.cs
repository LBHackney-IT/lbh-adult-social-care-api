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
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Payments
{
    public class DeletePayRunUseCaseTests
    {
        private readonly ArchivePayRunUseCase _useCase;
        private readonly Mock<IPayRunGateway> _payRunGateway;
        private readonly Mock<IDatabaseManager> _dbManager;

        private readonly Payrun _payrun;
        private const string DeleteNotes = "invalid values";

        public DeletePayRunUseCaseTests()
        {
            _payrun = TestDataHelper.CreatePayRun(type: PayrunType.ResidentialRecurring, status: PayrunStatus.Approved);
            _payRunGateway = new Mock<IPayRunGateway>();
            _dbManager = new Mock<IDatabaseManager>();

            _payRunGateway.Setup(g => g.GetPayRunAsync(It.IsAny<Guid>(), It.IsAny<PayRunFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_payrun);

            _useCase = new ArchivePayRunUseCase(_payRunGateway.Object, _dbManager.Object);
        }

        [Fact]
        public void ShouldRaiseExceptionIfPayRunDoesNotExist()
        {
            _payRunGateway.Setup(g => g.GetPayRunAsync(It.IsAny<Guid>(), It.IsAny<PayRunFields>(), It.IsAny<bool>()))
                .ReturnsAsync((Payrun) null);

            _useCase
                .Invoking(useCase => useCase.RejectAsync(_payrun.Id, DeleteNotes))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status404NotFound);

            _payRunGateway.VerifyGetPayRun();
            _payRunGateway.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(PayrunStatus.Paid)]
        [InlineData(PayrunStatus.PaidWithHold)]
        [InlineData(PayrunStatus.Archived)]
        public void ShouldRaiseExceptionIfPayRunIsArchivedOrMarkedAsPaid(PayrunStatus status)
        {
            _payrun.Status = status;
            _useCase
                .Invoking(useCase => useCase.RejectAsync(_payrun.Id, DeleteNotes))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status400BadRequest);

            _payRunGateway.VerifyGetPayRun();
            _payRunGateway.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(PayrunStatus.Draft)]
        [InlineData(PayrunStatus.InProgress)]
        [InlineData(PayrunStatus.WaitingForReview)]
        [InlineData(PayrunStatus.WaitingForApproval)]
        [InlineData(PayrunStatus.Approved)]
        public async void ShouldArchivePayRuns(PayrunStatus status)
        {
            _payrun.Status = status;
            await _useCase.DeleteAsync(_payrun.Id, DeleteNotes);
            _payrun.Status.Should().Be(PayrunStatus.Archived);
            _payrun.Histories.Count.Should().Be(1);
            _dbManager.VerifySaved();
        }

        [Fact]
        public async void ShouldCreateHistoryRecordForPayRunDeletion()
        {
            _payrun.Status = PayrunStatus.Draft;
            await _useCase.DeleteAsync(_payrun.Id, DeleteNotes);

            _payrun.Histories.Count.Should().Be(1);

            _payrun.Histories.Should().ContainSingle(h =>
                h.Status == PayrunStatus.Archived &&
                h.Notes.Contains(DeleteNotes));

            _dbManager.VerifySaved();
        }
    }
}
