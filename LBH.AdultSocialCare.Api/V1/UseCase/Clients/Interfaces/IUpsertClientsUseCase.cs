using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces
{
    public interface IUpsertClientsUseCase
    {
        public Task<ServiceUserDomain> ExecuteAsync(ServiceUserDomain serviceUser);
    }
}
