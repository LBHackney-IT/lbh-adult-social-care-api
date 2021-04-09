using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region DayCarePackage

            CreateMap<DayCarePackageForCreationDomain, DayCarePackage>();
            CreateMap<DayCarePackage, DayCarePackageDomain>()
                .ForMember(dc => dc.PackageName, opt => opt.MapFrom(b => b.Package.PackageName))
                .ForMember(dc => dc.ClientName,
                    opt => opt.MapFrom(b => $"{b.Client.FirstName} {b.Client.MiddleName} {b.Client.LastName}"))
                .ForMember(dc => dc.TermTimeConsiderationOptionName,
                    opt => opt.MapFrom(b => b.TermTimeConsiderationOption.OptionName))
                .ForMember(dc => dc.CreatorName,
                    opt => opt.MapFrom(b => $"{b.Creator.FirstName} {b.Creator.MiddleName} {b.Creator.LastName}"))
                .ForMember(dc => dc.UpdaterName,
                    opt => opt.MapFrom(b => $"{b.Updater.FirstName} {b.Updater.MiddleName} {b.Updater.LastName}"));
            CreateMap<DayCarePackageForCreationRequest, DayCarePackageForCreationDomain>();
            CreateMap<DayCarePackageDomain, DayCarePackageResponse>();

            #endregion DayCarePackage
        }
    }
}
