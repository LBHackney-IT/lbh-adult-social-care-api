using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System.Collections.Generic;
using System.Linq;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.OpportunityLengthOptionDomains;
using LBH.AdultSocialCare.Api.V1.Domain.OpportunityTimesPerMonthOptionDomains;
using LBH.AdultSocialCare.Api.V1.Domain.TermTimeConsiderationOptionDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;

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


        #region NursingCarePackage

        public static NursingCarePackageDomain ToDomain(this NursingCarePackage nursingCarePackageEntity)
        {
            return new NursingCarePackageDomain
            {
                Id = nursingCarePackageEntity.Id,
                ClientId = nursingCarePackageEntity.ClientId,
                IsFixedPeriod = nursingCarePackageEntity.IsFixedPeriod,
                StartDate = nursingCarePackageEntity.StartDate,
                EndDate = nursingCarePackageEntity.EndDate,
                HasRespiteCare = nursingCarePackageEntity.HasRespiteCare,
                HasDischargePackage = nursingCarePackageEntity.HasDischargePackage,
                IsThisAnImmediateService = nursingCarePackageEntity.IsThisAnImmediateService,
                IsThisUserUnderS117 = nursingCarePackageEntity.IsThisUserUnderS117,
                TypeOfStayId = nursingCarePackageEntity.TypeOfStayId,
                NeedToAddress = nursingCarePackageEntity.NeedToAddress,
                TypeOfNursingCareHomeId = nursingCarePackageEntity.TypeOfNursingCareHomeId,
                CreatorId = nursingCarePackageEntity.CreatorId,
                UpdaterId = nursingCarePackageEntity.UpdaterId,
                StatusId = nursingCarePackageEntity.StatusId,
                ClientName = nursingCarePackageEntity.Client != null ? $"{nursingCarePackageEntity.Client.FirstName} {nursingCarePackageEntity.Client.MiddleName} {nursingCarePackageEntity.Client.LastName}": null,
                StatusName = nursingCarePackageEntity.Status?.StatusName,
                CreatorName = nursingCarePackageEntity.Creator != null ? $"{nursingCarePackageEntity.Creator.FirstName} {nursingCarePackageEntity.Creator.MiddleName} {nursingCarePackageEntity.Creator.LastName}": null,
                UpdaterName = nursingCarePackageEntity.Updater != null ? $"{nursingCarePackageEntity.Updater.FirstName} {nursingCarePackageEntity.Updater.MiddleName} {nursingCarePackageEntity.Updater.LastName}" : null,
                PackageName = "Nursing Care Package",
                TypeOfCareHomeName = nursingCarePackageEntity.TypeOfCareHome?.TypeOfCareHomeName,
                TypeOfStayOptionName = nursingCarePackageEntity.TypeOfStayOption?.OptionName,
                NursingCareAdditionalNeeds = nursingCarePackageEntity.NursingCareAdditionalNeeds.ToDomain()
            };
            // return _mapper.Map<NursingCarePackageDomain>(nursingCarePackageEntity);
        }

        public static IEnumerable<NursingCarePackageDomain> ToDomain(this List<NursingCarePackage> nursingCarePackageEntities)
        {
            return nursingCarePackageEntities.Select(entity => entity.ToDomain()).ToList();
        }

        #endregion

        #region NursingCareAdditionalNeed

        public static IEnumerable<NursingCareAdditionalNeedsDomain> ToDomain(this ICollection<NursingCareAdditionalNeed> nursingCareAdditionalNeedsEntities)
        {
            return _mapper.Map<IEnumerable<NursingCareAdditionalNeedsDomain>>(nursingCareAdditionalNeedsEntities);
        }

        #endregion

        #region TypeOfNursingCareHome

        public static IEnumerable<TypeOfNursingCareHomeDomain> ToDomain(this ICollection<TypeOfNursingCareHome> typeOfNursingCareHome)
        {
            return typeOfNursingCareHome.Select(item
                => new TypeOfNursingCareHomeDomain
                {
                    TypeOfCareHomeId = item.TypeOfCareHomeId,
                    TypeOfCareHomeName = item.TypeOfCareHomeName
                }).ToList();
        }

        #endregion

        #region NursingCareTypeOfStayOptions

        public static IEnumerable<NursingCareTypeOfStayOptionDomain> ToDomain(this ICollection<NursingCareTypeOfStayOption> nursingCareTypeOfStayOptions)
        {
            return nursingCareTypeOfStayOptions.Select(item
                => new NursingCareTypeOfStayOptionDomain
                {
                    TypeOfStayOptionId = item.TypeOfStayOptionId,
                    OptionName = item.OptionName,
                    OptionPeriod = item.OptionPeriod
                }).ToList();
        }

        #endregion



    }

}
