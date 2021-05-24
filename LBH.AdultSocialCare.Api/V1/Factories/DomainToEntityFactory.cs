using System.Collections.Generic;
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
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.SupplierDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCare;
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

        #endregion

        #region NursingCarePackage

        public static NursingCarePackage ToDb(this NursingCarePackageForCreationDomain nursingCarePackageForCreationDomain)
        {
            return _mapper.Map<NursingCarePackage>(nursingCarePackageForCreationDomain);
        }

        #endregion

        #region ResidentialCarePackage

        public static ResidentialCarePackage ToDb(this ResidentialCarePackageForCreationDomain residentialCarePackageForCreationDomain)
        {
            return _mapper.Map<ResidentialCarePackage>(residentialCarePackageForCreationDomain);
        }

        #endregion

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

        #endregion

        #region HomeCareBrokerage

        public static HomeCarePackageCost ToDb(this HomeCareBrokerageCreationDomain supplierCreationDomain)
        {
            return _mapper.Map<HomeCarePackageCost>(supplierCreationDomain);
        }

        public static HomeCareRequestMoreInformation ToDb(this HomeCareRequestMoreInformationDomain homeCareRequestMoreInformationDomain)
        {
            return _mapper.Map<HomeCareRequestMoreInformation>(homeCareRequestMoreInformationDomain);
        }

        #endregion

        #region DayCareCollege

        public static DayCareCollege ToDb(this DayCareCollegeForCreationDomain dayCareCollegeForCreationDomain)
        {
            return _mapper.Map<DayCareCollege>(dayCareCollegeForCreationDomain);
        }

        #endregion

        #region DayCareBrokerage

        public static DayCareRequestMoreInformation ToDb(this DayCareRequestMoreInformationDomain dayCareRequestMoreInformationDomain)
        {
            return _mapper.Map<DayCareRequestMoreInformation>(dayCareRequestMoreInformationDomain);
        }

        public static DayCareBrokerageInfo ToDb(this DayCareBrokerageInfoForCreationDomain dayCareBrokerageInfoForCreationDomain)
        {
            return _mapper.Map<DayCareBrokerageInfo>(dayCareBrokerageInfoForCreationDomain);
        }

        #endregion

        #region NursingCareBrokerage

        public static NursingCareRequestMoreInformation ToDb(this NursingCareRequestMoreInformationDomain nursingCareRequestMoreInformationDomain)
        {
            return _mapper.Map<NursingCareRequestMoreInformation>(nursingCareRequestMoreInformationDomain);
        }

        #endregion

        #region ResidentialCareBrokerage

        public static ResidentialCareRequestMoreInformation ToDb(this ResidentialCareRequestMoreInformationDomain residentialCareRequestMoreInformationDomain)
        {
            return _mapper.Map<ResidentialCareRequestMoreInformation>(residentialCareRequestMoreInformationDomain);
        }

        #endregion

        #region PackageReclaim

        public static HomeCarePackageReclaim ToDb(this HomeCarePackageClaimCreationDomain homeCarePackageClaimCreationDomain)
        {
            return _mapper.Map<HomeCarePackageReclaim>(homeCarePackageClaimCreationDomain);
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

        #endregion

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
                UpdatorId = homeCarePackageDomain.UpdatorId,
                StatusId = homeCarePackageDomain.StatusId,
                Status = homeCarePackageDomain.Status,
                StageId = homeCarePackageDomain.StageId,
                SupplierId = homeCarePackageDomain.SupplierId
            };
        }

        #endregion

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
                UpdatorId = clientsDomain.UpdatorId
            };
        }

        #endregion

        #region NursingCareAdditionalNeeds

        public static NursingCareAdditionalNeed ToEntity(this NursingCareAdditionalNeedsDomain nursingCareAdditionalNeedsDomain)
        {
            return new NursingCareAdditionalNeed
            {
                Id = nursingCareAdditionalNeedsDomain.Id,
                NursingCarePackageId = nursingCareAdditionalNeedsDomain.NursingCarePackageId,
                IsWeeklyCost = nursingCareAdditionalNeedsDomain.IsWeeklyCost,
                IsOneOffCost = nursingCareAdditionalNeedsDomain.IsOneOffCost,
                NeedToAddress = nursingCareAdditionalNeedsDomain.NeedToAddress,
                CreatorId = nursingCareAdditionalNeedsDomain.CreatorId,
                UpdaterId = nursingCareAdditionalNeedsDomain.UpdaterId,
            };
        }

        #endregion
    }
}
