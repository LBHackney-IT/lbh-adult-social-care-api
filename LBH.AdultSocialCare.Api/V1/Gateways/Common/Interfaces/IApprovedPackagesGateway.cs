using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface IApprovedPackagesGateway
    {
        Task<PagedList<ApprovedPackagesDomain>> GetApprovedPackages(ApprovedPackagesParameters parameters, int statusId);

        Task<IEnumerable<UsersMinimalDomain>> GetUsers(Guid roleId);
    }
}
