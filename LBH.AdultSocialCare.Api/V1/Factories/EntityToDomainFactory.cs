using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.DayCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Domain.OpportunityLengthOptionDomains;
using LBH.AdultSocialCare.Api.V1.Domain.OpportunityTimesPerMonthOptionDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ReclaimsDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Domain.StageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.SupplierDomains;
using LBH.AdultSocialCare.Api.V1.Domain.TermTimeConsiderationOptionDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCarePackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCarePackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCarePackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.PackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCarePackageReclaims;
using System.Collections.Generic;
using System.Linq;

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

        #endregion DayCarePackage

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

        #endregion DayCarePackageOpportunity

        #region TermTimeConsiderationOptions

        public static IEnumerable<TermTimeConsiderationOptionDomain> ToDomain(
            this List<TermTimeConsiderationOption> termTimeConsiderationOptionEntities)
        {
            return _mapper.Map<IEnumerable<TermTimeConsiderationOptionDomain>>(termTimeConsiderationOptionEntities);
        }

        #endregion TermTimeConsiderationOptions

        #region OpportunityLengthOptions

        public static IEnumerable<OpportunityLengthOptionDomain> ToDomain(
            this List<OpportunityLengthOption> opportunityLengthOptionEntities)
        {
            return _mapper.Map<IEnumerable<OpportunityLengthOptionDomain>>(opportunityLengthOptionEntities);
        }

        #endregion OpportunityLengthOptions

        #region OpportunityTimesPerMonthOptions

        public static IEnumerable<OpportunityTimesPerMonthOptionDomain> ToDomain(
            this List<OpportunityTimesPerMonthOption> opportunityTimesPerMonthOptionEntities)
        {
            return _mapper.Map<IEnumerable<OpportunityTimesPerMonthOptionDomain>>(opportunityTimesPerMonthOptionEntities);
        }

        #endregion OpportunityTimesPerMonthOptions

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
                ClientName = nursingCarePackageEntity.Client != null ? $"{nursingCarePackageEntity.Client.FirstName} {nursingCarePackageEntity.Client.MiddleName} {nursingCarePackageEntity.Client.LastName}" : null,
                StatusName = nursingCarePackageEntity.Status?.StatusName,
                CreatorName = nursingCarePackageEntity.Creator != null ? $"{nursingCarePackageEntity.Creator.FirstName} {nursingCarePackageEntity.Creator.MiddleName} {nursingCarePackageEntity.Creator.LastName}" : null,
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

        #endregion NursingCarePackage

        #region NursingCareAdditionalNeed

        public static IEnumerable<NursingCareAdditionalNeedsDomain> ToDomain(this ICollection<NursingCareAdditionalNeed> nursingCareAdditionalNeedsEntities)
        {
            return _mapper.Map<IEnumerable<NursingCareAdditionalNeedsDomain>>(nursingCareAdditionalNeedsEntities);
        }

        #endregion NursingCareAdditionalNeed

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

        #endregion TypeOfNursingCareHome

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

        #endregion NursingCareTypeOfStayOptions

        #region ResidentialCarePackage

        public static ResidentialCarePackageDomain ToDomain(this ResidentialCarePackage residentialCarePackageEntity)
        {
            return new ResidentialCarePackageDomain
            {
                Id = residentialCarePackageEntity.Id,
                ClientId = residentialCarePackageEntity.ClientId,
                IsFixedPeriod = residentialCarePackageEntity.IsFixedPeriod,
                StartDate = residentialCarePackageEntity.StartDate,
                EndDate = residentialCarePackageEntity.EndDate,
                HasRespiteCare = residentialCarePackageEntity.HasRespiteCare,
                HasDischargePackage = residentialCarePackageEntity.HasDischargePackage,
                IsThisAnImmediateService = residentialCarePackageEntity.IsThisAnImmediateService,
                IsThisUserUnderS117 = residentialCarePackageEntity.IsThisUserUnderS117,
                TypeOfStayId = residentialCarePackageEntity.TypeOfStayId,
                NeedToAddress = residentialCarePackageEntity.NeedToAddress,
                TypeOfResidentialCareHomeId = residentialCarePackageEntity.TypeOfResidentialCareHomeId,
                CreatorId = residentialCarePackageEntity.CreatorId,
                UpdaterId = residentialCarePackageEntity.UpdaterId,
                StatusId = residentialCarePackageEntity.StatusId,
                ClientName = residentialCarePackageEntity.Client != null ? $"{residentialCarePackageEntity.Client.FirstName} {residentialCarePackageEntity.Client.MiddleName} {residentialCarePackageEntity.Client.LastName}" : null,
                StatusName = residentialCarePackageEntity.Status?.StatusName,
                CreatorName = residentialCarePackageEntity.Creator != null ? $"{residentialCarePackageEntity.Creator.FirstName} {residentialCarePackageEntity.Creator.MiddleName} {residentialCarePackageEntity.Creator.LastName}" : null,
                UpdaterName = residentialCarePackageEntity.Updater != null ? $"{residentialCarePackageEntity.Updater.FirstName} {residentialCarePackageEntity.Updater.MiddleName} {residentialCarePackageEntity.Updater.LastName}" : null,
                PackageName = "Residential Care Package",
                TypeOfCareHomeName = residentialCarePackageEntity.TypeOfCareHome?.TypeOfCareHomeName,
                TypeOfStayOptionName = residentialCarePackageEntity.TypeOfStayOption?.OptionName,
                ResidentialCareAdditionalNeeds = residentialCarePackageEntity.ResidentialCareAdditionalNeeds.ToDomain()
            };
        }

        public static IEnumerable<ResidentialCarePackageDomain> ToDomain(this List<ResidentialCarePackage> nursingCarePackageEntities)
        {
            return nursingCarePackageEntities.Select(entity => entity.ToDomain()).ToList();
        }

        #endregion ResidentialCarePackage

        #region ResidentialCareAdditionalNeed

        public static IEnumerable<ResidentialCareAdditionalNeedsDomain> ToDomain(this ICollection<ResidentialCareAdditionalNeed> residentialCareAdditionalNeedsEntities)
        {
            return _mapper.Map<IEnumerable<ResidentialCareAdditionalNeedsDomain>>(residentialCareAdditionalNeedsEntities);
        }

        #endregion ResidentialCareAdditionalNeed

        #region TypeOfResidentialCareHome

        public static IEnumerable<TypeOfResidentialCareHomeDomain> ToDomain(this ICollection<TypeOfResidentialCareHome> typeOfResidentialCareHome)
        {
            return typeOfResidentialCareHome.Select(item
                => new TypeOfResidentialCareHomeDomain
                {
                    TypeOfCareHomeId = item.TypeOfCareHomeId,
                    TypeOfCareHomeName = item.TypeOfCareHomeName
                }).ToList();
        }

        #endregion TypeOfResidentialCareHome

        #region ResidentialCareTypeOfStayOptions

        public static IEnumerable<ResidentialCareTypeOfStayOptionDomain> ToDomain(this ICollection<ResidentialCareTypeOfStayOption> residentialCareTypeOfStayOptions)
        {
            return residentialCareTypeOfStayOptions.Select(item
                => new ResidentialCareTypeOfStayOptionDomain
                {
                    TypeOfStayOptionId = item.TypeOfStayOptionId,
                    OptionName = item.OptionName,
                    OptionPeriod = item.OptionPeriod
                }).ToList();
        }

        #endregion ResidentialCareTypeOfStayOptions

        #region Supplier

        public static SupplierDomain ToDomain(this Supplier supplierEntity)
        {
            return _mapper.Map<SupplierDomain>(supplierEntity);
        }

        public static IEnumerable<SupplierDomain> ToDomain(this List<Supplier> supplierEntities)
        {
            return _mapper.Map<IEnumerable<SupplierDomain>>(supplierEntities);
        }

        public static IEnumerable<HomeCareSupplierCostDomain> ToDomain(
            this List<HomeCareSupplierCost> homeCareSupplierCostEntities)
        {
            return _mapper.Map<IEnumerable<HomeCareSupplierCostDomain>>(homeCareSupplierCostEntities);
        }

        #endregion Supplier

        #region HomeCareBrokerage

        public static IEnumerable<StageDomain> ToDomain(this List<Stage> homeCareStageEntities)
        {
            return _mapper.Map<IEnumerable<StageDomain>>(homeCareStageEntities);
        }

        public static HomeCarePackageCostDomain ToDomain(this HomeCarePackageCost homeCarePackageCostEntity)
        {
            return _mapper.Map<HomeCarePackageCostDomain>(homeCarePackageCostEntity);
        }

        public static HomeCarePackageDomain ToDomain(this HomeCarePackage homeCarePackageEntity)
        {
            return _mapper.Map<HomeCarePackageDomain>(homeCarePackageEntity);
        }

        public static IEnumerable<HomeCarePackageCostDomain> ToDomain(this List<HomeCarePackageCost> homeCarePackageCostEntities)
        {
            return _mapper.Map<IEnumerable<HomeCarePackageCostDomain>>(homeCarePackageCostEntities);
        }

        public static IEnumerable<HomeCareApprovalHistoryDomain> ToDomain(
            this List<HomeCareApprovalHistory> homeCareApprovalHistoryEntities)
        {
            return _mapper.Map<IEnumerable<HomeCareApprovalHistoryDomain>>(homeCareApprovalHistoryEntities);
        }

        #endregion HomeCareBrokerage

        #region NursingCareBrokerage

        public static IEnumerable<NursingCareApprovalHistoryDomain> ToDomain(
            this List<NursingCareApprovalHistory> nursingCareApprovalHistoryEntities)
        {
            return _mapper.Map<IEnumerable<NursingCareApprovalHistoryDomain>>(nursingCareApprovalHistoryEntities);
        }

        #endregion NursingCareBrokerage

        #region ResidentialCareBrokerage

        public static IEnumerable<ResidentialCareApprovalHistoryDomain> ToDomain(
            this List<ResidentialCareApprovalHistory> residentialCareApprovalHistoryEntities)
        {
            return _mapper.Map<IEnumerable<ResidentialCareApprovalHistoryDomain>>(residentialCareApprovalHistoryEntities);
        }

        #endregion ResidentialCareBrokerage

        #region DayCareCollege

        public static DayCareCollegeDomain ToDomain(this DayCareCollege dayCareCollegeEntity)
        {
            return _mapper.Map<DayCareCollegeDomain>(dayCareCollegeEntity);
        }

        public static IEnumerable<DayCareCollegeDomain> ToDomain(this List<DayCareCollege> dayCareCollegeEntities)
        {
            return _mapper.Map<IEnumerable<DayCareCollegeDomain>>(dayCareCollegeEntities);
        }

        #endregion DayCareCollege

        #region PackageReclaim

        public static HomeCarePackageClaimDomain ToDomain(this HomeCarePackageReclaim homeCarePackageReclaim)
        {
            return _mapper.Map<HomeCarePackageClaimDomain>(homeCarePackageReclaim);
        }

        public static IEnumerable<ReclaimAmountOptionDomain> ToDomain(this ICollection<ReclaimAmountOption> reclaimAmountOptions)
        {
            return reclaimAmountOptions.Select(item
                => new ReclaimAmountOptionDomain
                {
                    AmountOptionId = item.AmountOptionId,
                    AmountOptionName = item.AmountOptionName
                }).ToList();
        }

        public static IEnumerable<ReclaimCategoryDomain> ToDomain(this ICollection<ReclaimCategory> reclaimCategories)
        {
            return reclaimCategories.Select(item
                => new ReclaimCategoryDomain
                {
                    ReclaimCategoryId = item.ReclaimCategoryId,
                    ReclaimCategoryName = item.ReclaimCategoryName
                }).ToList();
        }

        public static IEnumerable<ReclaimFromDomain> ToDomain(this ICollection<ReclaimFrom> reclaimFroms)
        {
            return reclaimFroms.Select(item
                => new ReclaimFromDomain
                {
                    ReclaimFromId = item.ReclaimFromId,
                    ReclaimFromName = item.ReclaimFromName
                }).ToList();
        }

        public static DayCarePackageClaimDomain ToDomain(this DayCarePackageReclaim dayCarePackageReclaim)
        {
            return _mapper.Map<DayCarePackageClaimDomain>(dayCarePackageReclaim);
        }

        public static NursingCarePackageClaimDomain ToDomain(this NursingCarePackageReclaim nursingCarePackageReclaim)
        {
            return _mapper.Map<NursingCarePackageClaimDomain>(nursingCarePackageReclaim);
        }

        public static ResidentialCarePackageClaimDomain ToDomain(this ResidentialCarePackageReclaim residentialCarePackageReclaim)
        {
            return _mapper.Map<ResidentialCarePackageClaimDomain>(residentialCarePackageReclaim);
        }

        #endregion PackageReclaim

        #region DayCareBrokerage

        public static DayCareBrokerageInfoDomain ToDomain(this DayCareBrokerageInfo dayCareBrokerageInfoEntity)
        {
            return _mapper.Map<DayCareBrokerageInfoDomain>(dayCareBrokerageInfoEntity);
        }

        #endregion DayCareBrokerage

        #region HomeCare

        public static IList<HomeCarePackageDomain> ToDomain(this IList<HomeCarePackage> homeCarePackagesEntity)
        {
            return _mapper.Map<IList<HomeCarePackageDomain>>(homeCarePackagesEntity);
        }

        #endregion HomeCare

        #region Clients

        public static ClientsDomain ToDomain(this Client clientEntity)
        {
            return new ClientsDomain
            {
                Id = clientEntity.Id,
                FirstName = clientEntity.FirstName,
                MiddleName = clientEntity.MiddleName,
                LastName = clientEntity.LastName,
                DateOfBirth = clientEntity.DateOfBirth,
                HackneyId = clientEntity.HackneyId,
                AddressLine1 = clientEntity.AddressLine1,
                AddressLine2 = clientEntity.AddressLine2,
                AddressLine3 = clientEntity.AddressLine3,
                Town = clientEntity.Town,
                County = clientEntity.County,
                PostCode = clientEntity.PostCode,
                CreatorId = clientEntity.CreatorId,
                DateCreated = clientEntity.DateCreated,
                UpdatorId = clientEntity.UpdatorId,
                DateUpdated = clientEntity.DateUpdated
            };
        }

        #endregion Clients

        #region NursingCareAdditionalNeeds

        public static NursingCareAdditionalNeedsDomain ToDomain(this NursingCareAdditionalNeed nursingCareAdditionalNeedEntity)
        {
            return new NursingCareAdditionalNeedsDomain
            {
                Id = nursingCareAdditionalNeedEntity.Id,
                NursingCarePackageId = nursingCareAdditionalNeedEntity.NursingCarePackageId,
                IsWeeklyCost = nursingCareAdditionalNeedEntity.IsWeeklyCost,
                IsOneOffCost = nursingCareAdditionalNeedEntity.IsOneOffCost,
                NeedToAddress = nursingCareAdditionalNeedEntity.NeedToAddress,
                CreatorId = nursingCareAdditionalNeedEntity.CreatorId,
                UpdaterId = nursingCareAdditionalNeedEntity.UpdaterId,
            };
        }

        #endregion NursingCareAdditionalNeeds

        #region Packages

        public static PackageDomain ToDomain(this Package packageEntity)
        {
            return new PackageDomain
            {
                Id = packageEntity.Id,
                PackageType = packageEntity.PackageType,
                Sequence = packageEntity.Sequence,
                CreatorId = packageEntity.CreatorId,
                DateCreated = packageEntity.DateCreated,
                UpdatorId = packageEntity.UpdatorId,
                DateUpdated = packageEntity.DateUpdated
            };
        }

        #endregion Packages

        #region ResidentialCareAdditionalNeeds

        public static ResidentialCareAdditionalNeedsDomain ToDomain(this ResidentialCareAdditionalNeed residentialCareAdditionalNeedEntity)
        {
            return new ResidentialCareAdditionalNeedsDomain
            {
                Id = residentialCareAdditionalNeedEntity.Id,
                ResidentialCarePackageId = residentialCareAdditionalNeedEntity.ResidentialCarePackageId,
                IsWeeklyCost = residentialCareAdditionalNeedEntity.IsWeeklyCost,
                IsOneOffCost = residentialCareAdditionalNeedEntity.IsOneOffCost,
                NeedToAddress = residentialCareAdditionalNeedEntity.NeedToAddress,
                CreatorId = residentialCareAdditionalNeedEntity.CreatorId,
                UpdatorId = residentialCareAdditionalNeedEntity.UpdaterId,
            };
        }

        #endregion ResidentialCareAdditionalNeeds

        #region ResidentialCarePackage

        public static IList<ResidentialCarePackageForCreationDomain> ToDomain(this IList<ResidentialCarePackage> residentialCarePackagesEntity)
        {
            return _mapper.Map<IList<ResidentialCarePackageForCreationDomain>>(residentialCarePackagesEntity);
        }

        public static IList<TypeOfResidentialCareHomeDomain> ToDomain(this IList<TypeOfResidentialCareHome> typeOfResidentialCareHomes)
        {
            return typeOfResidentialCareHomes.Select(item
                => new TypeOfResidentialCareHomeDomain
                {
                    TypeOfCareHomeId = item.TypeOfCareHomeId,
                    TypeOfCareHomeName = item.TypeOfCareHomeName
                }).ToList();
        }

        #endregion ResidentialCarePackage

        #region Roles

        public static RolesDomain ToDomain(this Role roleEntity)
        {
            return new RolesDomain
            {
                Id = roleEntity.Id,
                RoleName = roleEntity.RoleName,
                IsDefault = roleEntity.IsDefault,
                Sequence = roleEntity.Sequence,
                CreatorId = roleEntity.CreatorId,
                DateCreated = roleEntity.DateCreated,
                UpdatorId = roleEntity.UpdatorId,
                DateUpdated = roleEntity.DateUpdated
            };
        }

        #endregion Roles

        #region HomeCareServiceTypes

        public static HomeCareServiceDomain ToDomain(this HomeCareServiceType serviceEntity)
        {
            return new HomeCareServiceDomain
            {
                Id = serviceEntity.Id,
                ServiceName = serviceEntity.ServiceName,
                CreatorId = serviceEntity.CreatorId,
                DateCreated = serviceEntity.DateCreated,
                UpdatorId = serviceEntity.UpdatorId,
                DateUpdated = serviceEntity.DateUpdated
            };
        }

        #endregion HomeCareServiceTypes

        #region Users

        public static UsersDomain ToDomain(this User userEntity)
        {
            return new UsersDomain
            {
                Id = userEntity.Id,
                FirstName = userEntity.FirstName,
                MiddleName = userEntity.MiddleName,
                LastName = userEntity.LastName,
                HackneyId = userEntity.HackneyId,
                AddressLine1 = userEntity.AddressLine1,
                AddressLine2 = userEntity.AddressLine2,
                AddressLine3 = userEntity.AddressLine3,
                Town = userEntity.Town,
                County = userEntity.County,
                PostCode = userEntity.PostCode,
                RoleId = userEntity.RoleId,
                Role = userEntity.Role,
                CreatorId = userEntity.CreatorId,
                DateCreated = userEntity.DateCreated,
                UpdatorId = userEntity.UpdatorId,
                DateUpdated = userEntity.DateUpdated
            };
        }

        #endregion Users
    }
}
