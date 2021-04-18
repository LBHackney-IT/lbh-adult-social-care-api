using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IDeleteRoleUseCase
    {
        public Task<bool> DeleteAsync(int roleId);
    }
}
