using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IDeletePackageUseCase
    {
        public Task<bool> DeleteAsync(Guid packageId);
    }
}
