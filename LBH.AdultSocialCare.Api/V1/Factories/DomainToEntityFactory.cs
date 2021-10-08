using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCarePackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCarePackageReclaims;
using System.Collections.Generic;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Domain.Security;

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

        public static ResidentialCarePackage ToDb(this CarePackageForCreationDomain carePackageForCreationDomain)
        {
            return _mapper.Map<ResidentialCarePackage>(carePackageForCreationDomain);
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

        #endregion Supplier

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

        public static NursingCarePackageReclaim ToDb(this NursingCarePackageClaimCreationDomain nursingCarePackageClaimCreationDomain)
        {
            return _mapper.Map<NursingCarePackageReclaim>(nursingCarePackageClaimCreationDomain);
        }

        public static ResidentialCarePackageReclaim ToDb(this ResidentialCarePackageClaimCreationDomain residentialCarePackageClaimCreationDomain)
        {
            return _mapper.Map<ResidentialCarePackageReclaim>(residentialCarePackageClaimCreationDomain);
        }

        #endregion PackageReclaim

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

        public static Package ToEntity(this PackageTypeDomain packageTypeDomain)
        {
            return new Package
            {
                Id = packageTypeDomain.Id,
                PackageType = packageTypeDomain.PackageType,
                Sequence = packageTypeDomain.Sequence
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

        public static PackageStatusOption ToEntity(this StatusDomain statusDomain)
        {
            return new PackageStatusOption
            {
                Id = statusDomain.Id,
                StatusName = statusDomain.StatusName
            };
        }

        #endregion PackageStatus

        #region Funded Nursing Care

        public static FundedNursingCare ToEntity(this FundedNursingCareDomain fundedNursingCareDomain)
        {
            return _mapper.Map<FundedNursingCare>(fundedNursingCareDomain);
        }

        #endregion
    }
}
