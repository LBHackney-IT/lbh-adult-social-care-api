using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareApproveCommercialDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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
                throw new ApiException($"Could not find the Nursing Care Package {nursingCarePackageId}");
            }

            var nursingCareApproveCommercialDomain = new NursingCareApproveCommercialDomain()
            {
                NursingCarePackage = nursingCarePackage.ToDomain(),
                CostOfCare = 0,
                CostOfAdditionalNeeds = 0,
                TotalPerWeek = 0
            };

            return nursingCareApproveCommercialDomain;
        }
    }
}
