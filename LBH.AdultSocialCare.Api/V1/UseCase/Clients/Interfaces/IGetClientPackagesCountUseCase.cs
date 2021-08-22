using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces
{
    public interface IGetClientPackagesCountUseCase
    {
        Task<int> GetCountAsync(Guid clientId, int? packageTypeId);
    }
}
