using AutoMapper;
using BaseApi.V1.Boundary.DayCarePackageBoundary.Request;
using BaseApi.V1.Domain.DayCarePackageDomains;

namespace BaseApi.V1.Factories
{
    public static class ApiToDomainFactory
    {
        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static DayCarePackageForCreationDomain ToDomain(this DayCarePackageForCreationRequest dayCarePackageForCreation)
        {
            return _mapper.Map<DayCarePackageForCreationDomain>(dayCarePackageForCreation);
        }
    }
}
