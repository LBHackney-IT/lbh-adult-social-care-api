using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareApprovePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareApprovePackageDomains;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

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
                throw new ErrorException($"Could not find the Nursing Care Package {nursingCarePackageId}");
            }

            var nursingCareApprovePackageDomain = new NursingCareApprovePackageDomain()
            {
                NursingCarePackage = nursingCarePackage.ToDomain(),
                CostOfCare = 1000,
                CostOfAdditionalNeeds = 200,
                CostOfOneOff = 300,
                TotalPerWeek = 500
            };

            return nursingCareApprovePackageDomain;
        }
    }
}
