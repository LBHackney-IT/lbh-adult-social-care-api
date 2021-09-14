using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
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
            var useCase = InitUseCase(out var fncGateway, out _);

            var packageId = Guid.NewGuid();
            var supplierId = 1;
            var collectorId = 1;

            useCase.UpsertAsync(packageId, supplierId, collectorId);

            fncGateway.Verify(g => g.DeleteFundedNursingCareAsync(packageId), Times.Never);
            fncGateway.Verify(g => g.UpsertFundedNursingCaseAsync(
                It.Is<FundedNursingCareDomain>(
                    d => d.NursingCarePackageId == packageId &&
                         d.CollectorId == collectorId)),
                Times.Once);
        }

        [Fact]
        public void FncIsDeletedWhenCollectorIsNull()
        {
            var useCase = InitUseCase(out var fncGateway, out _);

            var packageId = Guid.NewGuid();

            useCase.UpsertAsync(packageId, null, null);

            fncGateway.Verify(g => g.DeleteFundedNursingCareAsync(packageId), Times.Once);
            fncGateway.Verify(g => g.UpsertFundedNursingCaseAsync(It.IsAny<FundedNursingCareDomain>()), Times.Never());
        }

        [Fact]
        public void DefaultFncCollectorShouldBeSetToSupplier()
        {
            var supplierId = 123;
            var collectorId = 456;

            var useCase = InitUseCase(out _, out var supplierGateway, supplierId);

            useCase.UpsertAsync(new Guid(), supplierId, collectorId);

            supplierGateway.Verify(
                g => g.UpdateAsync(It.Is<SupplierDomain>(
                    s => s.Id == supplierId &&
                         s.FundedNursingCareCollectorId == collectorId)),
                Times.Once);
        }

        private static UpsertFundedNursingCareUseCase InitUseCase(out Mock<IFundedNursingCareGateway> fncGateway,
            out Mock<ISupplierGateway> supplierGateway, int supplierId = 1)
        {
            fncGateway = new Mock<IFundedNursingCareGateway>();
            supplierGateway = new Mock<ISupplierGateway>();

            supplierGateway
                .Setup(g => g.GetAsync(supplierId))
                .Returns(() => Task.FromResult(new SupplierDomain { Id = supplierId }));

            var useCase = new UpsertFundedNursingCareUseCase(fncGateway.Object, supplierGateway.Object);

            return useCase;
        }
    }
}
