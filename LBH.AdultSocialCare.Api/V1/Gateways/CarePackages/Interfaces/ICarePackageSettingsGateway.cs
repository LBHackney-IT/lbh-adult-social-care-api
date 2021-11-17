using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces
{
    public interface ICarePackageSettingsGateway
    {
        Task<CarePackageSettings> GetPackageSettingsPlainAsync(Guid carePackageId, bool trackChanges = false);
    }
}
