using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface IServiceUserGateway
    {
        Task<bool> CreateAsync(Client client);

        Task<int> GetServiceUserCountAsync(int hackneyId);

        Task<ClientsDomain> GetAsync(int hackneyId);
    }
}
