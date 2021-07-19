using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IDeleteStatusUseCase
    {
        public Task<bool> DeleteAsync(int statusId);
    }
}
