using LBH.AdultSocialCare.Api.V1.Domain;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IUpsertServiceUseCase
    {
        public Task<ServiceDomain> ExecuteAsync(ServiceDomain package);
    }
}
