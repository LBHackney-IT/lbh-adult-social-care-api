using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareRequestMoreInformationGateways
{
    public interface IResidentialCareRequestMoreInformationGateway
    {
        public Task<bool> CreateAsync(ResidentialCareRequestMoreInformation residentialCareRequestMoreInformationCreation);
    }
}
