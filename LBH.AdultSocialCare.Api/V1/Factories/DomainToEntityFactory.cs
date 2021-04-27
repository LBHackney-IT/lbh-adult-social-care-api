using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

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
    }
}
