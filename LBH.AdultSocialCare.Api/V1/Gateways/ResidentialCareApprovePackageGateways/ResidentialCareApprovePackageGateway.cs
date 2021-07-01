using System;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareApprovePackageDomains;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

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
                throw new ErrorException($"Could not find the Residential Care Package {residentialCarePackageId}");

            var costOfCare = await _databaseContext.ResidentialCareBrokerageInfos
                .Where(a => a.ResidentialCarePackageId.Equals(residentialCarePackageId))
                .Select(a => a.ResidentialCore)
                .SingleOrDefaultAsync().ConfigureAwait(false);

            var costOfAdditionalNeeds = await _databaseContext.ResidentialCareBrokerageInfos
                .Where(a => a.ResidentialCarePackageId.Equals(residentialCarePackageId))
                .Select(a => a.AdditionalNeedsPayment)
                .SingleOrDefaultAsync().ConfigureAwait(false);

            var costOfOneOff = await _databaseContext.ResidentialCareBrokerageInfos
                .Where(a => a.ResidentialCarePackageId.Equals(residentialCarePackageId))
                .Select(a => a.AdditionalNeedsPaymentOneOff)
                .SingleOrDefaultAsync().ConfigureAwait(false);

            var residentialCareApprovePackageDomain = new ResidentialCareApprovePackageDomain
            {
                ResidentialCarePackage = residentialCarePackage.ToDomain(),
                CostOfCare = costOfCare,
                CostOfAdditionalNeeds = costOfAdditionalNeeds,
                CostOfOneOff = costOfOneOff,
                TotalPerWeek = costOfCare + costOfAdditionalNeeds
            };

            return residentialCareApprovePackageDomain;
        }
    }
}
