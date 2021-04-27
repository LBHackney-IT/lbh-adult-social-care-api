using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageOpportunityBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageOpportunityBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareAdditionalNeedsBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareAdditionalNeedsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.OpportunityLengthOptionBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.OpportunityTimesPerMonthOptionBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.TermTimeConsiderationOptionBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using LBH.AdultSocialCare.Api.V1.Domain.OpportunityLengthOptionDomains;
using LBH.AdultSocialCare.Api.V1.Domain.OpportunityTimesPerMonthOptionDomains;
using LBH.AdultSocialCare.Api.V1.Domain.TermTimeConsiderationOptionDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareAdditionalNeedsDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Request.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareAdditionalNeedsDomains;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarepackageBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region DayCarePackage

            CreateMap<DayCarePackageForCreationDomain, DayCarePackage>();
            CreateMap<DayCarePackageForUpdateDomain, DayCarePackage>();
            CreateMap<DayCarePackage, DayCarePackageDomain>()
                .ForMember(dc => dc.PackageName, opt => opt.MapFrom(b => "Day Care package"))
                .ForMember(dc => dc.ClientName,
                    opt => opt.MapFrom(b => $"{b.Client.FirstName} {b.Client.MiddleName} {b.Client.LastName}"))
                .ForMember(dc => dc.TermTimeConsiderationOptionName,
                    opt => opt.MapFrom(b => b.TermTimeConsiderationOption.OptionName))
                .ForMember(dc => dc.CreatorName,
                    opt => opt.MapFrom(b => $"{b.Creator.FirstName} {b.Creator.MiddleName} {b.Creator.LastName}"))
                .ForMember(dc => dc.UpdaterName,
                    opt => opt.MapFrom(b => $"{b.Updater.FirstName} {b.Updater.MiddleName} {b.Updater.LastName}"));
            CreateMap<DayCarePackageForCreationRequest, DayCarePackageForCreationDomain>();
            CreateMap<DayCarePackageForUpdateRequest, DayCarePackageForUpdateDomain>();
            CreateMap<DayCarePackageDomain, DayCarePackageResponse>();

            CreateMap<DayCarePackageOpportunityForCreationDomain, DayCarePackageOpportunity>();
            CreateMap<DayCarePackageOpportunityForUpdateDomain, DayCarePackageOpportunity>();
            CreateMap<DayCarePackageOpportunity, DayCarePackageOpportunityDomain>()
                .ForMember(dco => dco.HowLong,
                    opt => opt.MapFrom(b => b.OpportunityLengthOption))
                .ForMember(dco => dco.HowManyTimesPerMonth,
                    opt => opt.MapFrom(b => b.OpportunityTimesPerMonthOption));
            CreateMap<DayCarePackageOpportunityForCreationRequest, DayCarePackageOpportunityForCreationDomain>()
                .ForMember(dco => dco.OpportunityLengthOptionId,
                opt => opt.MapFrom(b => b.HowLongId))
                .ForMember(dco => dco.OpportunityTimePerMonthOptionId,
                opt => opt.MapFrom(b => b.HowManyTimesPerMonthId));
            CreateMap<DayCarePackageOpportunityForUpdateRequest, DayCarePackageOpportunityForUpdateDomain>()
                .ForMember(dco => dco.OpportunityLengthOptionId,
                    opt => opt.MapFrom(b => b.HowLongId))
                .ForMember(dco => dco.OpportunityTimePerMonthOptionId,
                    opt => opt.MapFrom(b => b.HowManyTimesPerMonthId));
            CreateMap<DayCarePackageOpportunityDomain, DayCarePackageOpportunityResponse>();

            #endregion DayCarePackage

            #region TermTimeConsiderationOptions

            CreateMap<TermTimeConsiderationOption, TermTimeConsiderationOptionDomain>();
            CreateMap<TermTimeConsiderationOptionDomain, TermTimeConsiderationOptionResponse>();

            #endregion

            #region OpportunityLengthOptions

            CreateMap<OpportunityLengthOption, OpportunityLengthOptionDomain>();
            CreateMap<OpportunityLengthOptionDomain, OpportunityLengthOptionResponse>();

            #endregion

            #region OpportunityTimesPerMonthOptions

            CreateMap<OpportunityTimesPerMonthOption, OpportunityTimesPerMonthOptionDomain>();
            CreateMap<OpportunityTimesPerMonthOptionDomain, OpportunityTimesPerMonthOptionResponse>();

            #endregion

            #region HomeCarePackage

            CreateMap<HomeCarePackageResponse, HomeCarePackageDomain>();
            CreateMap<HomeCarePackage, HomeCarePackageDomain>();
            CreateMap<HomeCarePackageDomain, HomeCarePackage>();
            CreateMap<HomeCarePackageDomain, HomeCarePackageResponse>();

            #endregion HomeCarePackage

            #region NursingCarePackage

            CreateMap<TypeOfNursingCareHome, TypeOfNursingCareHomeDomain>();
            CreateMap<NursingCarePackageDomain, NursingCarePackageResponse>();
            CreateMap<NursingCarePackage, NursingCarePackageDomain>();
            CreateMap<NursingCarePackageDomain, NursingCarePackage>();
            CreateMap<NursingCareTypeOfStayOption, NursingCareTypeOfStayOptionDomain>();
            CreateMap<NursingCareTypeOfStayOptionDomain, NursingCareTypeOfStayOptionResponse>();
            CreateMap<NursingCarePackageForUpdateRequest, NursingCarePackageDomain>();
            CreateMap<NursingCarePackageForCreationRequest, NursingCarePackageForCreationDomain>();
            CreateMap<NursingCareAdditionalNeedForCreationRequest, NursingCareAdditionalNeedForCreationDomain>();
            CreateMap<NursingCareAdditionalNeedForCreationDomain, NursingCareAdditionalNeed>();
            CreateMap<NursingCareAdditionalNeed, NursingCareAdditionalNeedsDomain>();
            CreateMap<NursingCareAdditionalNeedsDomain, NursingCareAdditionalNeedsResponse>();
            CreateMap<NursingCarePackageForCreationDomain, NursingCarePackage>();
            CreateMap<NursingCarePackageForUpdateDomain, NursingCarePackage>();
            CreateMap<TypeOfNursingCareHomeDomain, TypeOfNursingCareHomeResponse>();

            #endregion

            #region ResidentialCarePackage

            CreateMap<TypeOfResidentialCareHome, TypeOfResidentialCareHomeDomain>();
            CreateMap<ResidentialCarePackageDomain, ResidentialCarePackageResponse>();
            CreateMap<ResidentialCarePackage, ResidentialCarePackageDomain>();
            CreateMap<ResidentialCarePackageDomain, ResidentialCarePackage>();
            CreateMap<ResidentialCareTypeOfStayOption, ResidentialCareTypeOfStayOptionDomain>();
            CreateMap<ResidentialCareTypeOfStayOptionDomain, ResidentialCareTypeOfStayOptionResponse>();
            CreateMap<ResidentialCarePackageForUpdateRequest, ResidentialCarePackageDomain>();
            CreateMap<ResidentialCarePackageForCreationRequest, ResidentialCarePackageForCreationDomain>();
            CreateMap<ResidentialCareAdditionalNeedForCreationRequest, ResidentialCareAdditionalNeedForCreationDomain>();
            CreateMap<ResidentialCareAdditionalNeedForCreationDomain, ResidentialCareAdditionalNeed>();
            CreateMap<ResidentialCareAdditionalNeed, ResidentialCareAdditionalNeedsDomain>();
            CreateMap<ResidentialCareAdditionalNeedsDomain, ResidentialCareAdditionalNeedsResponse>();
            CreateMap<ResidentialCarePackageForCreationDomain, ResidentialCarePackage>();
            CreateMap<ResidentialCarePackageForUpdateDomain, ResidentialCarePackage>();
            CreateMap<TypeOfResidentialCareHomeDomain, TypeOfResidentialCareHomeResponse>();

            #endregion
        }
    }
}
