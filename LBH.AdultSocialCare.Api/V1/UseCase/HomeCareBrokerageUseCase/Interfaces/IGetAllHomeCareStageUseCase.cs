using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareBrokerageBoundary.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Interfaces
{
    public interface IGetAllHomeCareStageUseCase
    {
        public Task<IEnumerable<HomeCareStageResponse>> GetAllAsync();
    }
}
