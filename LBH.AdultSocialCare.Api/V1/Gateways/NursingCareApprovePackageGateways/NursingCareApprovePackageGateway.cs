using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareApprovePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApprovePackageGateways
{
    public class NursingCareApprovePackageGateway : INursingCareApprovePackageGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public NursingCareApprovePackageGateway(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<NursingCareApprovePackageDomain> GetAsync(Guid nursingCarePackageId)
        {
            var nursingCarePackage = await _databaseContext.NursingCarePackages
                .Where(item => item.Id == nursingCarePackageId)
                .Include(item => item.NursingCareAdditionalNeeds)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (nursingCarePackage == null)
            {
                throw new ApiException($"Could not find the Nursing Care Package {nursingCarePackageId}");
            }

            var costOfCare = Math.Round(await _databaseContext.NursingCareBrokerageInfos
                .DefaultIfEmpty()
                .AverageAsync(nc => nc == null ? 0 : nc.NursingCore)
                .ConfigureAwait(false), 2);

            var costOfAdditionalNeeds = Math.Round(await _databaseContext.NursingCareAdditionalNeedsCosts
                .Where(item => item.AdditionalNeedsPaymentTypeId == AdditionalNeedPaymentTypesConstants.WeeklyCost)
                .DefaultIfEmpty()
                .AverageAsync(nc => nc == null ? 0 : nc.AdditionalNeedsCost)
                .ConfigureAwait(false), 2);

            var costOfOneOff = Math.Round(await _databaseContext.NursingCareAdditionalNeedsCosts
                .Where(item => item.AdditionalNeedsPaymentTypeId == AdditionalNeedPaymentTypesConstants.OneOff)
                .DefaultIfEmpty()
                .AverageAsync(nc => nc == null ? 0 : nc.AdditionalNeedsCost)
                .ConfigureAwait(false), 2);

            var nursingCareApprovePackageDomain = new NursingCareApprovePackageDomain()
            {
                NursingCarePackage = nursingCarePackage.ToDomain(),
                CostOfCare = costOfCare,
                CostOfAdditionalNeeds = costOfAdditionalNeeds,
                CostOfOneOff = costOfOneOff,
                TotalPerWeek = costOfCare + costOfAdditionalNeeds
            };

            return nursingCareApprovePackageDomain;
        }
    }
}
