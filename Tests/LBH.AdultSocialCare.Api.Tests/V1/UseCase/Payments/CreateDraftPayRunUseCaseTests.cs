using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.Services.Queuing;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.TestFramework.Extensions;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Payments
{
    public class CreateDraftPayRunUseCaseTests : BaseTest
    {
        private readonly CreateDraftPayRunUseCase _useCase;
        private readonly Mock<IPayRunGateway> _payRunGateway;
        private readonly Mock<IQueueService> _queueService;
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly DateTimeOffset _periodFrom = DateTimeOffset.UtcNow.AddDays(-30).Date;
        private readonly DateTimeOffset _periodTo = DateTimeOffset.UtcNow.Date;

        public CreateDraftPayRunUseCaseTests()
        {
            _payRunGateway = new Mock<IPayRunGateway>();
            _queueService = new Mock<IQueueService>();
            _dbManager = new Mock<IDatabaseManager>();

            _payRunGateway.Setup(g => g.CheckExistsUnApprovedPayRunAsync()).ReturnsAsync(false);
            _payRunGateway.Setup(g => g.GetEndDateOfLastPayRun()).ReturnsAsync(_periodFrom.AddDays(-1));

            _useCase = new CreateDraftPayRunUseCase(_payRunGateway.Object, _queueService.Object, _dbManager.Object);
        }

        [Fact]
        public void ShouldRaiseExceptionIfExistsAnUnapprovedPayRun()
        {
            _payRunGateway.Setup(g => g.CheckExistsUnApprovedPayRunAsync()).ReturnsAsync(true);
            var payRunCreationDomain = new DraftPayRunCreationDomain
            {
                Type = PayrunType.ResidentialRecurring,
                PaidFromDate = _periodFrom,
                PaidUpToDate = _periodTo,
                StartDate = _periodFrom
            };
            _useCase
                .Invoking(useCase => useCase.CreateDraftPayRun(payRunCreationDomain))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status412PreconditionFailed);
            _dbManager.VerifyNotSaved();
        }

        [Theory]
        [InlineData(PayrunType.ResidentialRecurring)]
        [InlineData(PayrunType.ResidentialReleasedHolds)]
        public async void ShouldCreatePayRun(PayrunType type)
        {
            var newPayRun = new Payrun();
            _payRunGateway
                .Setup(g => g.CreateDraftPayRun(It.IsAny<Payrun>()))
                .Callback<Payrun>(payRun => newPayRun = payRun).Returns(Task.CompletedTask);
            var payRunCreationDomain = new DraftPayRunCreationDomain
            {
                Type = type,
                PaidFromDate = _periodFrom,
                PaidUpToDate = _periodTo,
                StartDate = _periodFrom
            };

            await _useCase.CreateDraftPayRun(payRunCreationDomain);
            newPayRun.Should().BeEquivalentTo(payRunCreationDomain, options =>
                options.ExcludingNestedObjects().ExcludingMissingMembers());
            newPayRun.Status.Should().Be(PayrunStatus.Draft);
            _dbManager.VerifySaved();
        }
    }
}
