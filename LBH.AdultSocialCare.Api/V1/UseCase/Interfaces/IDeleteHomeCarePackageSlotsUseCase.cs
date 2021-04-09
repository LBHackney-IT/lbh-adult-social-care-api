using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IDeleteHomeCarePackageSlotsUseCase
    {
        public Task<bool> DeleteAsync(Guid homeCarePackageId);
    }
}
