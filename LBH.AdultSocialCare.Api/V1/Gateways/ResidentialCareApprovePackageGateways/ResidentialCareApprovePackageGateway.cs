using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareApprovePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApprovePackageGateways
{
    public class ResidentialCareApprovePackageGateway : IResidentialCareApprovePackageGateway
    {
        private readonly DatabaseContext _databaseContext;

        public ResidentialCareApprovePackageGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<ResidentialCareApprovePackageDomain> GetAsync(Guid residentialCarePackageId)
        {
            var residentialCarePackage = await _databaseContext.ResidentialCarePackages
                .Where(item => item.Id == residentialCarePackageId)
                .Include(item => item.ResidentialCareAdditionalNeeds)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (residentialCarePackage == null)
            {
                throw new ApiException($"Could not find the Residential Care Package {residentialCarePackageId}");
            }

            var residentialCareApprovePackageDomain = new ResidentialCareApprovePackageDomain()
            {
                ResidentialCarePackage = residentialCarePackage.ToDomain(),
                CostOfCare = 0,
                CostOfAdditionalNeeds = 0,
                CostOfOneOff = 0,
                TotalPerWeek = 0
            };

            return residentialCareApprovePackageDomain;
        }
    }
}
