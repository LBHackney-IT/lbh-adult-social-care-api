using System;
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
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Payments
{
    public class ChangePayRunInvoiceStatusUseCaseTests : BaseTest
    {
        private readonly ChangePayRunInvoiceStatusUseCase _useCase;
        private readonly Mock<IPayRunGateway> _payRunGateway;
        private readonly Mock<IPayRunInvoiceGateway> _payRunInvoiceGateway;
        private readonly Mock<IDatabaseManager> _dbManager;

        private readonly Payrun _payrun;
        private readonly PayrunInvoice _payrunInvoice;

        public ChangePayRunInvoiceStatusUseCaseTests()
        {
            _payRunGateway = new Mock<IPayRunGateway>();
            _payRunInvoiceGateway = new Mock<IPayRunInvoiceGateway>();
            _dbManager = new Mock<IDatabaseManager>();
            _payrun = TestDataHelper.CreatePayRun(type: PayrunType.ResidentialRecurring, status: PayrunStatus.WaitingForApproval);

            var fixture = new Fixture();
            _payrunInvoice = fixture.Build<PayrunInvoice>()
                .OmitAutoProperties()
                .With(pi => pi.PayrunId, _payrun.Id)
                .With(pi => pi.InvoiceStatus, InvoiceStatus.Draft)
                .Create();
            _payrun.PayrunInvoices.Add(_payrunInvoice);

            _payRunGateway.Setup(g => g.GetPayRunAsync(It.IsAny<Guid>(), It.IsAny<PayRunFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_payrun);

            _payRunInvoiceGateway.Setup(g => g.GetPayRunInvoiceAsync(It.IsAny<Guid>(), It.IsAny<PayRunInvoiceFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_payrunInvoice);

            _useCase = new ChangePayRunInvoiceStatusUseCase(_dbManager.Object, _payRunGateway.Object,
                _payRunInvoiceGateway.Object);
        }

        [Fact]
        public void ShouldRaiseExceptionIfPayRunDoesNotExist()
        {
            _payRunGateway.Setup(g => g.GetPayRunAsync(It.IsAny<Guid>(), It.IsAny<PayRunFields>(), It.IsAny<bool>()))
                .ReturnsAsync((Payrun) null);

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_payrun.Id, _payrunInvoice.Id, InvoiceStatus.Accepted))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status404NotFound);

            _payRunGateway.VerifyGetPayRun();
            _payRunGateway.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldRaiseExceptionIfPayRunInvoiceDoesNotExist()
        {
            _payRunInvoiceGateway.Setup(g => g.GetPayRunInvoiceAsync(It.IsAny<Guid>(), It.IsAny<PayRunInvoiceFields>(), It.IsAny<bool>()))
                .ReturnsAsync((PayrunInvoice) null);
            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_payrun.Id, _payrunInvoice.Id, InvoiceStatus.Accepted))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status404NotFound);
            _dbManager.VerifyNotSaved();
        }

        [Theory]
        [InlineData(PayrunStatus.Draft)]
        [InlineData(PayrunStatus.InProgress)]
        [InlineData(PayrunStatus.Approved)]
        [InlineData(PayrunStatus.Paid)]
        [InlineData(PayrunStatus.PaidWithHold)]
        [InlineData(PayrunStatus.Archived)]
        public void ShouldFailIfPayRunNotInReviewOrAwaitingApproval(PayrunStatus status)
        {
            _payrun.Status = status;
            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_payrun.Id, _payrunInvoice.Id, InvoiceStatus.Accepted))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status400BadRequest);
            _dbManager.VerifyNotSaved();
        }

        [Fact]
        public void ShouldFailIfInvoiceIsHeld()
        {
            _payrunInvoice.InvoiceStatus = InvoiceStatus.Held;
            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_payrun.Id, _payrunInvoice.Id, InvoiceStatus.Accepted))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status400BadRequest);
            _dbManager.VerifyNotSaved();
        }

        [Theory]
        [InlineData(PayrunStatus.WaitingForReview, InvoiceStatus.Draft, InvoiceStatus.Accepted)]
        [InlineData(PayrunStatus.WaitingForReview, InvoiceStatus.Rejected, InvoiceStatus.Accepted)]
        [InlineData(PayrunStatus.WaitingForReview, InvoiceStatus.Accepted, InvoiceStatus.Rejected)]
        [InlineData(PayrunStatus.WaitingForReview, InvoiceStatus.Released, InvoiceStatus.Accepted)]
        [InlineData(PayrunStatus.WaitingForApproval, InvoiceStatus.Draft, InvoiceStatus.Accepted)]
        public async void ShouldChangePayRunInvoiceStatus(PayrunStatus payrunStatus, InvoiceStatus oldInvoiceStatus, InvoiceStatus newInvoiceStatus)
        {
            _payrun.Status = payrunStatus;
            _payrunInvoice.InvoiceStatus = oldInvoiceStatus;
            await _useCase.ExecuteAsync(_payrun.Id, _payrunInvoice.Id, newInvoiceStatus);

            _payrunInvoice.InvoiceStatus.Should().Be(newInvoiceStatus);
            _dbManager.VerifySaved();
        }
    }
}
