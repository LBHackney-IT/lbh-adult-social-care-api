using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces
{
    public interface IDeleteUsersUseCase
    {
        public Task<bool> DeleteAsync(Guid userId);
    }
}