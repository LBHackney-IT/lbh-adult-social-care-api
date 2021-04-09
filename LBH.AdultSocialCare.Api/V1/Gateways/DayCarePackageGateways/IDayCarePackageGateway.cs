using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways
{
    public interface IDayCarePackageGateway
    {
        Task<Guid> CreateDayCarePackage(Infrastructure.Entities.DayCarePackage dayCarePackage);
        Task SaveChangesAsync();
    }
}
