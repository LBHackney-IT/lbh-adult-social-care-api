using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageOpportunityBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareAdditionalNeedsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.OpportunityLengthOptionBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.OpportunityTimesPerMonthOptionBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.TermTimeConsiderationOptionBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.OpportunityLengthOptionDomains;
using LBH.AdultSocialCare.Api.V1.Domain.OpportunityTimesPerMonthOptionDomains;
using LBH.AdultSocialCare.Api.V1.Domain.TermTimeConsiderationOptionDomains;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class ResponseFactory
    {
        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        //TODO: Map the fields in the domain object(s) to fields in the response object(s).
        // More information on this can be found here https://github.com/LBHackney-IT/lbh-base-api/wiki/Factory-object-mappings
        public static ResponseObject ToResponse(this Entity domain)
        {
            return new ResponseObject();
        }

        public static List<ResponseObject> ToResponse(this IEnumerable<Entity> domainList)
        {
            return domainList.Select(domain => domain.ToResponse()).ToList();
        }

        #region DayCarePackage

        public static DayCarePackageResponse ToResponse(this DayCarePackageDomain dayCarePackageDomain)
        {
            return _mapper.Map<DayCarePackageResponse>(dayCarePackageDomain);
        }

        public static IEnumerable<DayCarePackageResponse> ToResponse(this IEnumerable<DayCarePackageDomain> dayCarePackageDomains)
        {
            return _mapper.Map<IEnumerable<DayCarePackageResponse>>(dayCarePackageDomains);
        }

        #endregion

        public static DayCarePackageOpportunityResponse ToResponse(this DayCarePackageOpportunityDomain dayCarePackageOpportunityDomain)
        {
            return _mapper.Map<DayCarePackageOpportunityResponse>(dayCarePackageOpportunityDomain);
        }

        public static IEnumerable<DayCarePackageOpportunityResponse> ToResponse(this IEnumerable<DayCarePackageOpportunityDomain> dayCarePackageOpportunityDomains)
        {
            return _mapper.Map<IEnumerable<DayCarePackageOpportunityResponse>>(dayCarePackageOpportunityDomains);
        }

        #region TermTimeConsiderations

        public static IEnumerable<TermTimeConsiderationOptionResponse> ToResponse(this IEnumerable<TermTimeConsiderationOptionDomain> termTimeConsiderationDomains)
        {
            return _mapper.Map<IEnumerable<TermTimeConsiderationOptionResponse>>(termTimeConsiderationDomains);
        }

        #endregion

        #region OpportunityLengthOptions

        public static IEnumerable<OpportunityLengthOptionResponse> ToResponse(this IEnumerable<OpportunityLengthOptionDomain> opportunityLengthOptionDomains)
        {
            return _mapper.Map<IEnumerable<OpportunityLengthOptionResponse>>(opportunityLengthOptionDomains);
        }

        #endregion

        #region OpportunityTimesPerMonthOptions

        public static IEnumerable<OpportunityTimesPerMonthOptionResponse> ToResponse(this IEnumerable<OpportunityTimesPerMonthOptionDomain> opportunityTimesPerMonthOptionDomains)
        {
            return _mapper.Map<IEnumerable<OpportunityTimesPerMonthOptionResponse>>(opportunityTimesPerMonthOptionDomains);
        }

        #endregion

        #region NursingCarePackage

        public static NursingCarePackageResponse ToResponse(this NursingCarePackageDomain nursingCarePackageDomain)
        {
            // return _mapper.Map<NursingCarePackageResponse>(nursingCarePackageDomain);
            return new NursingCarePackageResponse
            {
                Id = nursingCarePackageDomain.Id,
                ClientId = nursingCarePackageDomain.ClientId,
                IsFixedPeriod = nursingCarePackageDomain.IsFixedPeriod,
                StartDate = nursingCarePackageDomain.StartDate,
                EndDate = nursingCarePackageDomain.EndDate,
                IsRespiteCare = nursingCarePackageDomain.IsRespiteCare,
                IsDischargePackage = nursingCarePackageDomain.IsDischargePackage,
                IsThisAnImmediateService = nursingCarePackageDomain.IsThisAnImmediateService,
                IsThisUserUnderS117 = nursingCarePackageDomain.IsThisUserUnderS117,
                TypeOfStayId = nursingCarePackageDomain.TypeOfStayId,
                NeedToAddress = nursingCarePackageDomain.NeedToAddress,
                TypeOfNursingCareHomeId = nursingCarePackageDomain.TypeOfNursingCareHomeId,
                CreatorId = nursingCarePackageDomain.CreatorId,
                UpdaterId = nursingCarePackageDomain.UpdaterId,
                StatusId = nursingCarePackageDomain.StatusId,
                ClientName = nursingCarePackageDomain.ClientName,
                StatusName = nursingCarePackageDomain.StatusName,
                CreatorName = nursingCarePackageDomain.CreatorName,
                UpdaterName = nursingCarePackageDomain.UpdaterName,
                PackageName = nursingCarePackageDomain.PackageName,
                TypeOfCareHomeName = nursingCarePackageDomain.TypeOfCareHomeName,
                TypeOfStayOptionName = nursingCarePackageDomain.TypeOfStayOptionName,
                NursingCareAdditionalNeeds = nursingCarePackageDomain.NursingCareAdditionalNeeds.ToResponse()
            };
        }

        public static IEnumerable<NursingCarePackageResponse> ToResponse(this IEnumerable<NursingCarePackageDomain> nursingCarePackageDomains)
        {
            return _mapper.Map<IEnumerable<NursingCarePackageResponse>>(nursingCarePackageDomains);
        }

        #endregion

        #region NursingCareAdditionalNeeds

        public static IEnumerable<NursingCareAdditionalNeedsResponse> ToResponse(this IEnumerable<NursingCareAdditionalNeedsDomain> nursingCareAdditionalNeedsDomain)
        {
            return _mapper.Map<IEnumerable<NursingCareAdditionalNeedsResponse>>(nursingCareAdditionalNeedsDomain);
        }

        #endregion

        #region NursingCareTypeOfStayOptions

        public static IEnumerable<NursingCareTypeOfStayOptionResponse> ToResponse(this IEnumerable<NursingCareTypeOfStayOptionDomain> nursingCareTypeOfStayOptionDomains)
        {
            return nursingCareTypeOfStayOptionDomains.Select(item
                => new NursingCareTypeOfStayOptionResponse
                {
                    TypeOfStayOptionId = item.TypeOfStayOptionId,
                    OptionName = item.OptionName,
                    OptionPeriod = item.OptionPeriod
                }).ToList();
        }

        #endregion

        public static IEnumerable<TypeOfNursingCareHomeResponse> ToResponse(this IEnumerable<TypeOfNursingCareHomeDomain> typeOfNursingCareHomeDomain)
        {
            return _mapper.Map<IEnumerable<TypeOfNursingCareHomeResponse>>(typeOfNursingCareHomeDomain);
        }
    }
}
