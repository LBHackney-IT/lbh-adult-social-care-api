using AutoMapper;
using System;
using System.Collections.Generic;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Request;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
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

        #region ResidentialCarePackage

        public static ResidentialCarePackageForUpdateDomain ToDomain(this ResidentialCarePackageForUpdateRequest residentialCarePackageForUpdate, Guid residentialCarePackageId)
        {
            var res = _mapper.Map<ResidentialCarePackageForUpdateDomain>(residentialCarePackageForUpdate);
            res.Id = residentialCarePackageId;
            return res;
        }

        public static CarePackageForCreationDomain ToDomain(this CarePackageForCreationRequest carePackageForCreation)
        {
            var res = _mapper.Map<CarePackageForCreationDomain>(carePackageForCreation);
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

        #endregion Supplier

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

        #region PackageReclaim

        public static ResidentialCarePackageClaimCreationDomain ToDomain(this ResidentialCarePackageClaimCreationRequest residentialCarePackageClaimCreationRequest)
        {
            var res = _mapper.Map<ResidentialCarePackageClaimCreationDomain>(residentialCarePackageClaimCreationRequest);
            return res;
        }

        #endregion PackageReclaim

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

        #region Packages

        public static PackageTypeDomain ToDomain(this PackageRequest packageEntity)
        {
            return new PackageTypeDomain
            {
                Id = packageEntity.Id,
                PackageType = packageEntity.PackageType
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

        #region Reclaim

        public static CarePackageReclaimCreationDomain ToDomain(this CareChargeReclaimCreationRequest carePackageReclaimCreationRequest)
        {
            return _mapper.Map<CarePackageReclaimCreationDomain>(carePackageReclaimCreationRequest);
        }

        public static CarePackageReclaimCreationDomain ToDomain(this FundedNursingCareCreationRequest fundedNursingCareCreationRequest)
        {
            return _mapper.Map<CarePackageReclaimCreationDomain>(fundedNursingCareCreationRequest);
        }

        public static CarePackageReclaimForUpdateDomain ToDomain(this CareChargeReclaimUpdateRequest carePackageReclaimUpdateRequest)
        {
            return _mapper.Map<CarePackageReclaimForUpdateDomain>(carePackageReclaimUpdateRequest);
        }

        public static CarePackageReclaimForUpdateDomain ToDomain(this FundedNursingCareUpdateRequest fundedNursingCareUpdateRequest)
        {
            return _mapper.Map<CarePackageReclaimForUpdateDomain>(fundedNursingCareUpdateRequest);
        }

        #endregion
    }
}
