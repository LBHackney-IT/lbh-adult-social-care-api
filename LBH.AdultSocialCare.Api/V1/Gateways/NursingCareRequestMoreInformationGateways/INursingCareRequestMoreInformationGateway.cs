using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCareRequestMoreInformationGateways
{
    public interface INursingCareRequestMoreInformationGateway
    {
        public Task<bool> CreateAsync(NursingCareRequestMoreInformation nursingCareRequestMoreInformationCreation);
    }
}
