using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.PackageReclaims;
using System.Collections.Generic;
using System.Linq;
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

        #region HomeCareBrokerage

        public static IEnumerable<StageDomain> ToDomain(this List<Stage> homeCareStageEntities)
        {
            return _mapper.Map<IEnumerable<StageDomain>>(homeCareStageEntities);
        }

        #endregion HomeCareBrokerage

        #region PackageReclaim

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

        #endregion PackageReclaim

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

        #region Packages

        public static PackageTypeDomain ToDomain(this Package packageEntity)
        {
            return new PackageTypeDomain
            {
                Id = packageEntity.Id,
                PackageType = packageEntity.PackageType,
                Sequence = packageEntity.Sequence
            };
        }

        #endregion Packages

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

        #region PackageStatus

        public static StatusDomain ToDomain(this PackageStatusOption statusOptionEntity)
        {
            return new StatusDomain
            {
                Id = statusOptionEntity.Id,
                StatusName = statusOptionEntity.StatusName
            };
        }

        public static IEnumerable<StatusDomain> ToDomain(this List<PackageStatusOption> packageStatus)
        {
            return _mapper.Map<IEnumerable<StatusDomain>>(packageStatus);
        }

        #endregion PackageStatus

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
