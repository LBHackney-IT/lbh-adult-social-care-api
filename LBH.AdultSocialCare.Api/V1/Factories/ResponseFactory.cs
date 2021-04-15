using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageOpportunityBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class ResponseFactory
    {
        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        //TODO: Map the fields in the domain object(s) to fields in the response object(s).
        // More information on this can be found here https://github.com/LBHackney-IT/lbh-base-api/wiki/Factory-object-mappings
        public static ResponseObject ToResponse(this Entity domain)
        {
            return new ResponseObject();
        }

        public static List<ResponseObject> ToResponse(this IEnumerable<Entity> domainList)
        {
            return domainList.Select(domain => domain.ToResponse()).ToList();
        }

        public static DayCarePackageResponse ToResponse(this DayCarePackageDomain dayCarePackageDomain)
        {
            return _mapper.Map<DayCarePackageResponse>(dayCarePackageDomain);
        }

        public static IEnumerable<DayCarePackageResponse> ToResponse(this IEnumerable<DayCarePackageDomain> dayCarePackageDomains)
        {
            return _mapper.Map<IEnumerable<DayCarePackageResponse>>(dayCarePackageDomains);
        }

        public static DayCarePackageOpportunityResponse ToResponse(this DayCarePackageOpportunityDomain dayCarePackageOpportunityDomain)
        {
            return _mapper.Map<DayCarePackageOpportunityResponse>(dayCarePackageOpportunityDomain);
        }

        public static IEnumerable<DayCarePackageOpportunityResponse> ToResponse(this IEnumerable<DayCarePackageOpportunityDomain> dayCarePackageOpportunityDomains)
        {
            return _mapper.Map<IEnumerable<DayCarePackageOpportunityResponse>>(dayCarePackageOpportunityDomains);
        }
    }
}
