using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Extensions;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface IServiceUserGateway
    {
        Task<bool> CreateAsync(ServiceUser serviceUser);

        Task<int> GetServiceUserCountAsync(int hackneyId);

        Task<ServiceUserDomain> GetAsync(int hackneyId);

        Task<ServiceUser> GetByIdAsync(Guid serviceUserId);

        public Task<PagedList<ServiceUserDomain>> GetAllAsync(RequestParameters parameters, string serviceUserName);

        Task<ServiceUserDomain> GetRandomAsync();

        Task<PagedList<ServiceUserDomain>> GetServiceUserInformation(ServiceUserQueryParameters queryParameters);
    }
}
