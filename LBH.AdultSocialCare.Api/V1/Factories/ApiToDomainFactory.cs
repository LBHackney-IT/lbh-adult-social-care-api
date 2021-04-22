using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageOpportunityBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareAdditionalNeedsBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class ApiToDomainFactory
    {
        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static DayCarePackageForCreationDomain ToDomain(this DayCarePackageForCreationRequest dayCarePackageForCreation)
        {
            var res = _mapper.Map<DayCarePackageForCreationDomain>(dayCarePackageForCreation);
            // Set status to 1 for new package
            if (res.StatusId == 0)
            {
                res.StatusId = 1;
            }
            // Set package id to 3 for day care package
            res.PackageId = 3;
            return res;
        }

        public static DayCarePackageForUpdateDomain ToDomain(this DayCarePackageForUpdateRequest dayCarePackageForUpdate)
        {
            return _mapper.Map<DayCarePackageForUpdateDomain>(dayCarePackageForUpdate);
        }

        public static DayCarePackageOpportunityForCreationDomain ToDomain(this DayCarePackageOpportunityForCreationRequest dayCarePackageOpportunityForCreation, Guid dayCarePackageId)
        {
            var domain = _mapper.Map<DayCarePackageOpportunityForCreationDomain>(dayCarePackageOpportunityForCreation);
            domain.DayCarePackageId = dayCarePackageId;
            return domain;
        }

        public static DayCarePackageOpportunityForUpdateDomain ToDomain(this DayCarePackageOpportunityForUpdateRequest dayCarePackageOpportunityForUpdate, Guid dayCarePackageId, Guid dayCarePackageOpportunityId)
        {
            var domain = _mapper.Map<DayCarePackageOpportunityForUpdateDomain>(dayCarePackageOpportunityForUpdate);
            domain.DayCarePackageId = dayCarePackageId;
            domain.DayCarePackageOpportunityId = dayCarePackageOpportunityId;
            return domain;
        }

        #region NursingCarePackage

        public static NursingCarePackageForUpdateDomain ToDomain(this NursingCarePackageForUpdateRequest nursingCarePackageForUpdate, Guid nursingCarePackageId)
        {
            var res = _mapper.Map<NursingCarePackageForUpdateDomain>(nursingCarePackageForUpdate);
            res.Id = nursingCarePackageId;
            return res;
        }

        public static NursingCarePackageForCreationDomain ToDomain(this NursingCarePackageForCreationRequest nursingCarePackageForCreation)
        {
            var res = _mapper.Map<NursingCarePackageForCreationDomain>(nursingCarePackageForCreation);
            // Set status to 1 for new package
            if (res.StatusId == 0)
            {
                res.StatusId = 1;
            }
            return res;
        }

        #endregion

        #region NursingCareAdditionalNeed

        public static IEnumerable<NursingCareAdditionalNeedsDomain> ToDomain(this IEnumerable<NursingCareAdditionalNeedForCreationRequest> nursingCareAdditionalNeedsForCreation)
        {
            return _mapper.Map<IEnumerable<NursingCareAdditionalNeedsDomain>>(nursingCareAdditionalNeedsForCreation);
        }

        #endregion
    }
}
