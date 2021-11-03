using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces
{
    public interface ICarePackageSettingsGateway
    {
        Task<CarePackageSettings> GetPackageSettingsPlainAsync(Guid carePackageId, bool trackChanges = false);
    }
}
