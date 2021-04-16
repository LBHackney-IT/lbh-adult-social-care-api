using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System.Collections.Generic;
using LBH.AdultSocialCare.Api.V1.Domain.OpportunityLengthOptionDomains;
using LBH.AdultSocialCare.Api.V1.Domain.OpportunityTimesPerMonthOptionDomains;
using LBH.AdultSocialCare.Api.V1.Domain.TermTimeConsiderationOptionDomains;

namespace LBH.AdultSocialCare.Api.V1.Factories
{

    public static class EntityToDomainFactory
    {

        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region DayCarePackage

        public static DayCarePackageDomain ToDomain(this DayCarePackage dayCarePackageEntity)
        {
            return _mapper.Map<DayCarePackageDomain>(dayCarePackageEntity);
        }

        public static IEnumerable<DayCarePackageDomain> ToDomain(this List<DayCarePackage> dayCarePackageEntities)
        {
            return _mapper.Map<IEnumerable<DayCarePackageDomain>>(dayCarePackageEntities);
        }

        #endregion

        #region DayCarePackageOpportunity

        public static DayCarePackageOpportunityDomain ToDomain(
            this DayCarePackageOpportunity dayCarePackageOpportunityEntity)
        {
            return _mapper.Map<DayCarePackageOpportunityDomain>(dayCarePackageOpportunityEntity);
        }

        public static IEnumerable<DayCarePackageOpportunityDomain> ToDomain(
            this List<DayCarePackageOpportunity> dayCarePackageOpportunityEntities)
        {
            return _mapper.Map<IEnumerable<DayCarePackageOpportunityDomain>>(dayCarePackageOpportunityEntities);
        }

        #endregion

        #region TermTimeConsiderationOptions

        public static IEnumerable<TermTimeConsiderationOptionDomain> ToDomain(
            this List<TermTimeConsiderationOption> termTimeConsiderationOptionEntities)
        {
            return _mapper.Map<IEnumerable<TermTimeConsiderationOptionDomain>>(termTimeConsiderationOptionEntities);
        }

        #endregion

        #region OpportunityLengthOptions

        public static IEnumerable<OpportunityLengthOptionDomain> ToDomain(
            this List<OpportunityLengthOption> opportunityLengthOptionEntities)
        {
            return _mapper.Map<IEnumerable<OpportunityLengthOptionDomain>>(opportunityLengthOptionEntities);
        }

        #endregion

        #region OpportunityTimesPerMonthOptions

        public static IEnumerable<OpportunityTimesPerMonthOptionDomain> ToDomain(
            this List<OpportunityTimesPerMonthOption> opportunityTimesPerMonthOptionEntities)
        {
            return _mapper.Map<IEnumerable<OpportunityTimesPerMonthOptionDomain>>(opportunityTimesPerMonthOptionEntities);
        }

        #endregion

    }

}
