using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface IServiceUserGateway
    {
        Task<bool> CreateAsync(ServiceUser serviceUser);

        Task<int> GetServiceUserCountAsync(int hackneyId);

        Task<ServiceUserDomain> GetAsync(int hackneyId);

        public Task<PagedList<ServiceUserDomain>> GetAllAsync(RequestParameters parameters, string serviceUserName);

        Task<ServiceUserDomain> GetRandomAsync();
    }
}
