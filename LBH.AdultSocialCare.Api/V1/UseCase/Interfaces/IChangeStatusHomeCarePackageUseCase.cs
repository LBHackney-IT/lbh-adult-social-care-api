using LBH.AdultSocialCare.Api.V1.Domain;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IChangeStatusHomeCarePackageUseCase
    {
        public Task<HomeCarePackageDomain> UpdateAsync(Guid homeCarePackageId, int statusId);
    }
}
