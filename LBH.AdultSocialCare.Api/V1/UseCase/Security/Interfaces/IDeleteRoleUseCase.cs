using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces
{
    public interface IDeleteRoleUseCase
    {
        public Task<bool> DeleteAsync(Guid roleId);
    }
}
