using System;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.NursingCare
{
    public class UpsertFundedNursingCareUseCaseTests
    {
        [Fact]
        public void FncIsCreatedWhenCollectorIsProvided()
        {
            var gateway = new Mock<IFundedNursingCaseGateway>();
            var useCase = new UpsertFundedNursingCareUseCase(gateway.Object);

            var packageId = Guid.NewGuid();
            var collectorId = 1;

            useCase.UpsertAsync(packageId, collectorId);

            gateway.Verify(g => g.DeleteFundedNursingCareAsync(packageId), Times.Never);
            gateway.Verify(g => g.UpsertFundedNursingCaseAsync(
                It.Is<FundedNursingCareDomain>(
                    d => d.NursingCarePackageId == packageId && d.CollectorId == collectorId)), Times.Once);
        }

        [Fact]
        public void FncIsDeletedWhenCollectorIsNull()
        {
            var gateway = new Mock<IFundedNursingCaseGateway>();
            var useCase = new UpsertFundedNursingCareUseCase(gateway.Object);

            var packageId = Guid.NewGuid();

            useCase.UpsertAsync(packageId, null);

            gateway.Verify(g => g.DeleteFundedNursingCareAsync(packageId), Times.Once);
            gateway.Verify(g => g.UpsertFundedNursingCaseAsync(It.IsAny<FundedNursingCareDomain>()), Times.Never());
        }
    }
}
