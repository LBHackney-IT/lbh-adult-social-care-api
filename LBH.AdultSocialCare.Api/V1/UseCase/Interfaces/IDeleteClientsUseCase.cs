using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IDeleteClientsUseCase
    {
        public Task<bool> DeleteAsync(Guid clientId);
    }
}
