using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCarePackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCarePackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCarePackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCarePackageReclaims;
using System.Collections.Generic;
using System.Linq;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    // public interface IDto { }

    public static class DomainToEntityFactory
    {
        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        /*public static T MapTo<T>(this IDto dto)
        {
            return _mapper.Map<T>(dto);
        }*/

        #region HomeCarePackage

        public static HomeCareApprovalHistory ToDb(this HomeCareApprovalHistoryDomain homeCareApprovalHistoryDomain)
        {
            return _mapper.Map<HomeCareApprovalHistory>(homeCareApprovalHistoryDomain);
        }

        #endregion HomeCarePackage

        #region DayCarePackage

        public static DayCarePackage ToDb(this DayCarePackageForCreationDomain dayCarePackageForCreationDomain)
        {
            return _mapper.Map<DayCarePackage>(dayCarePackageForCreationDomain);
        }

        public static DayCarePackageOpportunity ToDb(this DayCarePackageOpportunityForCreationDomain dayCarePackageOpportunityForCreationDomain)
        {
            return _mapper.Map<DayCarePackageOpportunity>(dayCarePackageOpportunityForCreationDomain);
        }

        public static DayCareApprovalHistory ToDb(this DayCareApprovalHistoryForCreationDomain dayCareApprovalHistoryForCreationDomain)
        {
            return _mapper.Map<DayCareApprovalHistory>(dayCareApprovalHistoryForCreationDomain);
        }

        public static EscortPackage ToEscortPackage(this DayCarePackageDomain dayCarePackageDomain)
        {
            return _mapper.Map<EscortPackage>(dayCarePackageDomain);
        }

        public static TransportPackage ToTransportPackage(this DayCarePackageDomain dayCarePackageDomain)
        {
            return _mapper.Map<TransportPackage>(dayCarePackageDomain);
        }

        public static TransportEscortPackage ToTransportEscortPackage(this DayCarePackageDomain dayCarePackageDomain)
        {
            return _mapper.Map<TransportEscortPackage>(dayCarePackageDomain);
        }

        #endregion DayCarePackage

        #region NursingCarePackage

        public static NursingCarePackage ToDb(this NursingCarePackageForCreationDomain nursingCarePackageForCreationDomain)
        {
            return _mapper.Map<NursingCarePackage>(nursingCarePackageForCreationDomain);
        }

        public static NursingCareApprovalHistory ToDb(this NursingCareApprovalHistoryDomain nursingCareApprovalHistoryDomain)
        {
            return _mapper.Map<NursingCareApprovalHistory>(nursingCareApprovalHistoryDomain);
        }

        #endregion NursingCarePackage

        #region ResidentialCarePackage

        public static ResidentialCarePackage ToDb(this ResidentialCarePackageForCreationDomain residentialCarePackageForCreationDomain)
        {
            return _mapper.Map<ResidentialCarePackage>(residentialCarePackageForCreationDomain);
        }

        public static ResidentialCareApprovalHistory ToDb(this ResidentialCareApprovalHistoryDomain residentialCareApprovalHistory)
        {
            return _mapper.Map<ResidentialCareApprovalHistory>(residentialCareApprovalHistory);
        }

        #endregion ResidentialCarePackage

        #region Supplier

        public static Supplier ToDb(this SupplierCreationDomain supplierCreationDomain)
        {
            return _mapper.Map<Supplier>(supplierCreationDomain);
        }

        public static List<HomeCareSupplierCost> ToDb(
            this IEnumerable<HomeCareSupplierCostDomain> homeCareSupplierCostDomain)
        {
            return _mapper.Map<List<HomeCareSupplierCost>>(homeCareSupplierCostDomain);
        }

        public static List<HomeCareSupplierCost> ToDb(
            this IEnumerable<HomeCareSupplierCostCreationDomain> homeCareSupplierCostDomain)
        {
            return _mapper.Map<List<HomeCareSupplierCost>>(homeCareSupplierCostDomain);
        }

        #endregion Supplier

        #region HomeCareBrokerage

        public static HomeCarePackageCost ToDb(this HomeCareBrokerageCreationDomain supplierCreationDomain)
        {
            return _mapper.Map<HomeCarePackageCost>(supplierCreationDomain);
        }

        public static HomeCareRequestMoreInformation ToDb(this HomeCareRequestMoreInformationDomain homeCareRequestMoreInformationDomain)
        {
            return _mapper.Map<HomeCareRequestMoreInformation>(homeCareRequestMoreInformationDomain);
        }

        #endregion HomeCareBrokerage

        #region DayCareCollege

        public static DayCareCollege ToDb(this DayCareCollegeForCreationDomain dayCareCollegeForCreationDomain)
        {
            return _mapper.Map<DayCareCollege>(dayCareCollegeForCreationDomain);
        }

        #endregion DayCareCollege

        #region DayCareBrokerage

        public static DayCareRequestMoreInformation ToDb(this DayCareRequestMoreInformationDomain dayCareRequestMoreInformationDomain)
        {
            return _mapper.Map<DayCareRequestMoreInformation>(dayCareRequestMoreInformationDomain);
        }

        public static DayCareBrokerageInfo ToDb(this DayCareBrokerageInfoForCreationDomain dayCareBrokerageInfoForCreationDomain)
        {
            return _mapper.Map<DayCareBrokerageInfo>(dayCareBrokerageInfoForCreationDomain);
        }

        public static DayCareBrokerageInfo ToDb(this DayCareBrokerageInfoDomain dayCareBrokerageInfoDomain)
        {
            return _mapper.Map<DayCareBrokerageInfo>(dayCareBrokerageInfoDomain);
        }

        #endregion DayCareBrokerage

        #region NursingCareBrokerage

        public static NursingCareRequestMoreInformation ToDb(this NursingCareRequestMoreInformationDomain nursingCareRequestMoreInformationDomain)
        {
            return _mapper.Map<NursingCareRequestMoreInformation>(nursingCareRequestMoreInformationDomain);
        }

        public static NursingCareBrokerageInfo ToDb(this NursingCareBrokerageInfoCreationDomain nursingCareBrokerageInfoCreationDomain)
        {
            return _mapper.Map<NursingCareBrokerageInfo>(nursingCareBrokerageInfoCreationDomain);
        }

        #endregion NursingCareBrokerage

        #region ResidentialCareBrokerage

        public static ResidentialCareRequestMoreInformation ToDb(this ResidentialCareRequestMoreInformationDomain residentialCareRequestMoreInformationDomain)
        {
            return _mapper.Map<ResidentialCareRequestMoreInformation>(residentialCareRequestMoreInformationDomain);
        }

        public static ResidentialCareBrokerageInfo ToDb(this ResidentialCareBrokerageForCreationDomain residentialCareBrokerageForCreationDomain)
        {
            return _mapper.Map<ResidentialCareBrokerageInfo>(residentialCareBrokerageForCreationDomain);
        }

        #endregion ResidentialCareBrokerage

        #region PackageReclaim

        public static HomeCarePackageReclaim ToDb(this HomeCarePackageClaimCreationDomain homeCarePackageClaimCreationDomain)
        {
            return _mapper.Map<HomeCarePackageReclaim>(homeCarePackageClaimCreationDomain);
        }

        public static IEnumerable<HomeCarePackageReclaim> ToDb(this IEnumerable<HomeCarePackageClaimCreationDomain> homeCarePackageClaimsCreationDomain)
        {
            return _mapper.Map<IEnumerable<HomeCarePackageReclaim>>(homeCarePackageClaimsCreationDomain);
        }

        public static DayCarePackageReclaim ToDb(this DayCarePackageClaimCreationDomain dayCarePackageClaimCreationDomain)
        {
            return _mapper.Map<DayCarePackageReclaim>(dayCarePackageClaimCreationDomain);
        }

        public static NursingCarePackageReclaim ToDb(this NursingCarePackageClaimCreationDomain nursingCarePackageClaimCreationDomain)
        {
            return _mapper.Map<NursingCarePackageReclaim>(nursingCarePackageClaimCreationDomain);
        }

        public static ResidentialCarePackageReclaim ToDb(this ResidentialCarePackageClaimCreationDomain residentialCarePackageClaimCreationDomain)
        {
            return _mapper.Map<ResidentialCarePackageReclaim>(residentialCarePackageClaimCreationDomain);
        }

        #endregion PackageReclaim

        #region HomeCare

        public static HomeCarePackage ToEntity(this HomeCarePackageDomain homeCarePackageDomain)
        {
            return new HomeCarePackage
            {
                Id = homeCarePackageDomain.Id,
                ClientId = homeCarePackageDomain.ClientId,
                Client = homeCarePackageDomain.Client,
                StartDate = homeCarePackageDomain.StartDate,
                EndDate = homeCarePackageDomain.EndDate,
                IsFixedPeriod = homeCarePackageDomain.IsFixedPeriod,
                IsOngoingPeriod = homeCarePackageDomain.IsOngoingPeriod,
                IsThisAnImmediateService = homeCarePackageDomain.IsThisAnImmediateService,
                IsThisuserUnderS117 = homeCarePackageDomain.IsThisuserUnderS117,
                CreatorId = homeCarePackageDomain.CreatorId,
                UpdaterId = homeCarePackageDomain.UpdaterId,
                StatusId = homeCarePackageDomain.StatusId,
                Status = homeCarePackageDomain.Status,
                StageId = homeCarePackageDomain.StageId,
                SupplierId = homeCarePackageDomain.SupplierId,
                PackageReclaims = homeCarePackageDomain.PackageReclaims.ToDb().ToList()
            };
        }

        #endregion HomeCare

        #region Clients

        public static Client ToEntity(this ClientsDomain clientsDomain)
        {
            return new Client
            {
                Id = clientsDomain.Id,
                FirstName = clientsDomain.FirstName,
                MiddleName = clientsDomain.MiddleName,
                LastName = clientsDomain.LastName,
                DateOfBirth = clientsDomain.DateOfBirth,
                HackneyId = clientsDomain.HackneyId,
                AddressLine1 = clientsDomain.AddressLine1,
                AddressLine2 = clientsDomain.AddressLine2,
                AddressLine3 = clientsDomain.AddressLine3,
                Town = clientsDomain.Town,
                County = clientsDomain.County,
                PostCode = clientsDomain.PostCode,
                CreatorId = clientsDomain.CreatorId,
                UpdaterId = clientsDomain.UpdaterId
            };
        }

        #endregion Clients

        #region NursingCareAdditionalNeeds

        public static NursingCareAdditionalNeed ToEntity(this NursingCareAdditionalNeedsDomain nursingCareAdditionalNeedsDomain)
        {
            return new NursingCareAdditionalNeed
            {
                Id = nursingCareAdditionalNeedsDomain.Id,
                NursingCarePackageId = nursingCareAdditionalNeedsDomain.NursingCarePackageId,
                AdditionalNeedsPaymentTypeId = nursingCareAdditionalNeedsDomain.AdditionalNeedsPaymentTypeId,
                NeedToAddress = nursingCareAdditionalNeedsDomain.NeedToAddress,
                CreatorId = nursingCareAdditionalNeedsDomain.CreatorId,
                UpdaterId = nursingCareAdditionalNeedsDomain.UpdaterId,
            };
        }

        #endregion NursingCareAdditionalNeeds

        #region Packages

        public static Package ToEntity(this PackageDomain packageDomain)
        {
            return new Package
            {
                Id = packageDomain.Id,
                PackageType = packageDomain.PackageType,
                Sequence = packageDomain.Sequence,
                CreatorId = packageDomain.CreatorId,
                UpdaterId = packageDomain.UpdaterId
            };
        }

        #endregion Packages

        #region ResidentialCareAdditionalNeeds

        public static ResidentialCareAdditionalNeed ToEntity(this ResidentialCareAdditionalNeedsDomain residentialCareAdditionalNeedsDomain)
        {
            return new ResidentialCareAdditionalNeed
            {
                Id = residentialCareAdditionalNeedsDomain.Id,
                ResidentialCarePackageId = residentialCareAdditionalNeedsDomain.ResidentialCarePackageId,
                AdditionalNeedsPaymentTypeId = residentialCareAdditionalNeedsDomain.AdditionalNeedsPaymentTypeId,
                NeedToAddress = residentialCareAdditionalNeedsDomain.NeedToAddress,
                CreatorId = residentialCareAdditionalNeedsDomain.CreatorId,
                UpdaterId = residentialCareAdditionalNeedsDomain.UpdatorId,
            };
        }

        #endregion ResidentialCareAdditionalNeeds

        #region Roles

        public static Role ToEntity(this RoleForCreationDomain rolesDomain)
        {
            return new Role
            {
                Name = rolesDomain.Name,
                NormalizedName = rolesDomain.Name.ToUpper()
            };
        }

        #endregion Roles

        #region HomeCareServiceTypes

        public static HomeCareServiceType ToEntity(this HomeCareServiceDomain homeCareServiceDomain)
        {
            return new HomeCareServiceType
            {
                Id = homeCareServiceDomain.Id,
                ServiceName = homeCareServiceDomain.ServiceName,
                CreatorId = homeCareServiceDomain.CreatorId,
                UpdaterId = homeCareServiceDomain.UpdaterId,
            };
        }

        #endregion HomeCareServiceTypes

        #region ServiceUsers

        public static User ToEntity(this UserForRegistrationDomain userForRegistrationDomain)
        {
            return new User
            {
                Email = userForRegistrationDomain.Email,
                EmailConfirmed = false,
                LockoutEnabled = false,
                NormalizedEmail = userForRegistrationDomain.Email.ToUpperInvariant(),
                NormalizedUserName = userForRegistrationDomain.Email.ToUpperInvariant(),
                PasswordHash = null,
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                UserName = userForRegistrationDomain.Email,
                Name = userForRegistrationDomain.Name
            };
        }

        #endregion ServiceUsers

        #region PackageStatus

        public static PackageStatus ToEntity(this StatusDomain statusDomain)
        {
            return new PackageStatus
            {
                Id = statusDomain.Id,
                StatusName = statusDomain.StatusName,
                CreatorId = statusDomain.CreatorId,
                UpdaterId = statusDomain.UpdaterId
            };
        }

        #endregion PackageStatus

        #region TimeSlotShifts

        public static TimeSlotShifts ToEntity(this TimeSlotShiftsDomain timeSlotShiftsDomain)
        {
            return new TimeSlotShifts
            {
                Id = timeSlotShiftsDomain.Id,
                TimeSlotShiftName = timeSlotShiftsDomain.TimeSlotShiftName,
                TimeSlotTimeLabel = timeSlotShiftsDomain.TimeSlotTimeLabel,
                CreatorId = timeSlotShiftsDomain.CreatorId,
                UpdaterId = timeSlotShiftsDomain.UpdaterId
            };
        }

        #endregion TimeSlotShifts

        #region Funded Nursing Care

        public static FundedNursingCare ToEntity(this FundedNursingCareDomain fundedNursingCareDomain)
        {
            return _mapper.Map<FundedNursingCare>(fundedNursingCareDomain);
        }

        #endregion

        #region Care Charge

        public static CareChargeElement ToEntity(this CareChargeElementPlainDomain careChargeElement)
        {
            return _mapper.Map<CareChargeElement>(careChargeElement);
        }

        #endregion Care Charge
    }
}
