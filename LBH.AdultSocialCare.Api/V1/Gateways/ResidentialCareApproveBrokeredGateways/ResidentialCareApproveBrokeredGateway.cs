using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareApproveBrokeredDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApproveBrokeredGateways
{
    public class ResidentialCareApproveBrokeredGateway : IResidentialCareApproveBrokeredGateway
    {
        private readonly DatabaseContext _databaseContext;

        public ResidentialCareApproveBrokeredGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<ResidentialCareApproveBrokeredDomain> GetAsync(Guid residentialCarePackageId)
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

            var costOfCare = await _databaseContext.ResidentialCareBrokerageInfos
                .Where(a => a.ResidentialCarePackageId.Equals(residentialCarePackageId))
                .Select(a => a.ResidentialCore)
                .SingleOrDefaultAsync().ConfigureAwait(false);

            var costOfAdditionalNeeds = await _databaseContext.ResidentialCareBrokerageInfos
                .Where(a => a.ResidentialCarePackageId.Equals(residentialCarePackageId))
                .Select(a => a.AdditionalNeedsPayment)
                .SingleOrDefaultAsync().ConfigureAwait(false);

            var residentialCareApproveBrokeredDomain = new ResidentialCareApproveBrokeredDomain()
            {
                ResidentialCarePackage = residentialCarePackage.ToDomain(),
                CostOfCare = costOfCare,
                CostOfAdditionalNeeds = costOfAdditionalNeeds,
                TotalPerWeek = costOfCare + costOfAdditionalNeeds
            };

            return residentialCareApproveBrokeredDomain;
        }
    }
}
