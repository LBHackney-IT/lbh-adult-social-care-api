using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
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
                SupplierId = nursingCarePackageEntity.SupplierId,
                StageId = nursingCarePackageEntity.StageId,
                ClientName = nursingCarePackageEntity.Client != null ? $"{nursingCarePackageEntity.Client.FirstName} {nursingCarePackageEntity.Client.MiddleName} {nursingCarePackageEntity.Client.LastName}" : null,
                ClientHackneyId = nursingCarePackageEntity.Client?.HackneyId ?? 0,
                ClientPostCode = nursingCarePackageEntity.Client?.PostCode,
                ClientCanSpeakEnglish = nursingCarePackageEntity.Client?.CanSpeakEnglish,
                ClientPreferredContact = nursingCarePackageEntity.Client?.PreferredContact,
                ClientDateOfBirth = nursingCarePackageEntity.Client?.DateOfBirth,
                StatusName = nursingCarePackageEntity.Status?.StatusName,
                CreatorName = nursingCarePackageEntity.Creator != null ? $"{nursingCarePackageEntity.Creator.Name}" : null,
                UpdaterName = nursingCarePackageEntity.Updater != null ? $"{nursingCarePackageEntity.Updater.Name}" : null,
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

        public static NursingCarePackagePlainDomain ToPlainDomain(this NursingCarePackage nursingCarePackage)
        {
            return _mapper.Map<NursingCarePackagePlainDomain>(nursingCarePackage);
        }

        #endregion NursingCarePackage

        #region NursingCareAdditionalNeed

        public static IEnumerable<NursingCareAdditionalNeedsDomain> ToDomain(this ICollection<NursingCareAdditionalNeed> nursingCareAdditionalNeedsEntities)
        {
            return _mapper.Map<IEnumerable<NursingCareAdditionalNeedsDomain>>(nursingCareAdditionalNeedsEntities);
        }

        public static IEnumerable<TypeOfNursingCareHomeDomain> ToDomain(this ICollection<TypeOfNursingCareHome> typeOfNursingCareHome)
        {
            return typeOfNursingCareHome.Select(item
                => new TypeOfNursingCareHomeDomain
                {
                    TypeOfCareHomeId = item.TypeOfCareHomeId,
                    TypeOfCareHomeName = item.TypeOfCareHomeName
                }).ToList();
        }

        #endregion NursingCareAdditionalNeed

        #region TypeOfNursingCareHome

        public static IEnumerable<AdditionalNeedsPaymentTypeDomain> ToDomain(this ICollection<AdditionalNeedsPaymentType> additionalNeedsPaymentTypes)
        {
            return _mapper.Map<IEnumerable<AdditionalNeedsPaymentTypeDomain>>(additionalNeedsPaymentTypes);
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
                SupplierId = residentialCarePackageEntity.SupplierId,
                StageId = residentialCarePackageEntity.StageId,
                ClientName = residentialCarePackageEntity.Client != null ? $"{residentialCarePackageEntity.Client.FirstName} {residentialCarePackageEntity.Client.MiddleName} {residentialCarePackageEntity.Client.LastName}" : null,
                ClientHackneyId = residentialCarePackageEntity.Client?.HackneyId ?? 0,
                ClientPostCode = residentialCarePackageEntity.Client?.PostCode,
                ClientCanSpeakEnglish = residentialCarePackageEntity.Client?.CanSpeakEnglish,
                ClientPreferredContact = residentialCarePackageEntity.Client?.PreferredContact,
                ClientDateOfBirth = residentialCarePackageEntity.Client?.DateOfBirth,
                StatusName = residentialCarePackageEntity.Status?.StatusName,
                CreatorName = residentialCarePackageEntity.Creator != null ? $"{residentialCarePackageEntity.Creator.Name}" : null,
                UpdaterName = residentialCarePackageEntity.Updater != null ? $"{residentialCarePackageEntity.Updater.Name}" : null,
                PackageName = "Residential Care Package",
                TypeOfCareHomeName = residentialCarePackageEntity.TypeOfCareHome?.TypeOfCareHomeName,
                TypeOfStayOptionName = residentialCarePackageEntity.TypeOfStayOption?.OptionName,
                ResidentialCareAdditionalNeeds = residentialCarePackageEntity.ResidentialCareAdditionalNeeds.ToDomain()
            };
        }

        public static IEnumerable<ResidentialCarePackageDomain> ToDomain(this List<ResidentialCarePackage> residentialCarePackageEntities)
        {
            return residentialCarePackageEntities.Select(entity => entity.ToDomain()).ToList();
        }

        public static ResidentialCarePackagePlainDomain ToPlainDomain(this ResidentialCarePackage residentialCarePackage)
        {
            return _mapper.Map<ResidentialCarePackagePlainDomain>(residentialCarePackage);
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

        public static HomeCareApprovalHistoryDomain ToDomain(this HomeCareApprovalHistory homeCareApprovalHistory)
        {
            return _mapper.Map<HomeCareApprovalHistoryDomain>(homeCareApprovalHistory);
        }

        #endregion HomeCareBrokerage

        #region NursingCareBrokerage

        public static IEnumerable<NursingCareApprovalHistoryDomain> ToDomain(
            this List<NursingCareApprovalHistory> nursingCareApprovalHistoryEntities)
        {
            return _mapper.Map<IEnumerable<NursingCareApprovalHistoryDomain>>(nursingCareApprovalHistoryEntities);
        }

        public static NursingCareBrokerageInfoDomain ToDomain(this NursingCareBrokerageInfo nursingCareBrokerageInfoEntity)
        {
            return _mapper.Map<NursingCareBrokerageInfoDomain>(nursingCareBrokerageInfoEntity);
        }

        public static NursingCareApprovalHistoryDomain ToDomain(this NursingCareApprovalHistory nursingCareApprovalHistory)
        {
            return _mapper.Map<NursingCareApprovalHistoryDomain>(nursingCareApprovalHistory);
        }

        #endregion NursingCareBrokerage

        #region ResidentialCareBrokerage

        public static IEnumerable<ResidentialCareApprovalHistoryDomain> ToDomain(
            this List<ResidentialCareApprovalHistory> residentialCareApprovalHistoryEntities)
        {
            return _mapper.Map<IEnumerable<ResidentialCareApprovalHistoryDomain>>(residentialCareApprovalHistoryEntities);
        }

        public static ResidentialCareBrokerageInfoDomain ToDomain(this ResidentialCareBrokerageInfo residentialCareBrokerageInfoEntity)
        {
            return _mapper.Map<ResidentialCareBrokerageInfoDomain>(residentialCareBrokerageInfoEntity);
        }

        public static ResidentialCareApprovalHistoryDomain ToDomain(this ResidentialCareApprovalHistory residentialCareApprovalHistory)
        {
            return _mapper.Map<ResidentialCareApprovalHistoryDomain>(residentialCareApprovalHistory);
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
                UpdaterId = clientEntity.UpdaterId,
                DateUpdated = clientEntity.DateUpdated
            };
        }

        public static IEnumerable<ClientsDomain> ToDomain(this List<Client> clientEntities)
        {
            return _mapper.Map<IEnumerable<ClientsDomain>>(clientEntities);
        }

        #endregion Clients

        #region NursingCareAdditionalNeeds

        public static NursingCareAdditionalNeedsDomain ToDomain(this NursingCareAdditionalNeed nursingCareAdditionalNeedEntity)
        {
            return new NursingCareAdditionalNeedsDomain
            {
                Id = nursingCareAdditionalNeedEntity.Id,
                NursingCarePackageId = nursingCareAdditionalNeedEntity.NursingCarePackageId,
                AdditionalNeedsPaymentTypeId = nursingCareAdditionalNeedEntity.AdditionalNeedsPaymentTypeId,
                AdditionalNeedsPaymentTypeName = nursingCareAdditionalNeedEntity.AdditionalNeedsPaymentType.OptionName,
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
                UpdaterId = packageEntity.UpdaterId,
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
                AdditionalNeedsPaymentTypeId = residentialCareAdditionalNeedEntity.AdditionalNeedsPaymentTypeId,
                AdditionalNeedsPaymentTypeName = residentialCareAdditionalNeedEntity.AdditionalNeedsPaymentType.OptionName,
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
            return _mapper.Map<RolesDomain>(roleEntity);
        }

        public static IList<RolesDomain> ToDomain(this IEnumerable<Role> roleEntities)
        {
            return _mapper.Map<IList<RolesDomain>>(roleEntities);
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
                UpdaterId = serviceEntity.UpdaterId,
                DateUpdated = serviceEntity.DateUpdated
            };
        }

        #endregion HomeCareServiceTypes

        #region ServiceUsers

        public static UsersDomain ToDomain(this User userEntity)
        {
            return new UsersDomain
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email
            };
        }

        public static IEnumerable<UsersDomain> ToDomain(this List<User> users)
        {
            return _mapper.Map<IEnumerable<UsersDomain>>(users);
        }

        #endregion ServiceUsers

        #region PackageStatus

        public static StatusDomain ToDomain(this PackageStatus statusEntity)
        {
            return new StatusDomain
            {
                Id = statusEntity.Id,
                StatusName = statusEntity.StatusName,
                CreatorId = statusEntity.CreatorId,
                UpdaterId = statusEntity.UpdaterId
            };
        }

        public static IEnumerable<StatusDomain> ToDomain(this List<PackageStatus> packageStatus)
        {
            return _mapper.Map<IEnumerable<StatusDomain>>(packageStatus);
        }

        #endregion PackageStatus

        #region TimeSlotShifts

        public static TimeSlotShiftsDomain ToDomain(this TimeSlotShifts timeSlotShiftsEntity)
        {
            return new TimeSlotShiftsDomain
            {
                Id = timeSlotShiftsEntity.Id,
                TimeSlotShiftName = timeSlotShiftsEntity.TimeSlotShiftName,
                TimeSlotTimeLabel = timeSlotShiftsEntity.TimeSlotTimeLabel,
                CreatorId = timeSlotShiftsEntity.CreatorId,
                DateCreated = timeSlotShiftsEntity.DateCreated,
                UpdaterId = timeSlotShiftsEntity.UpdaterId,
                DateUpdated = timeSlotShiftsEntity.DateUpdated
            };
        }

        #endregion TimeSlotShifts

        #region PrimarySupportReason

        public static IEnumerable<PrimarySupportReasonDomain> ToDomain(this List<PrimarySupportReason> primarySupportReasons)
        {
            return _mapper.Map<IEnumerable<PrimarySupportReasonDomain>>(primarySupportReasons);
        }

        #endregion PrimarySupportReason

        #region FundedNursingCare

        public static IEnumerable<FundedNursingCareCollectorDomain> ToDomain(this List<FundedNursingCareCollector> collectors)
        {
            return _mapper.Map<IEnumerable<FundedNursingCareCollectorDomain>>(collectors);
        }

        public static FundedNursingCareDomain ToDomain(this FundedNursingCare fundedNursingCare)
        {
            return _mapper.Map<FundedNursingCareDomain>(fundedNursingCare);
        }

        public static FundedNursingCarePriceDomain ToDomain(this FundedNursingCarePrice fundedNursingCarePrice)
        {
            return _mapper.Map<FundedNursingCarePriceDomain>(fundedNursingCarePrice);
        }

        public static IEnumerable<FundedNursingCarePriceDomain> ToDomain(this IEnumerable<FundedNursingCarePrice> fundedNursingCarePrices)
        {
            return _mapper.Map<IEnumerable<FundedNursingCarePriceDomain>>(fundedNursingCarePrices);
        }

        #endregion FundedNursingCare

        #region CareCharges

        public static ProvisionalCareChargeAmountPlainDomain ToDomain(this ProvisionalCareChargeAmount provisionalCareCharge)
        {
            return _mapper.Map<ProvisionalCareChargeAmountPlainDomain>(provisionalCareCharge);
        }

        public static CareChargeElementPlainDomain ToPlainDomain(this CareChargeElement careChargeElement)
        {
            return _mapper.Map<CareChargeElementPlainDomain>(careChargeElement);
        }

        public static IEnumerable<CareChargeElementPlainDomain> ToPlainDomain(this IEnumerable<CareChargeElement> careChargeElements)
        {
            return _mapper.Map<IEnumerable<CareChargeElementPlainDomain>>(careChargeElements);
        }

        public static PackageCareChargePlainDomain ToPlainDomain(this PackageCareCharge packageCareCharge)
        {
            return _mapper.Map<PackageCareChargePlainDomain>(packageCareCharge);
        }

        public static InvoiceCreditNotePlainDomain ToPlainDomain(this InvoiceCreditNote invoiceCreditNote)
        {
            return _mapper.Map<InvoiceCreditNotePlainDomain>(invoiceCreditNote);
        }

        #endregion CareCharges
    }
}
