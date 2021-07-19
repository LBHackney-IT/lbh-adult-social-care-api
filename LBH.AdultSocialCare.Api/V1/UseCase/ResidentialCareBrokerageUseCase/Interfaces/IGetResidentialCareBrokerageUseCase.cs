using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareBrokerageBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Interfaces
{
    public interface IGetResidentialCareBrokerageUseCase
    {
        Task<ResidentialCareBrokerageInfoResponse> Execute(Guid residentialCarePackageId);
    }
}
