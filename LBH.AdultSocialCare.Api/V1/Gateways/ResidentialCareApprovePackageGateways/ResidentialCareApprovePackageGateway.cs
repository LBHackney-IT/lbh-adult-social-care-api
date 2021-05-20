using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareApprovePackageDomains;
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
            {
                throw new ErrorException($"Could not find the Residential Care Package {residentialCarePackageId}");
            }

            var residentialCareApprovePackageDomain = new ResidentialCareApprovePackageDomain()
            {
                ResidentialCarePackage = residentialCarePackage.ToDomain(),
                CostOfCare = 1200,
                CostOfAdditionalNeeds = 350,
                CostOfOneOff = 330,
                TotalPerWeek = 600
            };

            return residentialCareApprovePackageDomain;
        }
    }
}
