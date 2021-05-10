using System.Collections.Generic;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.DayCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.SupplierDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;

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
    }
}
