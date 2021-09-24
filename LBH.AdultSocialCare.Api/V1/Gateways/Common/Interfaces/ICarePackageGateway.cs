using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ICarePackageGateway
    {
        Task<CarePackage> GetPackageAsync(Guid packageId);

        void Create(CarePackage newCarePackage);
    }
}
