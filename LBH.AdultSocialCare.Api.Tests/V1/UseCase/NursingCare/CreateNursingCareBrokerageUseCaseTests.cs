using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.NursingCare
{
    public class CreateNursingCareBrokerageUseCaseTests : BaseTest
    {
        private readonly Mock<INursingCareBrokerageGateway> _brokerageGateway;
        private readonly Mock<INursingCarePackageGateway> _packageGateway;
        private readonly Mock<IUpsertFundedNursingCareUseCase> _upsertFundedNursingCareUseCase;
        private readonly Mock<IChangeStatusNursingCarePackageUseCase> _changeStatusUseCase;
        private readonly Mock<IDbContextTransaction> _transaction;
        private readonly Mock<IDatabaseManager> _transactionManager;
        private readonly Guid _packageId;

        private readonly CreateNursingCareBrokerageUseCase _useCase;

        public CreateNursingCareBrokerageUseCaseTests()
        {
            _brokerageGateway = new Mock<INursingCareBrokerageGateway>();
            _packageGateway = new Mock<INursingCarePackageGateway>();
            _upsertFundedNursingCareUseCase = new Mock<IUpsertFundedNursingCareUseCase>();
            _changeStatusUseCase = new Mock<IChangeStatusNursingCarePackageUseCase>();
            _transaction = new Mock<IDbContextTransaction>();
            _transactionManager = new Mock<IDatabaseManager>();

            _packageId = Guid.NewGuid();

            _brokerageGateway
                .Setup(g => g.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new NursingCareBrokerageInfoDomain { NursingCareBrokerageId = Guid.Empty });
            _brokerageGateway
                .Setup(g => g.CreateAsync(It.IsAny<NursingCareBrokerageInfo>()))
                .ReturnsAsync(new NursingCareBrokerageInfoDomain { NursingCarePackageId = _packageId });

            _packageGateway
                .Setup(g => g.GetAsync(It.Is<Guid>(g => g == _packageId)))
                .ReturnsAsync(new NursingCarePackageDomain { Id = _packageId });

            _packageGateway.Setup(g => g.CheckNursingCarePackageExists(_packageId))
                .ReturnsAsync(() => new NursingCarePackagePlainDomain
                {
                    Id = _packageId,
                    IsThisUserUnderS117 = false
                });

            _transactionManager
                .Setup(t => t.BeginTransactionAsync())
                .ReturnsAsync(_transaction.Object);

            _useCase = new CreateNursingCareBrokerageUseCase(
                _upsertFundedNursingCareUseCase.Object,
                _changeStatusUseCase.Object,
                _brokerageGateway.Object,
                _packageGateway.Object,
                _transactionManager.Object, Mapper, null, null);
        }

        [Fact]
        public async Task ShouldRaiseExceptionIfBrokerageExistsAlready()
        {
            _brokerageGateway
                .Setup(g => g.GetAsync(_packageId))
                .ReturnsAsync(() => new NursingCareBrokerageInfoDomain { NursingCareBrokerageId = Guid.NewGuid() });

            Func<Task> action = () => _useCase.ExecuteAsync(new NursingCareBrokerageInfoCreationDomain
            {
                NursingCarePackageId = _packageId,
                HasCareCharges = false
            });

            await action.Should().ThrowAsync<ApiException>().ConfigureAwait(false);
            _brokerageGateway.Verify(
                g => g.CreateAsync(It.IsAny<NursingCareBrokerageInfo>()),
                Times.Never);
        }

        [Fact]
        public async Task ShouldSetPackageStatusToApprovedForBrokerage()
        {
            await _useCase.ExecuteAsync(GetBrokerageInfoCreationDomain()).ConfigureAwait(false);

            _changeStatusUseCase.Verify(
                u => u.UpdateAsync(_packageId, ApprovalHistoryConstants.ApprovedForBrokerageId, null),
                Times.Once);

            _transaction.Verify(t => t.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
            _transaction.Verify(t => t.RollbackAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task ShouldUpdatePackageDatesAndStage()
        {
            var request = GetBrokerageInfoCreationDomain();
            await _useCase.ExecuteAsync(request).ConfigureAwait(false);

            _packageGateway.Verify(
                u => u.UpdateAsync(It.Is<NursingCarePackageForUpdateDomain>(p =>
                    p.Id == _packageId &&
                    p.SupplierId == request.SupplierId &&
                    p.StageId == request.StageId &&
                    p.EndDate == request.EndDate)),
                Times.Once);

            _transaction.Verify(t => t.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
            _transaction.Verify(t => t.RollbackAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task ShouldRollbackOnError()
        {
            _changeStatusUseCase
                .Setup(u => u.UpdateAsync(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<string>()))
                .Throws<InvalidOperationException>();

            try
            {
                await _useCase.ExecuteAsync(GetBrokerageInfoCreationDomain()).ConfigureAwait(false);
            }
            catch (InvalidOperationException)
            {
                _transaction.Verify(t => t.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
                _transaction.Verify(t => t.RollbackAsync(It.IsAny<CancellationToken>()), Times.Once);
            }
        }

        private NursingCareBrokerageInfoCreationDomain GetBrokerageInfoCreationDomain()
        {
            return new NursingCareBrokerageInfoCreationDomain
            {
                NursingCarePackageId = _packageId,
                StageId = 10,
                SupplierId = 20,
                FundedNursingCareCollectorId = 30,
                StartDate = DateTimeOffset.Now,
                EndDate = DateTimeOffset.Now.AddDays(30),
                HasCareCharges = false
            };
        }
    }
}
