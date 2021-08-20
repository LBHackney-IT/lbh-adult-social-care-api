using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IGetStatusUseCase
    {
        public Task<StatusDomain> GetAsync(int statusId);
    }
}
