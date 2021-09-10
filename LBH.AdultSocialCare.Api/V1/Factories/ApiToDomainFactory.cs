using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Request;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Domain.Security;

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

        #endregion NursingCarePackage

        #region NursingCareAdditionalNeed

        public static IEnumerable<NursingCareAdditionalNeedsDomain> ToDomain(this IEnumerable<NursingCareAdditionalNeedForCreationRequest> nursingCareAdditionalNeedsForCreation)
        {
            return _mapper.Map<IEnumerable<NursingCareAdditionalNeedsDomain>>(nursingCareAdditionalNeedsForCreation);
        }

        #endregion NursingCareAdditionalNeed

        #region ResidentialCarePackage

        public static ResidentialCarePackageForUpdateDomain ToDomain(this ResidentialCarePackageForUpdateRequest residentialCarePackageForUpdate, Guid residentialCarePackageId)
        {
            var res = _mapper.Map<ResidentialCarePackageForUpdateDomain>(residentialCarePackageForUpdate);
            res.Id = residentialCarePackageId;
            return res;
        }

        public static ResidentialCarePackageForCreationDomain ToDomain(this ResidentialCarePackageForCreationRequest residentialCarePackageForCreation)
        {
            var res = _mapper.Map<ResidentialCarePackageForCreationDomain>(residentialCarePackageForCreation);
            // Set status to 1 for new package
            if (res.StatusId == 0)
            {
                res.StatusId = 1;
            }
            return res;
        }

        #endregion ResidentialCarePackage

        #region ResidentialCareAdditionalNeed

        public static IEnumerable<ResidentialCareAdditionalNeedsDomain> ToDomain(this IEnumerable<ResidentialCareAdditionalNeedForCreationRequest> residentialCareAdditionalNeedsForCreation)
        {
            return _mapper.Map<IEnumerable<ResidentialCareAdditionalNeedsDomain>>(residentialCareAdditionalNeedsForCreation);
        }

        #endregion ResidentialCareAdditionalNeed

        #region Supplier

        public static SupplierCreationDomain ToDomain(this SupplierCreationRequest supplierCreationRequest)
        {
            var res = _mapper.Map<SupplierCreationDomain>(supplierCreationRequest);
            return res;
        }

        public static IEnumerable<HomeCareSupplierCostCreationDomain> ToDomain(this IEnumerable<SupplierCostCreationRequest> supplierCostCreationRequests)
        {
            return _mapper.Map<IEnumerable<HomeCareSupplierCostCreationDomain>>(supplierCostCreationRequests);
        }

        #endregion Supplier

        #region HomeCareBrokerage

        public static HomeCareBrokerageCreationDomain ToDomain(this HomeCareBrokerageCreationRequest homeCareBrokerageCreationRequest)
        {
            var domain = _mapper.Map<HomeCareBrokerageCreationDomain>(homeCareBrokerageCreationRequest);
            return domain;
        }

        public static HomeCareRequestMoreInformationDomain ToDomain(this HomeCareRequestMoreInformationForCreationRequest homeCareRequestMoreInformationForCreationRequest)
        {
            var domain = _mapper.Map<HomeCareRequestMoreInformationDomain>(homeCareRequestMoreInformationForCreationRequest);
            return domain;
        }

        #endregion HomeCareBrokerage

        public static DayCareCollegeForCreationDomain ToDomain(this DayCareCollegeForCreationRequest dayCareCollegeForCreation)
        {
            var res = _mapper.Map<DayCareCollegeForCreationDomain>(dayCareCollegeForCreation);
            return res;
        }

        #region NursingCareBrokerage

        public static NursingCareRequestMoreInformationDomain ToDomain(this NursingCareRequestMoreInformationForCreationRequest nursingCareRequestMoreInformationForCreationRequest)
        {
            var domain = _mapper.Map<NursingCareRequestMoreInformationDomain>(nursingCareRequestMoreInformationForCreationRequest);
            return domain;
        }

        public static NursingCareBrokerageInfoCreationDomain ToDomain(this NursingCareBrokerageCreationRequest nursingCareBrokerageCreationRequest)
        {
            var domain = _mapper.Map<NursingCareBrokerageInfoCreationDomain>(nursingCareBrokerageCreationRequest);
            return domain;
        }

        #endregion NursingCareBrokerage

        #region ResidentialCareBrokerage

        public static ResidentialCareRequestMoreInformationDomain ToDomain(this ResidentialCareRequestMoreInformationForCreationRequest residentialCareRequestMoreInformationForCreationRequest)
        {
            var domain = _mapper.Map<ResidentialCareRequestMoreInformationDomain>(residentialCareRequestMoreInformationForCreationRequest);
            return domain;
        }

        public static ResidentialCareBrokerageForCreationDomain ToDomain(this ResidentialCareBrokerageForCreationRequest residentialCareBrokerageForCreationRequest)
        {
            var domain = _mapper.Map<ResidentialCareBrokerageForCreationDomain>(residentialCareBrokerageForCreationRequest);
            return domain;
        }

        #endregion ResidentialCareBrokerage

        #region DayCareBrokerage

        public static DayCareRequestMoreInformationDomain ToDomain(this DayCareRequestMoreInformationForCreationRequest dayCareRequestMoreInformationForCreationRequest)
        {
            var domain = _mapper.Map<DayCareRequestMoreInformationDomain>(dayCareRequestMoreInformationForCreationRequest);
            return domain;
        }

        public static DayCareBrokerageInfoForCreationDomain ToDomain(this DayCareBrokerageInfoForCreationRequest dayCareBrokerageInfoForCreationRequest, Guid dayCarePackageId)
        {
            var domain = _mapper.Map<DayCareBrokerageInfoForCreationDomain>(dayCareBrokerageInfoForCreationRequest);
            domain.DayCarePackageId = dayCarePackageId;
            return domain;
        }

        #endregion DayCareBrokerage

        #region PackageReclaim

        public static HomeCarePackageClaimCreationDomain ToDomain(this HomeCarePackageClaimCreationRequest homeCarePackageClaimCreationRequest)
        {
            var res = _mapper.Map<HomeCarePackageClaimCreationDomain>(homeCarePackageClaimCreationRequest);
            return res;
        }

        public static IEnumerable<HomeCarePackageClaimCreationDomain> ToDomain(this IEnumerable<HomeCarePackageClaimCreationRequest> homeCarePackageClaimsCreationRequest)
        {
            var res = _mapper.Map<IEnumerable<HomeCarePackageClaimCreationDomain>>(homeCarePackageClaimsCreationRequest);
            return res;
        }

        public static DayCarePackageClaimCreationDomain ToDomain(this DayCarePackageClaimCreationRequest dayCarePackageClaimCreationRequest)
        {
            var res = _mapper.Map<DayCarePackageClaimCreationDomain>(dayCarePackageClaimCreationRequest);
            return res;
        }

        public static NursingCarePackageClaimCreationDomain ToDomain(this NursingCarePackageClaimCreationRequest nursingCarePackageClaimCreationRequest)
        {
            var res = _mapper.Map<NursingCarePackageClaimCreationDomain>(nursingCarePackageClaimCreationRequest);
            return res;
        }

        public static ResidentialCarePackageClaimCreationDomain ToDomain(this ResidentialCarePackageClaimCreationRequest residentialCarePackageClaimCreationRequest)
        {
            var res = _mapper.Map<ResidentialCarePackageClaimCreationDomain>(residentialCarePackageClaimCreationRequest);
            return res;
        }

        #endregion PackageReclaim

        #region HomeCare

        public static HomeCarePackageDomain ToDomain(this HomeCarePackageRequest homeCarePackageEntity)
        {
            return new HomeCarePackageDomain
            {
                Id = homeCarePackageEntity.Id,
                ClientId = homeCarePackageEntity.ClientId,
                StartDate = homeCarePackageEntity.StartDate,
                EndDate = homeCarePackageEntity.EndDate,
                IsFixedPeriod = homeCarePackageEntity.IsFixedPeriod,
                IsOngoingPeriod = homeCarePackageEntity.IsOngoingPeriod,
                IsThisAnImmediateService = homeCarePackageEntity.IsThisAnImmediateService,
                IsThisuserUnderS117 = homeCarePackageEntity.IsThisClientUnderS117,
                StatusId = homeCarePackageEntity.StatusId,
                StageId = homeCarePackageEntity.StageId,
                SupplierId = homeCarePackageEntity.SupplierId,
                PackageReclaims = homeCarePackageEntity.PackageReclaims.ToDomain()
            };
        }

        public static HomeCarePackageSlotDomain ToDomain(this HomeCarePackageSlotRequest homeCarePackageSlotRequest)
        {
            var res = _mapper.Map<HomeCarePackageSlotDomain>(homeCarePackageSlotRequest);
            return res;
        }

        public static HomeCarePackageSlotListDomain ToDomain(this HomeCarePackageSlotsRequestList homeCarePackageSlotsRequestList)
        {
            // var res = _mapper.Map<HomeCarePackageSlotListDomain>(homeCarePackageSlotsRequestList);
            var res = new HomeCarePackageSlotListDomain
            {
                Id = default,
                HomeCarePackageId = homeCarePackageSlotsRequestList.HomeCarePackageId,
                HomeCarePackageSlots =
                    homeCarePackageSlotsRequestList.HomeCarePackageSlots.Select(opt => opt.ToDomain()).ToList()
            };

            return res;
        }

        #endregion HomeCare

        #region Clients

        public static ClientsDomain ToDomain(this ClientsRequest clientsEntity)
        {
            return new ClientsDomain
            {
                Id = clientsEntity.Id,
                FirstName = clientsEntity.FirstName,
                MiddleName = clientsEntity.MiddleName,
                LastName = clientsEntity.LastName,
                DateOfBirth = clientsEntity.DateOfBirth,
                HackneyId = clientsEntity.HackneyId,
                AddressLine1 = clientsEntity.AddressLine1,
                AddressLine2 = clientsEntity.AddressLine2,
                AddressLine3 = clientsEntity.AddressLine3,
                Town = clientsEntity.Town,
                County = clientsEntity.County,
                PostCode = clientsEntity.PostCode,
                DateCreated = clientsEntity.DateCreated,
                DateUpdated = clientsEntity.DateUpdated
            };
        }

        #endregion Clients

        #region NursingCareAdditionalNeeds

        public static NursingCareAdditionalNeedsDomain ToDomain(this NursingCareAdditionalNeedsRequest nursingCareAdditionalNeedsEntity)
        {
            return new NursingCareAdditionalNeedsDomain
            {
                Id = nursingCareAdditionalNeedsEntity.Id,
                NursingCarePackageId = nursingCareAdditionalNeedsEntity.NursingCarePackageId,
                AdditionalNeedsPaymentTypeId = nursingCareAdditionalNeedsEntity.AdditionalNeedsPaymentTypeId,
                NeedToAddress = nursingCareAdditionalNeedsEntity.NeedToAddress,
            };
        }

        #endregion NursingCareAdditionalNeeds

        #region Packages

        public static PackageDomain ToDomain(this PackageRequest packageEntity)
        {
            return new PackageDomain
            {
                Id = packageEntity.Id,
                PackageType = packageEntity.PackageType,
                DateCreated = packageEntity.DateCreated,
                DateUpdated = packageEntity.DateUpdated
            };
        }

        #endregion Packages

        #region ResidentialCareAdditionalNeeds

        public static ResidentialCareAdditionalNeedsDomain ToDomain(this ResidentialCareAdditionalNeedsRequest residentialCareAdditionalNeedsEntity)
        {
            return new ResidentialCareAdditionalNeedsDomain
            {
                Id = residentialCareAdditionalNeedsEntity.Id,
                ResidentialCarePackageId = residentialCareAdditionalNeedsEntity.ResidentialCarePackageId,
                AdditionalNeedsPaymentTypeId = residentialCareAdditionalNeedsEntity.AdditionalNeedsPaymentTypeId,
                NeedToAddress = residentialCareAdditionalNeedsEntity.NeedToAddress,
            };
        }

        #endregion ResidentialCareAdditionalNeeds

        #region Roles

        public static RoleForCreationDomain ToDomain(this RoleForCreationRequest rolesEntity)
        {
            return new RoleForCreationDomain
            {
                Name = rolesEntity.Name
            };
        }

        public static AssignRolesToUserDomain ToDomain(this AssignRolesToUserRequest rolesEntity)
        {
            return new AssignRolesToUserDomain
            {
                UserId = rolesEntity.UserId,
                Roles = rolesEntity.Roles
            };
        }

        public static HackneyTokenDomain ToDomain(this HackneyTokenRequest rolesEntity)
        {
            return _mapper.Map<HackneyTokenDomain>(rolesEntity);
        }

        #endregion Roles

        #region HomeCareServiceTypes

        public static HomeCareServiceDomain ToDomain(this HomeCareServiceRequest homeCareServiceEntity)
        {
            return new HomeCareServiceDomain
            {
                Id = homeCareServiceEntity.Id,
                ServiceName = homeCareServiceEntity.ServiceName,
                PackageId = homeCareServiceEntity.PackageId,
                DateCreated = homeCareServiceEntity.DateCreated,
                DateUpdated = homeCareServiceEntity.DateUpdated
            };
        }

        #endregion HomeCareServiceTypes

        #region ServiceUsers

        public static UserForRegistrationDomain ToDomain(this UserForRegistrationRequest usersEntity)
        {
            return new UserForRegistrationDomain
            {
                Name = $"{usersEntity.FirstName} {usersEntity.LastName}",
                Email = usersEntity.Email,
                Password = usersEntity.Password,
                ConfirmPassword = usersEntity.ConfirmPassword
            };
        }

        #endregion ServiceUsers

        #region PackageStatus

        public static StatusDomain ToDomain(this StatusRequest statusEntity)
        {
            return new StatusDomain
            {
                Id = statusEntity.Id,
                StatusName = statusEntity.StatusName
            };
        }

        #endregion PackageStatus

        #region TimeSlotShifts

        public static TimeSlotShiftsDomain ToDomain(this TimeSlotShiftsRequest timeSlotShiftsEntity)
        {
            return new TimeSlotShiftsDomain
            {
                Id = timeSlotShiftsEntity.Id,
                TimeSlotShiftName = timeSlotShiftsEntity.TimeSlotShiftName,
                TimeSlotTimeLabel = timeSlotShiftsEntity.TimeSlotTimeLabel,
                DateCreated = timeSlotShiftsEntity.DateCreated,
                DateUpdated = timeSlotShiftsEntity.DateUpdated
            };
        }

        #endregion TimeSlotShifts

        #region Care Charge

        public static CareChargeElementPlainDomain ToPlainDomain(this CareChargeElementCreationRequest request)
        {
            return _mapper.Map<CareChargeElementPlainDomain>(request);
        }

        public static IEnumerable<CareChargeElementPlainDomain> ToPlainDomain(this IEnumerable<CareChargeElementCreationRequest> request)
        {
            return _mapper.Map<IEnumerable<CareChargeElementPlainDomain>>(request);
        }

        #endregion Care Charge
    }
}
