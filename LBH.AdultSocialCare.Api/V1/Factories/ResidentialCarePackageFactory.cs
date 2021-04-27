using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class ResidentialCarePackageFactory
    {
        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static IList<ResidentialCarePackageForCreationDomain> ToDomain(this IList<ResidentialCarePackage> residentialCarePackagesEntity)
        {
            return _mapper.Map<IList<ResidentialCarePackageForCreationDomain>>(residentialCarePackagesEntity);
        }

        public static IList<ResidentialCarePackageResponse> ToResponse(this IList<ResidentialCarePackageForCreationDomain> residentialCarePackagesDomain)
        {
            return _mapper.Map<IList<ResidentialCarePackageResponse>>(residentialCarePackagesDomain);
        }

        public static IList<TypeOfResidentialCareHomeDomain> ToDomain(IList<TypeOfResidentialCareHome> typeOfResidentialCareHomes)
        {
            return typeOfResidentialCareHomes.Select(item
             => new TypeOfResidentialCareHomeDomain
             {
                 TypeOfCareHomeId = item.TypeOfCareHomeId,
                 TypeOfCareHomeName = item.TypeOfCareHomeName
             }).ToList();
        }

        public static IList<TypeOfResidentialCareHomeResponse> ToResponse(IList<TypeOfResidentialCareHomeDomain> typeOfResidentialCareHomesDomain)
        {
            return typeOfResidentialCareHomesDomain.Select(item
             => new TypeOfResidentialCareHomeResponse
             {
                 TypeOfCareHomeId = item.TypeOfCareHomeId,
                 TypeOfCareHomeName = item.TypeOfCareHomeName
             }).ToList();
        }
    }
}
