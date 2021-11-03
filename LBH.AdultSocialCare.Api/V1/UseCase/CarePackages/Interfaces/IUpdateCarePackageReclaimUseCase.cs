using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IUpdateCarePackageReclaimUseCase
    {
        Task UpdateAsync(CarePackageReclaimUpdateDomain carePackageReclaimUpdateDomain);

        Task<IList<CarePackageReclaimDomain>> UpdateListAsync(IList<CarePackageReclaimUpdateDomain> requestedReclaims);
    }
}
