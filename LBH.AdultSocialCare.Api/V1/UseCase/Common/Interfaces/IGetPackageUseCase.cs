using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetPackageUseCase
    {
        public Task<PackageDomain> GetAsync(int packageId);
    }
}