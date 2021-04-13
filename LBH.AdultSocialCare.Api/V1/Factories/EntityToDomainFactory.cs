using System.Collections.Generic;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class EntityToDomainFactory
    {
        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }
        public static Entity ToDomain(this DatabaseEntity databaseEntity)
        {
            //TODO: Map the rest of the fields in the domain object.
            // More information on this can be found here https://github.com/LBHackney-IT/lbh-base-api/wiki/Factory-object-mappings

            return new Entity
            {
                Id = databaseEntity.Id,
                CreatedAt = databaseEntity.CreatedAt
            };
        }

        public static DatabaseEntity ToDatabase(this Entity entity)
        {
            //TODO: Map the rest of the fields in the database object.

            return new DatabaseEntity
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt
            };
        }

        #region DayCarePackage

        public static DayCarePackageDomain ToDomain(this DayCarePackage dayCarePackageEntity)
        {
            return _mapper.Map<DayCarePackageDomain>(dayCarePackageEntity);
        }
        public static IEnumerable<DayCarePackageDomain> ToDomain(this List<DayCarePackage> dayCarePackageEntities)
        {
            return _mapper.Map<IEnumerable<DayCarePackageDomain>>(dayCarePackageEntities);
        }

        #endregion

        #region DayCarePackegeOpportunity

        public static DayCarePackageOpportunityDomain ToDomain(this DayCarePackageOpportunity dayCarePackageOpportunityEntity)
        {
            return _mapper.Map<DayCarePackageOpportunityDomain>(dayCarePackageOpportunityEntity);
        }

        public static IEnumerable<DayCarePackageOpportunityDomain> ToDomain(this List<DayCarePackageOpportunity> dayCarePackageOpportunityEntities)
        {
            return _mapper.Map<IEnumerable<DayCarePackageOpportunityDomain>>(dayCarePackageOpportunityEntities);
        }

        #endregion
    }
}
