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

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static partial class MappingExtensions
    {
        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static CareChargeElementCreationResponse ToCreationResponse(this CareChargeElementPlainDomain input)
        {
            return _mapper.Map<CareChargeElementCreationResponse>(input);
        }

        public static CareChargeElementPlainDomain ToPlainDomain(this CareChargeElementCreationResponse input)
        {
            return _mapper.Map<CareChargeElementPlainDomain>(input);
        }

        public static IEnumerable<CareChargeElementCreationResponse> ToCreationResponse(this IEnumerable<CareChargeElementPlainDomain> input)
        {
            return _mapper.Map<IEnumerable<CareChargeElementCreationResponse>>(input);
        }

        public static IEnumerable<CareChargeElementPlainDomain> ToPlainDomain(this IEnumerable<CareChargeElementCreationResponse> input)
        {
            return _mapper.Map<IEnumerable<CareChargeElementPlainDomain>>(input);
        }

        public static CareChargeElementTypePlainResponse ToResponse(this CareChargeElementTypePlainDomain input)
        {
            return _mapper.Map<CareChargeElementTypePlainResponse>(input);
        }

        public static CareChargeElementTypePlainDomain ToDomain(this CareChargeElementTypePlainResponse input)
        {
            return _mapper.Map<CareChargeElementTypePlainDomain>(input);
        }

        public static IEnumerable<CareChargeElementTypePlainResponse> ToResponse(this IEnumerable<CareChargeElementTypePlainDomain> input)
        {
            return _mapper.Map<IEnumerable<CareChargeElementTypePlainResponse>>(input);
        }

        public static IEnumerable<CareChargeElementTypePlainDomain> ToDomain(this IEnumerable<CareChargeElementTypePlainResponse> input)
        {
            return _mapper.Map<IEnumerable<CareChargeElementTypePlainDomain>>(input);
        }

        public static CarePackagePlainResponse ToResponse(this CarePackagePlainDomain input)
        {
            return _mapper.Map<CarePackagePlainResponse>(input);
        }

        public static CarePackagePlainDomain ToDomain(this CarePackagePlainResponse input)
        {
            return _mapper.Map<CarePackagePlainDomain>(input);
        }

        public static IEnumerable<CarePackagePlainResponse> ToResponse(this IEnumerable<CarePackagePlainDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackagePlainResponse>>(input);
        }

        public static IEnumerable<CarePackagePlainDomain> ToDomain(this IEnumerable<CarePackagePlainResponse> input)
        {
            return _mapper.Map<IEnumerable<CarePackagePlainDomain>>(input);
        }

        public static CarePackage ToEntity(this ResidentialCarePackageForCreationDomain input)
        {
            return _mapper.Map<CarePackage>(input);
        }

        public static ResidentialCarePackageForCreationDomain ToForCreationDomain(this CarePackage input)
        {
            return _mapper.Map<ResidentialCarePackageForCreationDomain>(input);
        }

        public static ResidentialCarePackageSettings ToSettings(this ResidentialCarePackageForCreationDomain input)
        {
            return _mapper.Map<ResidentialCarePackageSettings>(input);
        }

        public static ResidentialCarePackageForCreationDomain ToForCreationDomain(this ResidentialCarePackageSettings input)
        {
            return _mapper.Map<ResidentialCarePackageForCreationDomain>(input);
        }

        public static CareChargeElementPlainDomain ToPlainDomain(this CareChargeElementCreationRequest input)
        {
            return _mapper.Map<CareChargeElementPlainDomain>(input);
        }

        public static CareChargeElementCreationRequest ToCreationRequest(this CareChargeElementPlainDomain input)
        {
            return _mapper.Map<CareChargeElementCreationRequest>(input);
        }

        public static IEnumerable<CareChargeElementPlainDomain> ToPlainDomain(this IEnumerable<CareChargeElementCreationRequest> input)
        {
            return _mapper.Map<IEnumerable<CareChargeElementPlainDomain>>(input);
        }

        public static IEnumerable<CareChargeElementCreationRequest> ToCreationRequest(this IEnumerable<CareChargeElementPlainDomain> input)
        {
            return _mapper.Map<IEnumerable<CareChargeElementCreationRequest>>(input);
        }

        public static CareChargeElementForUpdateDomain ToDomain(this CareChargeElementForUpdateRequest input)
        {
            return _mapper.Map<CareChargeElementForUpdateDomain>(input);
        }

        public static CareChargeElementForUpdateRequest ToRequest(this CareChargeElementForUpdateDomain input)
        {
            return _mapper.Map<CareChargeElementForUpdateRequest>(input);
        }

        public static IEnumerable<CareChargeElementForUpdateDomain> ToDomain(this IEnumerable<CareChargeElementForUpdateRequest> input)
        {
            return _mapper.Map<IEnumerable<CareChargeElementForUpdateDomain>>(input);
        }

        public static IEnumerable<CareChargeElementForUpdateRequest> ToRequest(this IEnumerable<CareChargeElementForUpdateDomain> input)
        {
            return _mapper.Map<IEnumerable<CareChargeElementForUpdateRequest>>(input);
        }

        public static EndCareChargeElementDomain ToDomain(this EndCareChargeElementRequest input)
        {
            return _mapper.Map<EndCareChargeElementDomain>(input);
        }

        public static EndCareChargeElementRequest ToRequest(this EndCareChargeElementDomain input)
        {
            return _mapper.Map<EndCareChargeElementRequest>(input);
        }

        public static CareChargeElementPlainDomain ToPlainDomain(this CareChargeElement input)
        {
            return _mapper.Map<CareChargeElementPlainDomain>(input);
        }

        public static CareChargeElement ToEntity(this CareChargeElementPlainDomain input)
        {
            return _mapper.Map<CareChargeElement>(input);
        }

        public static IEnumerable<CareChargeElementPlainDomain> ToPlainDomain(this IEnumerable<CareChargeElement> input)
        {
            return _mapper.Map<IEnumerable<CareChargeElementPlainDomain>>(input);
        }

        public static IEnumerable<CareChargeElement> ToEntity(this IEnumerable<CareChargeElementPlainDomain> input)
        {
            return _mapper.Map<IEnumerable<CareChargeElement>>(input);
        }

        public static CareChargeElementTypePlainDomain ToElementTypePlainDomain(this CareChargeType input)
        {
            return _mapper.Map<CareChargeElementTypePlainDomain>(input);
        }

        public static CareChargeType ToType(this CareChargeElementTypePlainDomain input)
        {
            return _mapper.Map<CareChargeType>(input);
        }

        public static IEnumerable<CareChargeElementTypePlainDomain> ToElementTypePlainDomain(this IEnumerable<CareChargeType> input)
        {
            return _mapper.Map<IEnumerable<CareChargeElementTypePlainDomain>>(input);
        }

        public static IEnumerable<CareChargeType> ToType(this IEnumerable<CareChargeElementTypePlainDomain> input)
        {
            return _mapper.Map<IEnumerable<CareChargeType>>(input);
        }

        public static PackageCareChargeDomain ToDomain(this PackageCareCharge input)
        {
            return _mapper.Map<PackageCareChargeDomain>(input);
        }

        public static PackageCareCharge ToEntity(this PackageCareChargeDomain input)
        {
            return _mapper.Map<PackageCareCharge>(input);
        }

        public static IEnumerable<PackageCareChargeDomain> ToDomain(this IEnumerable<PackageCareCharge> input)
        {
            return _mapper.Map<IEnumerable<PackageCareChargeDomain>>(input);
        }

        public static IEnumerable<PackageCareCharge> ToEntity(this IEnumerable<PackageCareChargeDomain> input)
        {
            return _mapper.Map<IEnumerable<PackageCareCharge>>(input);
        }

        public static CarePackagePlainDomain ToPlainDomain(this CarePackage input)
        {
            return _mapper.Map<CarePackagePlainDomain>(input);
        }

        public static CarePackage ToEntity(this CarePackagePlainDomain input)
        {
            return _mapper.Map<CarePackage>(input);
        }

        public static IEnumerable<CarePackagePlainDomain> ToPlainDomain(this IEnumerable<CarePackage> input)
        {
            return _mapper.Map<IEnumerable<CarePackagePlainDomain>>(input);
        }

        public static IEnumerable<CarePackage> ToEntity(this IEnumerable<CarePackagePlainDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackage>>(input);
        }
    }
}
