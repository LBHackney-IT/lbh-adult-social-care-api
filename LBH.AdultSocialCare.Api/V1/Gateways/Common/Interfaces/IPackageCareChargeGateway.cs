using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface IPackageCareChargeGateway
    {
        Task<PackageCareChargePlainDomain> CreateAsync(PackageCareCharge newPackageCareCharge);

        Task<PackageCareChargePlainDomain> CheckIfExistsAsync(Guid packageCareChargeId);
    }
}
