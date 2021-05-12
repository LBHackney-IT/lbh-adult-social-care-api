using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCareApproveBrokeredBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCareApprovePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCareBrokerageBoundary.Request;
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
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareBrokerageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareApprovalHistoryBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareApprovePackageDomains;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareApprovePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareBrokerageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Domain.SupplierDomains;
using LBH.AdultSocialCare.Api.V1.Boundary.Response.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareApproveBrokeredDomains;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareApproveBrokeredBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareApprovalHistoryBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareApproveCommercialBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareApprovePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareBrokerageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareApprovalHistoryBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareApproveBrokeredBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareApproveBrokeredBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareApprovePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.StageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.SupplierBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.SupplierBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.DayCareApproveBrokeredDomains;
using LBH.AdultSocialCare.Api.V1.Domain.DayCareApprovePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.DayCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareApproveCommercialDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareApprovePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareApproveBrokeredDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareApprovePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.StageDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;

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

            #region HomeCareBrokerage

            CreateMap<HomeCarePackageCost, HomeCarePackageCostDomain>();
            CreateMap<HomeCarePackageCostDomain, HomeCarePackageCostResponse>();
            CreateMap<HomeCarePackageCostDomain, HomeCarePackageCost>();
            CreateMap<HomeCareBrokerageDomain, HomeCareBrokerageResponse>();
            CreateMap<HomeCareBrokerageCreationDomain, HomeCareBrokerageCreationRequest>();
            CreateMap<HomeCareBrokerageCreationRequest, HomeCareBrokerageCreationDomain>();
            CreateMap<HomeCarePackageCostCreationDomain, HomeCarePackageCostCreationRequest>();
            CreateMap<HomeCarePackageCostCreationRequest, HomeCarePackageCostCreationDomain>();
            CreateMap<HomeCareBrokerageResponse, HomeCareBrokerageCreationDomain>();
            CreateMap<HomeCareBrokerageCreationDomain, HomeCareBrokerageResponse>();
            CreateMap<HomeCarePackageCostCreationDomain, HomeCarePackageCostResponse>();
            CreateMap<HomeCarePackageCostResponse, HomeCarePackageCostCreationDomain>();
            CreateMap<HomeCareRequestMoreInformationDomain, HomeCareRequestMoreInformation>();
            CreateMap<HomeCareApprovalHistory, HomeCareApprovalHistoryDomain>();
            CreateMap<HomeCareApprovalHistoryDomain, HomeCareApprovalHistory>();
            CreateMap<HomeCareApprovalHistoryResponse, HomeCareApprovalHistoryDomain>();
            CreateMap<HomeCareApprovalHistoryDomain, HomeCareApprovalHistoryResponse>();
            CreateMap<CarerTypeDomain, CarerType>();
            CreateMap<CarerType, CarerTypeDomain>();
            CreateMap<CarerTypeResponse, CarerTypeDomain>();
            CreateMap<CarerTypeDomain, CarerTypeResponse>();
            CreateMap<HomeCareRequestMoreInformationForCreationRequest, HomeCareRequestMoreInformationDomain>();
            CreateMap<HomeCareRequestMoreInformationDomain, HomeCareRequestMoreInformationForCreationRequest>();

            #endregion

            #region HomeCareApprovalHistory

            CreateMap<HomeCareApprovalHistoryDomain, HomeCareApprovalHistory>();
            CreateMap<HomeCareApprovalHistory, HomeCareApprovalHistoryDomain>();
            CreateMap<HomeCareApprovalHistoryDomain, HomeCareApprovalHistoryResponse>();

            #endregion

            #region HomeCareApprovePackage

            CreateMap<HomeCareApprovePackageDomain, HomeCareApprovePackageResponse>();
            CreateMap<HomeCareApprovePackageResponse, HomeCareApprovePackageDomain>();

            #endregion

            #region Supplier

            CreateMap<Supplier, SupplierDomain>();
            CreateMap<SupplierDomain, Supplier>();
            CreateMap<SupplierDomain, SupplierResponse>();
            CreateMap<SupplierResponse, SupplierDomain>();
            CreateMap<HomeCareSupplierCostDomain, HomeCareSupplierCost>();
            CreateMap<HomeCareSupplierCostCreationDomain, HomeCareSupplierCost>();
            CreateMap<HomeCareSupplierCost, HomeCareSupplierCostDomain>();
            CreateMap<HomeCareSupplierCost, HomeCareSupplierCostCreationDomain>();
            CreateMap<SupplierCostCreationRequest, HomeCareSupplierCostCreationDomain>();
            CreateMap<HomeCareSupplierCostCreationDomain, SupplierCostCreationRequest>();

            #endregion

            #region HomeCareApproveBrokered

            CreateMap<HomeCareApproveBrokeredDomain, HomeCareApproveBrokeredResponse>();
            CreateMap<HomeCareApproveBrokeredResponse, HomeCareApproveBrokeredDomain>();
            CreateMap<HomeCarePackageBreakDownDomain, HomeCarePackageBreakDownResponse>();
            CreateMap<HomeCarePackageBreakDownResponse, HomeCarePackageBreakDownDomain>();
            CreateMap<HomeCarePackageElementsCostingDomain, HomeCarePackageElementsCostingResponse>();
            CreateMap<HomeCarePackageElementsCostingResponse, HomeCarePackageElementsCostingDomain>();

            #endregion

            #region DayCareApproveBrokered

            CreateMap<DayCareApproveBrokeredDomain, DayCareApproveBrokeredResponse>();
            CreateMap<DayCareApproveBrokeredResponse, DayCareApproveBrokeredDomain>();
            CreateMap<DayCarePackageBreakDownDomain, DayCarePackageBreakDownResponse>();
            CreateMap<DayCarePackageBreakDownResponse, DayCarePackageBreakDownDomain>();
            CreateMap<DayCarePackageElementsCostingDomain, DayCarePackageElementsCostingResponse>();
            CreateMap<DayCarePackageElementsCostingResponse, DayCarePackageElementsCostingDomain>();

            #endregion

            #region DayCareApprovePackage

            CreateMap<DayCareApprovePackageDomain, DayCareApprovePackageResponse>();
            CreateMap<DayCareApprovePackageResponse, DayCareApprovePackageDomain>();

            #endregion

            #region NursingCareApprovePackage

            CreateMap<NursingCareApprovePackageDomain, NursingCareApprovePackageResponse>();
            CreateMap<NursingCareApprovePackageResponse, NursingCareApprovePackageDomain>();

            #endregion

            #region NursingCareApproveCommercial

            CreateMap<NursingCareApproveCommercialDomain, NursingCareApproveCommercialResponse>();
            CreateMap<NursingCareApproveCommercialResponse, NursingCareApproveCommercialDomain>();

            #endregion

            #region ResidentialCareApprovePackage

            CreateMap<ResidentialCareApprovePackageDomain, ResidentialCareApprovePackageResponse>();
            CreateMap<ResidentialCareApprovePackageResponse, ResidentialCareApprovePackageDomain>();

            #endregion

            #region ResidentialCareApproveBrokered

            CreateMap<ResidentialCareApproveBrokeredDomain, ResidentialCareApproveBrokeredResponse>();
            CreateMap<ResidentialCareApproveBrokeredResponse, ResidentialCareApproveBrokeredDomain>();

            #endregion

            #region NursingCareBrokerage

            CreateMap<NursingCareApprovalHistory, NursingCareApprovalHistoryDomain>();
            CreateMap<NursingCareApprovalHistoryDomain, NursingCareApprovalHistory>();
            CreateMap<NursingCareApprovalHistoryResponse, NursingCareApprovalHistoryDomain>();
            CreateMap<NursingCareApprovalHistoryDomain, NursingCareApprovalHistoryResponse>();
            CreateMap<NursingCareRequestMoreInformationForCreationRequest, NursingCareRequestMoreInformationDomain>();
            CreateMap<NursingCareRequestMoreInformationDomain, NursingCareRequestMoreInformationForCreationRequest>();

            #endregion

            #region ResidentialCareBrokerage

            CreateMap<ResidentialCareApprovalHistory, ResidentialCareApprovalHistoryDomain>();
            CreateMap<ResidentialCareApprovalHistoryDomain, ResidentialCareApprovalHistory>();
            CreateMap<ResidentialCareApprovalHistoryResponse, ResidentialCareApprovalHistoryDomain>();
            CreateMap<ResidentialCareApprovalHistoryDomain, ResidentialCareApprovalHistoryResponse>();
            CreateMap<ResidentialCareRequestMoreInformationForCreationRequest, ResidentialCareRequestMoreInformationDomain>();
            CreateMap<ResidentialCareRequestMoreInformationDomain, ResidentialCareRequestMoreInformationForCreationRequest>();

            #endregion

            #region Stage

            CreateMap<Stage, StageDomain>();
            CreateMap<StageDomain, Stage>();
            CreateMap<StageDomain, StageResponse>();
            CreateMap<StageResponse, StageDomain>();

            #endregion

            #region DayCareCollege

            CreateMap<DayCarePackageForCreationDomain, DayCareCollege>();
            CreateMap<DayCarePackageForUpdateDomain, DayCareCollege>();
            CreateMap<DayCareCollege, DayCareCollegeDomain>();
            CreateMap<DayCareCollegeForCreationRequest, DayCareCollegeForCreationDomain>();
            CreateMap<DayCareCollegeDomain, DayCareCollegeResponse>();

            #endregion DayCareCollege

            #region DayCareBrokerage

            CreateMap<DayCareRequestMoreInformationForCreationRequest, DayCareRequestMoreInformationDomain>();
            CreateMap<DayCareRequestMoreInformationDomain, DayCareRequestMoreInformationForCreationRequest>();

            #endregion
        }
    }
}
