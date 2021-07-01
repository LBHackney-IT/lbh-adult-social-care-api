using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareApproveCommercialDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareApprovePackageDomains;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApproveCommercialGateways
{
    public class NursingCareApproveCommercialGateway : INursingCareApproveCommercialGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public NursingCareApproveCommercialGateway(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<NursingCareApproveCommercialDomain> GetAsync(Guid nursingCarePackageId)
        {
            var nursingCarePackage = await _databaseContext.NursingCarePackages
                .Where(item => item.Id == nursingCarePackageId)
                .Include(item => item.NursingCareAdditionalNeeds)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (nursingCarePackage == null)
            {
                throw new ErrorException($"Could not find the Nursing Care Package {nursingCarePackageId}");
            }

            var costOfCare = await _databaseContext.NursingCareBrokerageInfos
                .Where(a => a.NursingCarePackageId.Equals(nursingCarePackageId))
                .Select(a => a.NursingCore)
                .SingleOrDefaultAsync().ConfigureAwait(false);

            var costOfAdditionalNeeds = await _databaseContext.NursingCareBrokerageInfos
                .Where(a => a.NursingCarePackageId.Equals(nursingCarePackageId))
                .Select(a => a.AdditionalNeedsPayment)
                .SingleOrDefaultAsync().ConfigureAwait(false);

            var nursingCareApproveCommercialDomain = new NursingCareApproveCommercialDomain()
            {
                NursingCarePackage = nursingCarePackage.ToDomain(),
                CostOfCare = costOfCare,
                CostOfAdditionalNeeds = costOfAdditionalNeeds,
                TotalPerWeek = costOfCare + costOfAdditionalNeeds
            };

            return nursingCareApproveCommercialDomain;
        }
    }
}
