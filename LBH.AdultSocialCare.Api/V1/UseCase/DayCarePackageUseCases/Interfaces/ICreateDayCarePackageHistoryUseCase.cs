using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces
{
    public interface ICreateDayCarePackageHistoryUseCase
    {
        Task<Guid> Execute(DayCareApprovalHistoryForCreationDomain dayCareApprovalHistoryForCreationDomain);
    }
}
