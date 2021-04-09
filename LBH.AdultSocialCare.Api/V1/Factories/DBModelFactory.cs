using AutoMapper;
using LBH.AdultSocialCare.Api.V1.DataTransferObjects.DayCarePackageDtos;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Factories
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

        public static DayCarePackage ToDb(this DayCarePackageForCreationDto dayCarePackageForCreation)
        {
            return _mapper.Map<DayCarePackage>(dayCarePackageForCreation);
        }


    }
}
