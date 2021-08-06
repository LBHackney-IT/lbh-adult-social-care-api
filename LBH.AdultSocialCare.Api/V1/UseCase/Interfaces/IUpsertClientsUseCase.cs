using LBH.AdultSocialCare.Api.V1.Domain.ClientDomains;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IUpsertClientsUseCase
    {
        public Task<ClientsDomain> ExecuteAsync(ClientsDomain clients);
    }
}
