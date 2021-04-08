using AutoMapper;
using BaseApi.V1.Boundary.DayCarePackageBoundary.Request;
using BaseApi.V1.Infrastructure.Entities;

namespace BaseApi.V1.Factories
{
    // public interface IDto { }

    public static class DBModelFactory
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

        public static DayCarePackage ToDb(this DayCarePackageForCreationRequest dayCarePackageForCreation)
        {
            return _mapper.Map<DayCarePackage>(dayCarePackageForCreation);
        }
    }
}
