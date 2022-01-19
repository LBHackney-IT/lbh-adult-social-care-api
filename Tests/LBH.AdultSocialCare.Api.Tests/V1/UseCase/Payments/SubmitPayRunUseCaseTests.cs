using System;
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
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Payments
{
    public class SubmitPayRunUseCaseTests : BaseTest
    {
        private readonly Mock<IPayRunGateway> _payRunGateway;
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly SubmitPayRunUseCase _useCase;


        private readonly Payrun _payrun;
        private const string SubmitNotes = "submit notes";

        public SubmitPayRunUseCaseTests()
        {
            _payrun = TestDataHelper.CreatePayRun(type: PayrunType.ResidentialRecurring, status: PayrunStatus.WaitingForReview);

            _payRunGateway = new Mock<IPayRunGateway>();
            _dbManager = new Mock<IDatabaseManager>();

            _payRunGateway.Setup(g => g.GetPayRunAsync(It.IsAny<Guid>(), It.IsAny<PayRunFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_payrun);

            _useCase = new SubmitPayRunUseCase(_payRunGateway.Object, _dbManager.Object);
        }
        [Fact]
        public void ShouldRaiseExceptionIfPayRunDoesNotExist()
        {
            _payRunGateway.Setup(g => g.GetPayRunAsync(It.IsAny<Guid>(), It.IsAny<PayRunFields>(), It.IsAny<bool>()))
                .ReturnsAsync((Payrun) null);

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_payrun.Id, SubmitNotes))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status404NotFound);

            _payRunGateway.VerifyGetPayRun();
            _payRunGateway.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(PayrunStatus.Draft)]
        [InlineData(PayrunStatus.InProgress)]
        [InlineData(PayrunStatus.WaitingForApproval)]
        [InlineData(PayrunStatus.Approved)]
        [InlineData(PayrunStatus.Paid)]
        [InlineData(PayrunStatus.PaidWithHold)]
        [InlineData(PayrunStatus.Archived)]
        public void ShouldRaiseExceptionIfPayRunStatusIsNotWaitingForReview(PayrunStatus status)
        {
            _payrun.Status = status;
            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_payrun.Id, SubmitNotes))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status400BadRequest);

            _payRunGateway.VerifyGetPayRun();
            _payRunGateway.VerifyNoOtherCalls();
        }

        [Fact]
        public async void ShouldSubmitPayRunForApproval()
        {
            await _useCase.ExecuteAsync(_payrun.Id, SubmitNotes);

            _payrun.Status.Should().Be(PayrunStatus.WaitingForApproval);
            _payrun.Histories.Count.Should().Be(1);
            _payrun.Histories.Should().ContainSingle(h =>
                h.Status == PayrunStatus.WaitingForApproval &&
                h.Notes.Contains(SubmitNotes));
            _dbManager.VerifySaved();
        }
    }
}
