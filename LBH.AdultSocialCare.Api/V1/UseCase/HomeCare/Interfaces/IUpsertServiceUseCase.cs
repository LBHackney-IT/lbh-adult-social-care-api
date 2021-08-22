using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces
{
    public interface IUpsertServiceUseCase
    {
        public Task<HomeCareServiceDomain> ExecuteAsync(HomeCareServiceDomain package);
    }
}
