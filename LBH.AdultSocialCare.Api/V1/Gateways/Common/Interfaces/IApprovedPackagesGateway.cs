using LBH.AdultSocialCare.Api.V1.Domain.Security;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface IApprovedPackagesGateway
    {
        Task<IEnumerable<UsersMinimalDomain>> GetUsers(Guid roleId);
    }
}
