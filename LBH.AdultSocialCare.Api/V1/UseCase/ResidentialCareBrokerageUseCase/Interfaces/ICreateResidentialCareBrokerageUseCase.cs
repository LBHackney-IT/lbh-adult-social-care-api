using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Interfaces
{
    public interface ICreateResidentialCareBrokerageUseCase
    {
        Task<ResidentialCareBrokerageInfoResponse> ExecuteAsync(ResidentialCareBrokerageInfoCreationDomain residentialCareBrokerageInfoCreationDomain);

    }
}
