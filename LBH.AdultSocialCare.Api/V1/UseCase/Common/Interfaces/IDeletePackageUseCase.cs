using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IDeletePackageUseCase
    {
        public Task<bool> DeleteAsync(int packageId);
    }
}
