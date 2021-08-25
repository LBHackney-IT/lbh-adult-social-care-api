using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Concrete
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
                throw new EntityNotFoundException($"Could not find the Residential Care Package {residentialCarePackageId}");

            var costOfCare = Math.Round(await _databaseContext.ResidentialCareBrokerageInfos
                .DefaultIfEmpty()
                .AverageAsync(c => c == null ? 0 : c.ResidentialCore)
                .ConfigureAwait(false), 2);

            var costOfAdditionalNeeds = Math.Round(await _databaseContext.ResidentialCareBrokerageInfos
                .DefaultIfEmpty()
                .AverageAsync(c => c == null ? 0 : c.AdditionalNeedsPayment)
                .ConfigureAwait(false), 2);

            var costOfOneOff = Math.Round(await _databaseContext.ResidentialCareBrokerageInfos
                .DefaultIfEmpty()
                .AverageAsync(c => c == null ? 0 : c.AdditionalNeedsPaymentOneOff)
                .ConfigureAwait(false), 2);

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