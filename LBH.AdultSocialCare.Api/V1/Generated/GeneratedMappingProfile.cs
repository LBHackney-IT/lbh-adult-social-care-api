using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCarePackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCarePackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCarePackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.PackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCarePackageReclaims;

namespace LBH.AdultSocialCare.Api.V1.Profiles
{
    public class GeneratedMappingProfile : Profile
    {
        public GeneratedMappingProfile()
        {
            CreateMap<CareChargeElementPlainDomain, CareChargeElementCreationResponse>().ReverseMap();
            CreateMap<CareChargeElementTypePlainDomain, CareChargeElementTypePlainResponse>().ReverseMap();
            CreateMap<CarePackageDetailDomain, CarePackageDetail>().ReverseMap();
            CreateMap<CarePackagePlainDomain, CarePackagePlainResponse>().ReverseMap();
            CreateMap<CarePackageForCreationDomain, CarePackage>().ReverseMap();
            CreateMap<CarePackageForCreationDomain, CarePackageSettings>().ReverseMap();
            CreateMap<CareChargeElementCreationRequest, CareChargeElementPlainDomain>().ReverseMap();
            CreateMap<CareChargeElementForUpdateRequest, CareChargeElementForUpdateDomain>().ReverseMap();
            CreateMap<CarePackageBrokerageRequest, CarePackageBrokerageDomain>().ReverseMap();
            CreateMap<CarePackageDetailRequest, CarePackageDetailDomain>().ReverseMap();
            CreateMap<EndCareChargeElementRequest, EndCareChargeElementDomain>().ReverseMap();
            CreateMap<CareChargeElement, CareChargeElementPlainDomain>().ReverseMap();
            CreateMap<CareChargeType, CareChargeElementTypePlainDomain>().ReverseMap();
            CreateMap<PackageCareCharge, PackageCareChargeDomain>().ReverseMap();
            CreateMap<CarePackage, CarePackagePlainDomain>().ReverseMap();
        }
    }
}
