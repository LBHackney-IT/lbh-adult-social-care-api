using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces
{
    public interface IChangeStatusHomeCarePackageUseCase
    {
        Task<HomeCarePackageDomain> UpdateAsync(Guid homeCarePackageId, int statusId,
            string requestMoreInformation = null);
    }
}
