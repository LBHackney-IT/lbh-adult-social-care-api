using LBH.AdultSocialCare.Api.V1.Domain.PackageDomains;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IGetPackageUseCase
    {
        public Task<PackageDomain> GetAsync(int packageId);
    }
}
