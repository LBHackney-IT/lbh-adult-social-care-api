using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IGetAllHomeCareServiceTypesUseCase
    {
        public Task<IList<HomeCareServiceType>> GetAllAsync();
    }
}
