using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System.Collections.Generic;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class EntityToDomainFactory
    {
        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Supplier

        public static SupplierDomain ToDomain(this Supplier supplierEntity)
        {
            return _mapper.Map<SupplierDomain>(supplierEntity);
        }

        public static IEnumerable<SupplierDomain> ToDomain(this List<Supplier> supplierEntities)
        {
            return _mapper.Map<IEnumerable<SupplierDomain>>(supplierEntities);
        }

        #endregion Supplier

        #region Clients

        public static ClientsDomain ToDomain(this ServiceUser serviceUserEntity)
        {
            return new ClientsDomain
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
                CreatorId = serviceUserEntity.CreatorId,
                DateCreated = serviceUserEntity.DateCreated,
                UpdaterId = serviceUserEntity.UpdaterId,
                DateUpdated = serviceUserEntity.DateUpdated
            };
        }

        public static IEnumerable<ClientsDomain> ToDomain(this List<ServiceUser> clientEntities)
        {
            return _mapper.Map<IEnumerable<ClientsDomain>>(clientEntities);
        }

        #endregion Clients

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

        #region ServiceUsers

        public static AppUserDomain ToDomain(this User userEntity)
        {
            return new AppUserDomain
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email
            };
        }

        public static IEnumerable<AppUserDomain> ToDomain(this List<User> users)
        {
            return _mapper.Map<IEnumerable<AppUserDomain>>(users);
        }

        #endregion ServiceUsers

        #region PrimarySupportReason

        public static IEnumerable<PrimarySupportReasonDomain> ToDomain(this List<PrimarySupportReason> primarySupportReasons)
        {
            return _mapper.Map<IEnumerable<PrimarySupportReasonDomain>>(primarySupportReasons);
        }

        #endregion PrimarySupportReason

        #region FundedNursingCare

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

        #endregion CareCharges
    }
}
