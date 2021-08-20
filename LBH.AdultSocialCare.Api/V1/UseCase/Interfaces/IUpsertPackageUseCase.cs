using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IUpsertPackageUseCase
    {
        public Task<PackageDomain> ExecuteAsync(PackageDomain package);
    }
}
