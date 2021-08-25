using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces
{
    public interface IGetServiceUseCase
    {
        public Task<HomeCareServiceDomain> GetAsync(int serviceId);
    }
}