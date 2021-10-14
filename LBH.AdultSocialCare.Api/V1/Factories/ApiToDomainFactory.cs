using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Request;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
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

        #region CarePackage

        public static CarePackageForCreationDomain ToDomain(this CarePackageForCreationRequest carePackageForCreation)
        {
            var res = _mapper.Map<CarePackageForCreationDomain>(carePackageForCreation);
            return res;
        }

        #endregion CarePackage

        #region Supplier

        public static SupplierCreationDomain ToDomain(this SupplierCreationRequest supplierCreationRequest)
        {
            var res = _mapper.Map<SupplierCreationDomain>(supplierCreationRequest);
            return res;
        }

        #endregion Supplier

        #region Clients

        public static ServiceUserDomain ToDomain(this ServiceUserRequest serviceUserEntity)
        {
            return new ServiceUserDomain
            {
                Id = serviceUserEntity.Id,
                FirstName = serviceUserEntity.FirstName,
                MiddleName = serviceUserEntity.MiddleName,
                LastName = serviceUserEntity.LastName,
                DateOfBirth = serviceUserEntity.DateOfBirth,
                HackneyId = serviceUserEntity.HackneyId,
                AddressLine1 = serviceUserEntity.AddressLine1,
                AddressLine2 = serviceUserEntity.AddressLine2,
                AddressLine3 = serviceUserEntity.AddressLine3,
                Town = serviceUserEntity.Town,
                County = serviceUserEntity.County,
                PostCode = serviceUserEntity.PostCode,
                DateCreated = serviceUserEntity.DateCreated,
                DateUpdated = serviceUserEntity.DateUpdated
            };
        }

        #endregion Clients

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
