using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ICarePackageSettingsGateway
    {
        Task<CarePackageSettings> GetPackageSettingsPlainAsync(Guid carePackageId, bool trackChanges = false);
    }
}
