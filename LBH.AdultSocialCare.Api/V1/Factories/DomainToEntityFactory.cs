using System.Collections.Generic;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Entities.Payments;

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

        #region Supplier

        public static Supplier ToDb(this SupplierCreationDomain supplierCreationDomain)
        {
            return _mapper.Map<Supplier>(supplierCreationDomain);
        }

        #endregion Supplier

        #region Clients

        public static ServiceUser ToEntity(this ServiceUserDomain serviceUserDomain)
        {
            return new ServiceUser
            {
                Id = serviceUserDomain.Id,
                FirstName = serviceUserDomain.FirstName,
                MiddleName = serviceUserDomain.MiddleName,
                LastName = serviceUserDomain.LastName,
                DateOfBirth = serviceUserDomain.DateOfBirth,
                HackneyId = serviceUserDomain.HackneyId,
                AddressLine1 = serviceUserDomain.AddressLine1,
                AddressLine2 = serviceUserDomain.AddressLine2,
                AddressLine3 = serviceUserDomain.AddressLine3,
                Town = serviceUserDomain.Town,
                County = serviceUserDomain.County,
                PostCode = serviceUserDomain.PostCode,
                CreatorId = serviceUserDomain.CreatorId,
                UpdaterId = serviceUserDomain.UpdaterId
            };
        }

        #endregion Clients

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

        #region PayRun

        public static Payrun ToEntity(this DraftPayRunCreationDomain input)
        {
            return _mapper.Map<Payrun>(input);
        }

        #endregion

        #region Care charges

        public static CarePackageReclaim ToEntity(this CareChargeReclaimCreationDomain input)
        {
            return _mapper.Map<CarePackageReclaim>(input);
        }

        public static IEnumerable<CarePackageReclaim> ToEntity(this IEnumerable<CareChargeReclaimCreationDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackageReclaim>>(input);
        }

        #endregion
    }
}
