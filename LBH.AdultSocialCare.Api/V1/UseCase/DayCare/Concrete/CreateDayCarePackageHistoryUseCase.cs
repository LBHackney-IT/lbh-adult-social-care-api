using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCare.Concrete
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
