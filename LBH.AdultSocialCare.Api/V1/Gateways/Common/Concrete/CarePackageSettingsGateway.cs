using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class CarePackageSettingsGateway : ICarePackageSettingsGateway
    {
        private readonly DatabaseContext _dbContext;

        public CarePackageSettingsGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarePackageSettings> CheckPackageSettingsExistAsync(Guid packageId, bool trackChanges)
        {
            var packageSettings = await _dbContext.CarePackageSettings
                .Where(ps => ps.CarePackageId.Equals(packageId)).TrackChanges(trackChanges).SingleOrDefaultAsync();

            if (packageSettings == null)
            {
                throw new ApiException($"Package settings for package with id {packageId} not found",
                    HttpStatusCode.NotFound);
            }

            return packageSettings;
        }
    }
}
