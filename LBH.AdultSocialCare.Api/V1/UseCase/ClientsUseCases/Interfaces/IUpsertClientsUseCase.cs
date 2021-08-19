using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ClientsUseCases.Interfaces
{
    public interface IUpsertClientsUseCase
    {
        public Task<ClientsDomain> ExecuteAsync(ClientsDomain clients);
    }
}
