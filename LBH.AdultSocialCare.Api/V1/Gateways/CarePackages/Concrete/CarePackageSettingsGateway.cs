using System;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Concrete
{
    public class CarePackageSettingsGateway : ICarePackageSettingsGateway
    {
        private readonly DatabaseContext _dbContext;

        public CarePackageSettingsGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarePackageSettings> GetPackageSettingsPlainAsync(Guid carePackageId, bool trackChanges = false)
        {
            return await _dbContext.CarePackageSettings
                .Where(ps => ps.CarePackageId.Equals(carePackageId)).TrackChanges(trackChanges).SingleOrDefaultAsync();
        }
    }
}
