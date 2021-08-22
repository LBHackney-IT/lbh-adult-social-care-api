using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces
{
    public interface IGetAllHomeCareStageUseCase
    {
        public Task<IEnumerable<StageResponse>> GetAllAsync();
    }
}
