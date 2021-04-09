using AutoMapper;
using LBH.AdultSocialCare.Api.V1.DataTransferObjects.DayCarePackageDtos;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DayCarePackageForCreationDto, DayCarePackage>();
        }
    }
}
