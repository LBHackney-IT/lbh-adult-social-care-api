using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareDomains;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IUpsertServiceUseCase
    {
        public Task<HomeCareServiceDomain> ExecuteAsync(HomeCareServiceDomain package);
    }
}
