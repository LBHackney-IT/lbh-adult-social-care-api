using System;
using AutoFixture;
using Common.Exceptions.CustomExceptions;
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
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Payments
{
    public class HoldInvoiceUseCaseTests : BaseTest
    {
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly Mock<IHeldInvoiceGateway> _heldInvoiceGateway;
        private readonly Mock<IPayRunInvoiceGateway> _payRunInvoiceGateway;
        private readonly Mock<IPayRunGateway> _payRunGateway;

        private readonly HoldInvoiceUseCase _useCase;

        private readonly Payrun _payrun;
        private readonly PayrunInvoice _payrunInvoice;
        private readonly HeldInvoiceCreationDomain _heldInvoiceCreationDomain;

        public HoldInvoiceUseCaseTests()
        {
            _dbManager = new Mock<IDatabaseManager>();
            _heldInvoiceGateway = new Mock<IHeldInvoiceGateway>();
            _payRunInvoiceGateway = new Mock<IPayRunInvoiceGateway>();
            _payRunGateway = new Mock<IPayRunGateway>();

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

            _useCase = new HoldInvoiceUseCase(_dbManager.Object, _heldInvoiceGateway.Object,
                _payRunInvoiceGateway.Object, _payRunGateway.Object);

            _heldInvoiceCreationDomain = new HeldInvoiceCreationDomain
            {
                PayRunInvoiceId = _payrunInvoice.Id, ActionRequiredFromId = 1, ReasonForHolding = "Incorrect values"
            };
        }

        [Fact]
        public void ShouldRaiseExceptionIfPayRunDoesNotExist()
        {
            _payRunGateway.Setup(g => g.GetPayRunAsync(It.IsAny<Guid>(), It.IsAny<PayRunFields>(), It.IsAny<bool>()))
                .ReturnsAsync((Payrun) null);

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_payrun.Id, _payrunInvoice.Id, _heldInvoiceCreationDomain))
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
                .Invoking(useCase => useCase.ExecuteAsync(_payrun.Id, _payrunInvoice.Id, _heldInvoiceCreationDomain))
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
        public void ShouldFailIfPayRunNotInReviewOrWaitingApproval(PayrunStatus status)
        {
            _payrun.Status = status;
            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_payrun.Id, _payrunInvoice.Id, _heldInvoiceCreationDomain))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status400BadRequest);

            _payRunGateway.VerifyGetPayRun();
            _payRunGateway.VerifyNoOtherCalls();
            _dbManager.VerifyNotSaved();
        }

        [Fact]
        public async void ShouldMarkPayRunInvoiceAsHeld()
        {
            await _useCase.ExecuteAsync(_payrun.Id, _payrunInvoice.Id, _heldInvoiceCreationDomain);

            _payrunInvoice.InvoiceStatus.Should().Be(InvoiceStatus.Held);
            _dbManager.VerifySaved();
        }
    }
}
