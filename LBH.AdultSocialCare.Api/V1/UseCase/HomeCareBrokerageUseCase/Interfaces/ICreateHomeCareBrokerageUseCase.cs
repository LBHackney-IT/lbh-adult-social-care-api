using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerageDomains;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Interfaces
{
    public interface ICreateHomeCareBrokerageUseCase
    {
        public Task<HomeCareBrokerageResponse> ExecuteAsync(Guid homeCarePackageId, HomeCareBrokerageCreationDomain homeCareBrokerageCreationDomain);
    }
}
