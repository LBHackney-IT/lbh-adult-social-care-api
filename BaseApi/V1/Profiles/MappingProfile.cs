using AutoMapper;
using BaseApi.V1.DataTransferObjects.DayCarePackageDtos;
using BaseApi.V1.Infrastructure.Entities;

namespace BaseApi.V1.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DayCarePackageForCreationDto, DayCarePackage>();
        }
    }
}
