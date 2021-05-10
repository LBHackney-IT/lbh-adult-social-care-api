using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareBrokerageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Interfaces
{
    public interface ICreateHomeCareBrokerageUseCase
    {
        public Task<HomeCareBrokerageResponse> ExecuteAsync(Guid homeCarePackageId, HomeCareBrokerageCreationDomain homeCareBrokerageCreationDomain);
    }
}
