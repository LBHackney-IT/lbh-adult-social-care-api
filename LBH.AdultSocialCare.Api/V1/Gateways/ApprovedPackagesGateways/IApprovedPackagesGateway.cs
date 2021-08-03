using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ApprovedPackagesGateways
{
    public interface IApprovedPackagesGateway
    {
        Task<PagedList<ApprovedPackagesDomain>> GetApprovedPackages(ApprovedPackagesParameters parameters, int statusId);

        [Obsolete("use version with 'string role' instead")]
        Task<IEnumerable<UsersMinimalDomain>> GetUsers(int roleId);
        
        Task<IEnumerable<UsersMinimalDomain>> GetUsers(string roleName);
    }
}
