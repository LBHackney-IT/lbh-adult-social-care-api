using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCareRequestMoreInformationGateways
{
    public interface IHomeCareRequestMoreInformationGateway
    {
        public Task<bool> CreateAsync(HomeCareRequestMoreInformation homeCareRequestMoreInformationCreation);
    }
}
