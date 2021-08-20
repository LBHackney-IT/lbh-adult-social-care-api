using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Concrete
{
    public class CreateDayCarePackageHistoryUseCase : ICreateDayCarePackageHistoryUseCase
    {
        private readonly IDayCarePackageGateway _dayCarePackageGateway;

        public CreateDayCarePackageHistoryUseCase(IDayCarePackageGateway dayCarePackageGateway)
        {
            _dayCarePackageGateway = dayCarePackageGateway;
        }

        public async Task<Guid> Execute(DayCareApprovalHistoryForCreationDomain dayCareApprovalHistoryForCreationDomain)
        {
            var dayCarePackageHistoryEntity = dayCareApprovalHistoryForCreationDomain.ToDb();
            var id = await _dayCarePackageGateway.CreateDayCarePackageHistory(dayCarePackageHistoryEntity).ConfigureAwait(false);
            return id;
        }
    }
}
