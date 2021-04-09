using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IDeleteServiceUseCase
    {
        public Task<bool> DeleteAsync(Guid serviceId);
    }
}
