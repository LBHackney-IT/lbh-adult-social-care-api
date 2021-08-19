using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCareCollegeUseCase.Interfaces
{
    public interface IGetDayCareCollegeUseCase
    {
        Task<DayCareCollegeResponse> Execute(int dayCareCollegeId);
    }
}
