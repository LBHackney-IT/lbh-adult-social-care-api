using AutoMapper;
using HttpServices.Models.Requests;
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
using LBH.AdultSocialCare.Api.V1.BusinessRules;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
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
                    opt => opt.MapFrom(b => $"{b.Creator.Name}"))
                .ForMember(dc => dc.UpdaterName,
                    opt => opt.MapFrom(b => $"{b.Updater.Name}"));
            CreateMap<DayCarePackageForCreationRequest, DayCarePackageForCreationDomain>();
            CreateMap<DayCarePackageForUpdateRequest, DayCarePackageForUpdateDomain>();
            CreateMap<DayCarePackageDomain, DayCarePackageResponse>();
            CreateMap<DayCarePackageDomain, EscortPackage>();
            CreateMap<DayCarePackageDomain, TransportPackage>();
            CreateMap<DayCarePackageDomain, TransportEscortPackage>();

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

            #endregion TermTimeConsiderationOptions

            #region OpportunityLengthOptions

            CreateMap<OpportunityLengthOption, OpportunityLengthOptionDomain>();
            CreateMap<OpportunityLengthOptionDomain, OpportunityLengthOptionResponse>();

            #endregion OpportunityLengthOptions

            #region OpportunityTimesPerMonthOptions

            CreateMap<OpportunityTimesPerMonthOption, OpportunityTimesPerMonthOptionDomain>();
            CreateMap<OpportunityTimesPerMonthOptionDomain, OpportunityTimesPerMonthOptionResponse>();

            #endregion OpportunityTimesPerMonthOptions

            #region HomeCarePackage

            CreateMap<HomeCarePackageResponse, HomeCarePackageDomain>();
            CreateMap<HomeCarePackage, HomeCarePackageDomain>();
            CreateMap<HomeCarePackageDomain, HomeCarePackage>();
            CreateMap<HomeCarePackageDomain, HomeCarePackageResponse>();
            CreateMap<HomeCareApprovalHistory, HomeCareApprovalHistoryDomain>();
            CreateMap<HomeCareApprovalHistoryDomain, HomeCareApprovalHistory>();

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
            CreateMap<NursingCareApprovalHistory, NursingCareApprovalHistoryDomain>();
            CreateMap<NursingCareApprovalHistoryDomain, NursingCareApprovalHistory>();
            CreateMap<NursingCarePackage, NursingCarePackagePlainDomain>();
            CreateMap<NursingCarePackagePlainDomain, NursingCarePackageForUpdateDomain>();

            #endregion NursingCarePackage

            #region ResidentialCarePackage

            CreateMap<TypeOfResidentialCareHome, TypeOfResidentialCareHomeDomain>();
            CreateMap<ResidentialCarePackageDomain, ResidentialCarePackageResponse>();
            CreateMap<ResidentialCarePackage, ResidentialCarePackageDomain>();
            CreateMap<ResidentialCarePackageDomain, ResidentialCarePackage>();
            CreateMap<ResidentialCarePackageDomain, ResidentialCarePackageForUpdateDomain>();
            CreateMap<ResidentialCareTypeOfStayOption, ResidentialCareTypeOfStayOptionDomain>();
            CreateMap<ResidentialCareTypeOfStayOptionDomain, ResidentialCareTypeOfStayOptionResponse>();
            CreateMap<ResidentialCarePackageForUpdateRequest, ResidentialCarePackageDomain>();
            CreateMap<ResidentialCarePackageForCreationRequest, ResidentialCarePackageForCreationDomain>();
            CreateMap<ResidentialCareAdditionalNeedForCreationRequest, ResidentialCareAdditionalNeedForCreationDomain>();
            CreateMap<ResidentialCareAdditionalNeedsCreationRequest, ResidentialCareAdditionalNeedForCreationDomain>();
            CreateMap<ResidentialCareAdditionalNeedForCreationDomain, ResidentialCareAdditionalNeed>();
            CreateMap<ResidentialCareAdditionalNeed, ResidentialCareAdditionalNeedsDomain>();
            CreateMap<ResidentialCareAdditionalNeedsDomain, ResidentialCareAdditionalNeedsResponse>();
            CreateMap<ResidentialCarePackageForCreationDomain, ResidentialCarePackage>();
            CreateMap<ResidentialCarePackageForUpdateDomain, ResidentialCarePackage>();
            CreateMap<TypeOfResidentialCareHomeDomain, TypeOfResidentialCareHomeResponse>();
            CreateMap<ResidentialCareApprovalHistory, ResidentialCareApprovalHistoryDomain>();
            CreateMap<ResidentialCareApprovalHistoryDomain, ResidentialCareApprovalHistory>();
            CreateMap<ResidentialCarePackage, ResidentialCarePackagePlainDomain>();
            CreateMap<ResidentialCarePackagePlainDomain, ResidentialCarePackageForUpdateDomain>();

            #endregion ResidentialCarePackage

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

            #endregion HomeCareBrokerage

            #region HomeCareApprovalHistory

            CreateMap<HomeCareApprovalHistoryDomain, HomeCareApprovalHistory>();
            CreateMap<HomeCareApprovalHistory, HomeCareApprovalHistoryDomain>();
            CreateMap<HomeCareApprovalHistoryDomain, HomeCareApprovalHistoryResponse>();

            #endregion HomeCareApprovalHistory

            #region HomeCareApprovePackage

            CreateMap<HomeCareApprovePackageDomain, HomeCareApprovePackageResponse>();
            CreateMap<HomeCareApprovePackageResponse, HomeCareApprovePackageDomain>();

            #endregion HomeCareApprovePackage

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
            CreateMap<SupplierCreationDomain, SupplierCreationRequest>();
            CreateMap<SupplierCreationRequest, SupplierCreationDomain>();
            CreateMap<SupplierCreationDomain, Supplier>();
            CreateMap<Supplier, SupplierCreationDomain>();
            CreateMap<SupplierMinimalDomain, SupplierMinimalResponse>();

            #endregion Supplier

            #region HomeCareApproveBrokered

            CreateMap<HomeCareApproveBrokeredDomain, HomeCareApproveBrokeredResponse>();
            CreateMap<HomeCareApproveBrokeredResponse, HomeCareApproveBrokeredDomain>();
            CreateMap<HomeCarePackageBreakDownDomain, HomeCarePackageBreakDownResponse>();
            CreateMap<HomeCarePackageBreakDownResponse, HomeCarePackageBreakDownDomain>();
            CreateMap<HomeCarePackageElementsCostingDomain, HomeCarePackageElementsCostingResponse>();
            CreateMap<HomeCarePackageElementsCostingResponse, HomeCarePackageElementsCostingDomain>();

            #endregion HomeCareApproveBrokered

            #region DayCareApproveBrokered

            CreateMap<DayCareApproveBrokeredDomain, DayCareApproveBrokeredResponse>();
            CreateMap<DayCareApproveBrokeredResponse, DayCareApproveBrokeredDomain>();
            CreateMap<DayCarePackageBreakDownDomain, DayCarePackageBreakDownResponse>();
            CreateMap<DayCarePackageBreakDownResponse, DayCarePackageBreakDownDomain>();
            CreateMap<DayCarePackageElementsCostingDomain, DayCarePackageElementsCostingResponse>();
            CreateMap<DayCarePackageElementsCostingResponse, DayCarePackageElementsCostingDomain>();

            #endregion DayCareApproveBrokered

            #region DayCareApprovePackage

            CreateMap<DayCareApprovePackageDomain, DayCareApprovePackageResponse>();
            CreateMap<DayCareApprovePackageResponse, DayCareApprovePackageDomain>();
            CreateMap<DayCarePackageForApprovalDetailsDomain, DayCarePackageForApprovalDetailsResponse>();
            CreateMap<DayCareApprovalHistoryForCreationDomain, DayCareApprovalHistory>();

            #endregion DayCareApprovePackage

            #region DayCarePackageBrokerage

            CreateMap<DayCarePackageForBrokerageDomain, DayCarePackageForBrokerageResponse>();
            CreateMap<DayCareBrokerageInfoForCreationRequest, DayCareBrokerageInfoForCreationDomain>();
            CreateMap<DayCareBrokerageInfoForCreationDomain, DayCareBrokerageInfo>();
            CreateMap<DayCareBrokerageInfoDomain, DayCareBrokerageInfo>();
            CreateMap<DayCareBrokerageInfo, DayCareBrokerageInfoDomain>();
            CreateMap<DayCareBrokerageStageDomain, DayCareBrokerageStageResponse>();

            #endregion DayCarePackageBrokerage

            #region NursingCareApprovePackage

            CreateMap<NursingCareApprovePackageDomain, NursingCareApprovePackageResponse>();
            CreateMap<NursingCareApprovePackageResponse, NursingCareApprovePackageDomain>();

            #endregion NursingCareApprovePackage

            #region NursingCareApproveCommercial

            CreateMap<NursingCareApproveCommercialDomain, NursingCareApproveCommercialResponse>();
            CreateMap<NursingCareApproveCommercialResponse, NursingCareApproveCommercialDomain>();

            #endregion NursingCareApproveCommercial

            #region ResidentialCareApprovePackage

            CreateMap<ResidentialCareApprovePackageDomain, ResidentialCareApprovePackageResponse>();
            CreateMap<ResidentialCareApprovePackageResponse, ResidentialCareApprovePackageDomain>();

            #endregion ResidentialCareApprovePackage

            #region ResidentialCareApproveBrokered

            CreateMap<ResidentialCareApproveBrokeredDomain, ResidentialCareApproveBrokeredResponse>();
            CreateMap<ResidentialCareApproveBrokeredResponse, ResidentialCareApproveBrokeredDomain>();

            #endregion ResidentialCareApproveBrokered

            #region NursingCareBrokerage

            CreateMap<NursingCareApprovalHistory, NursingCareApprovalHistoryDomain>();
            CreateMap<NursingCareApprovalHistoryDomain, NursingCareApprovalHistory>();
            CreateMap<NursingCareApprovalHistoryResponse, NursingCareApprovalHistoryDomain>();
            CreateMap<NursingCareApprovalHistoryDomain, NursingCareApprovalHistoryResponse>();
            CreateMap<NursingCareRequestMoreInformationForCreationRequest, NursingCareRequestMoreInformationDomain>();
            CreateMap<NursingCareRequestMoreInformationDomain, NursingCareRequestMoreInformationForCreationRequest>();
            CreateMap<NursingCareRequestMoreInformationDomain, NursingCareRequestMoreInformation>();
            CreateMap<NursingCareRequestMoreInformation, NursingCareRequestMoreInformationDomain>();
            CreateMap<NursingCareRequestMoreInformationDomain, NursingCareRequestMoreInformation>();
            CreateMap<NursingCareBrokerageInfo, NursingCareBrokerageInfoDomain>();
            CreateMap<NursingCareBrokerageInfoDomain, NursingCareBrokerageInfo>();
            CreateMap<NursingCareBrokerageInfoDomain, NursingCareBrokerageInfoResponse>();
            CreateMap<NursingCareBrokerageInfoResponse, NursingCareBrokerageInfoDomain>();
            CreateMap<NursingCareBrokerageInfoCreationDomain, NursingCareBrokerageCreationRequest>();
            CreateMap<NursingCareBrokerageCreationRequest, NursingCareBrokerageInfoCreationDomain>();
            CreateMap<NursingCareAdditionalNeedsCostCreationDomain, NursingCareAdditionalNeedsCostCreationRequest>();
            CreateMap<NursingCareAdditionalNeedsCostCreationRequest, NursingCareAdditionalNeedsCostCreationDomain>();
            CreateMap<NursingCareBrokerageInfoCreationDomain, NursingCareBrokerageInfo>();
            CreateMap<NursingCareBrokerageInfo, NursingCareBrokerageInfoCreationDomain>();
            CreateMap<NursingCareAdditionalNeedsCostCreationDomain, NursingCareAdditionalNeedsCost>();
            CreateMap<NursingCareAdditionalNeedsCost, NursingCareAdditionalNeedsCostCreationDomain>();
            CreateMap<NursingCarePackageDomain, NursingCarePackageForUpdateDomain>();
            CreateMap<NursingCarePackageForUpdateDomain, NursingCarePackageDomain>();
            CreateMap<NursingCareAdditionalNeedsCost, NursingCareAdditionalNeedsCostDomain>();
            CreateMap<NursingCareAdditionalNeedsCostDomain, NursingCareAdditionalNeedsCostResponse>();

            #endregion NursingCareBrokerage

            #region ResidentialCareBrokerage

            CreateMap<ResidentialCareApprovalHistory, ResidentialCareApprovalHistoryDomain>();
            CreateMap<ResidentialCareApprovalHistoryDomain, ResidentialCareApprovalHistory>();
            CreateMap<ResidentialCareApprovalHistoryResponse, ResidentialCareApprovalHistoryDomain>();
            CreateMap<ResidentialCareApprovalHistoryDomain, ResidentialCareApprovalHistoryResponse>();
            CreateMap<ResidentialCareRequestMoreInformationForCreationRequest, ResidentialCareRequestMoreInformationDomain>();
            CreateMap<ResidentialCareRequestMoreInformationDomain, ResidentialCareRequestMoreInformationForCreationRequest>();
            CreateMap<ResidentialCareRequestMoreInformationDomain, ResidentialCareRequestMoreInformation>();
            CreateMap<ResidentialCareRequestMoreInformation, ResidentialCareRequestMoreInformationDomain>();
            CreateMap<ResidentialCareBrokerageInfo, ResidentialCareBrokerageInfoDomain>();
            CreateMap<ResidentialCareBrokerageInfoDomain, ResidentialCareBrokerageInfo>();
            CreateMap<ResidentialCareBrokerageInfoDomain, ResidentialCareBrokerageInfoResponse>();
            CreateMap<ResidentialCareBrokerageInfoResponse, ResidentialCareBrokerageInfoDomain>();
            CreateMap<ResidentialCareBrokerageForCreationDomain, ResidentialCareBrokerageForCreationRequest>();
            CreateMap<ResidentialCareBrokerageForCreationRequest, ResidentialCareBrokerageForCreationDomain>();
            CreateMap<ResidentialCareAdditionalNeedsCostCreationDomain, ResidentialCareAdditionalNeedsCostCreationRequest>();
            CreateMap<ResidentialCareAdditionalNeedsCostCreationRequest, ResidentialCareAdditionalNeedsCostCreationDomain>();
            CreateMap<ResidentialCareBrokerageForCreationDomain, ResidentialCareBrokerageInfo>();
            CreateMap<ResidentialCareBrokerageInfo, ResidentialCareBrokerageForCreationDomain>();
            CreateMap<ResidentialCareAdditionalNeedsCostCreationDomain, ResidentialCareAdditionalNeedsCost>();
            CreateMap<ResidentialCareAdditionalNeedsCost, ResidentialCareAdditionalNeedsCostCreationDomain>();
            CreateMap<ResidentialCareAdditionalNeedsCost, ResidentialCareAdditionalNeedsCostDomain>();
            CreateMap<ResidentialCareAdditionalNeedsCostDomain, ResidentialCareAdditionalNeedsCostResponse>();

            #endregion ResidentialCareBrokerage

            #region Stage

            CreateMap<Stage, StageDomain>();
            CreateMap<StageDomain, Stage>();
            CreateMap<StageDomain, StageResponse>();
            CreateMap<StageResponse, StageDomain>();

            #endregion Stage

            #region DayCareCollege

            CreateMap<DayCarePackageForCreationDomain, DayCareCollege>();
            CreateMap<DayCarePackageForUpdateDomain, DayCareCollege>();
            CreateMap<DayCareCollege, DayCareCollegeDomain>();
            CreateMap<DayCareCollegeForCreationRequest, DayCareCollegeForCreationDomain>();
            CreateMap<DayCareCollegeForCreationDomain, DayCareCollege>();
            CreateMap<DayCareCollegeDomain, DayCareCollegeResponse>();

            #endregion DayCareCollege

            #region ServiceUsers

            CreateMap<User, UsersDomain>();
            CreateMap<UsersDomain, UsersResponse>();
            CreateMap<UsersMinimalDomain, UsersMinimalResponse>();

            #endregion ServiceUsers

            #region DayCareBrokerage

            CreateMap<DayCareRequestMoreInformationForCreationRequest, DayCareRequestMoreInformationDomain>();
            CreateMap<DayCareRequestMoreInformationDomain, DayCareRequestMoreInformationForCreationRequest>();

            #endregion DayCareBrokerage

            #region PackageReclaim

            CreateMap<HomeCarePackageReclaim, HomeCarePackageClaimDomain>();
            CreateMap<HomeCarePackageClaimDomain, HomeCarePackageReclaim>();
            CreateMap<HomeCarePackageClaimDomain, HomeCarePackageClaimResponse>();
            CreateMap<HomeCarePackageClaimResponse, HomeCarePackageClaimDomain>();
            CreateMap<HomeCarePackageClaimCreationDomain, HomeCarePackageClaimCreationRequest>();
            CreateMap<HomeCarePackageClaimCreationRequest, HomeCarePackageClaimCreationDomain>();
            CreateMap<HomeCarePackageClaimCreationDomain, HomeCarePackageReclaim>();
            CreateMap<HomeCarePackageReclaim, HomeCarePackageClaimCreationDomain>();
            CreateMap<ReclaimAmountOption, ReclaimAmountOptionDomain>();
            CreateMap<ReclaimAmountOptionDomain, ReclaimAmountOptionResponse>();
            CreateMap<ReclaimCategory, ReclaimCategoryDomain>();
            CreateMap<ReclaimCategoryDomain, ReclaimCategoryResponse>();
            CreateMap<ReclaimFrom, ReclaimFromDomain>();
            CreateMap<ReclaimFromDomain, ReclaimFromResponse>();
            CreateMap<DayCarePackageReclaim, DayCarePackageClaimDomain>();
            CreateMap<DayCarePackageClaimDomain, DayCarePackageReclaim>();
            CreateMap<DayCarePackageClaimDomain, DayCarePackageClaimResponse>();
            CreateMap<DayCarePackageClaimResponse, DayCarePackageClaimDomain>();
            CreateMap<DayCarePackageClaimCreationDomain, DayCarePackageClaimCreationRequest>();
            CreateMap<DayCarePackageClaimCreationRequest, DayCarePackageClaimCreationDomain>();
            CreateMap<DayCarePackageClaimCreationDomain, DayCarePackageReclaim>();
            CreateMap<DayCarePackageReclaim, DayCarePackageClaimCreationDomain>();
            CreateMap<NursingCarePackageReclaim, NursingCarePackageClaimDomain>();
            CreateMap<NursingCarePackageClaimDomain, NursingCarePackageReclaim>();
            CreateMap<NursingCarePackageClaimDomain, NursingCarePackageClaimResponse>();
            CreateMap<NursingCarePackageClaimResponse, NursingCarePackageClaimDomain>();
            CreateMap<NursingCarePackageClaimCreationDomain, NursingCarePackageClaimCreationRequest>();
            CreateMap<NursingCarePackageClaimCreationRequest, NursingCarePackageClaimCreationDomain>();
            CreateMap<NursingCarePackageClaimCreationDomain, NursingCarePackageReclaim>();
            CreateMap<NursingCarePackageReclaim, NursingCarePackageClaimCreationDomain>();
            CreateMap<ResidentialCarePackageReclaim, ResidentialCarePackageClaimDomain>();
            CreateMap<ResidentialCarePackageClaimDomain, ResidentialCarePackageReclaim>();
            CreateMap<ResidentialCarePackageClaimDomain, ResidentialCarePackageClaimResponse>();
            CreateMap<ResidentialCarePackageClaimResponse, ResidentialCarePackageClaimDomain>();
            CreateMap<ResidentialCarePackageClaimCreationDomain, ResidentialCarePackageClaimCreationRequest>();
            CreateMap<ResidentialCarePackageClaimCreationRequest, ResidentialCarePackageClaimCreationDomain>();
            CreateMap<ResidentialCarePackageClaimCreationDomain, ResidentialCarePackageReclaim>();
            CreateMap<ResidentialCarePackageReclaim, ResidentialCarePackageClaimCreationDomain>();

            #endregion PackageReclaim

            #region HomeCarePackageSlots

            CreateMap<HomeCarePackageSlotRequest, HomeCarePackageSlotDomain>();

            #endregion HomeCarePackageSlots

            #region Roles

            CreateMap<Role, RolesDomain>();
            CreateMap<RoleForCreationRequest, RoleForCreationDomain>();
            CreateMap<RoleForUpdateRequest, RoleForUpdateDomain>();
            CreateMap<RoleForCreationDomain, Role>();
            CreateMap<RoleForUpdateDomain, Role>();
            CreateMap<RolesDomain, RoleResponse>();
            CreateMap<AssignRolesToUserRequest, AssignRolesToUserDomain>();
            CreateMap<HackneyTokenRequest, HackneyTokenDomain>();

            #endregion Roles

            #region SupplierBill

            CreateMap<SupplierBillDomain, SupplierBillResponse>();
            CreateMap<SupplierBillItemDomain, SupplierBillItemResponse>();

            #endregion SupplierBill

            #region PrimarySupportReason

            CreateMap<PrimarySupportReason, PrimarySupportReasonDomain>();
            CreateMap<PrimarySupportReasonDomain, PrimarySupportReasonResponse>();

            #endregion PrimarySupportReason

            #region SubmittedPackageRequests

            CreateMap<SubmittedPackageRequestsDomain, SubmittedPackageRequestsResponse>();

            #endregion SubmittedPackageRequests

            #region ApprovedPackages

            CreateMap<ApprovedPackagesDomain, ApprovedPackagesResponse>();

            #endregion ApprovedPackages

            #region BrokeredPackages

            CreateMap<BrokeredPackagesDomain, BrokeredPackagesResponse>();

            #endregion BrokeredPackages

            #region PackageStatus

            CreateMap<PackageStatus, StatusDomain>();
            CreateMap<StatusDomain, StatusResponse>();

            #endregion PackageStatus

            #region Invoice

            CreateMap<InvoiceDomain, InvoiceResponse>();
            CreateMap<InvoiceItemDomain, InvoiceItemResponse>();
            CreateMap<InvoiceForCreationRequest, InvoiceResponse>();
            CreateMap<InvoiceItemForCreationRequest, InvoiceItemResponse>();

            CreateMap<InvoiceResponse, InvoiceForCreationRequest>();
            CreateMap<InvoiceItemResponse, InvoiceItemForCreationRequest>();

            #endregion Invoice

            #region Clients

            CreateMap<ClientMinimalDomain, ClientMinimalResponse>();
            CreateMap<ClientsDomain, ClientsResponse>();
            CreateMap<Client, ClientsDomain>();

            #endregion Clients

            #region AdditionalNeedsPaymentType

            CreateMap<AdditionalNeedsPaymentType, AdditionalNeedsPaymentTypeDomain>();
            CreateMap<AdditionalNeedsPaymentTypeDomain, AdditionalNeedsPaymentTypeResponse>();

            #endregion AdditionalNeedsPaymentType

            #region Funded Nursing Care

            CreateMap<FundedNursingCare, FundedNursingCareDomain>();
            CreateMap<FundedNursingCareDomain, FundedNursingCare>();

            CreateMap<FundedNursingCareCollector, FundedNursingCareCollectorDomain>();
            CreateMap<FundedNursingCareCollectorDomain, FundedNursingCareCollectorResponse>();

            CreateMap<FundedNursingCarePrice, FundedNursingCarePriceDomain>();

            #endregion Funded Nursing Care

            #region Care Charges

            CreateMap<ProvisionalCareChargeAmount, ProvisionalCareChargeAmountPlainDomain>();
            CreateMap<ProvisionalCareChargeAmountPlainDomain, ProvisionalCareChargeAmountPlainResponse>().ReverseMap();
            CreateMap<BrokerageCareChargeForChangeRequest, BrokerageCareChargeForChangeDomain>();
            CreateMap<PackageCareCharge, PackageCareChargePlainDomain>();
            CreateMap<InvoiceCreditNote, InvoiceCreditNotePlainDomain>();

            #endregion Care Charges

            #region Invoicing

            CreateMap<NursingCareBrokerageInfo, BrokerageInfo>()
                .ForMember(d => d.Core, opt => opt.MapFrom(s => s.NursingCore))
                .ForMember(d => d.AdditionalNeedsCosts, opt => opt.MapFrom(s => s.NursingCareAdditionalNeedsCosts));

            CreateMap<ResidentialCareBrokerageInfo, BrokerageInfo>()
                .ForMember(d => d.Core, opt => opt.MapFrom(s => s.ResidentialCore))
                .ForMember(d => d.AdditionalNeedsCosts, opt => opt.MapFrom(s => s.ResidentialCareAdditionalNeedsCosts));

            CreateMap<NursingCareAdditionalNeedsCost, AdditionalNeedsCost>()
                .ForMember(d => d.Cost, opt => opt.MapFrom(s => s.AdditionalNeedsCost));

            CreateMap<ResidentialCareAdditionalNeedsCost, AdditionalNeedsCost>()
                .ForMember(d => d.Cost, opt => opt.MapFrom(s => s.AdditionalNeedsCost));

            CreateMap<NursingCarePackage, GenericPackage>()
                .ForMember(d => d.BrokerageInfo, opt => opt.MapFrom(s => s.NursingCareBrokerageInfo))
                .ForMember(d => d.OriginalPackage, opt => opt.MapFrom(s => s));

            CreateMap<ResidentialCarePackage, GenericPackage>()
                .ForMember(d => d.BrokerageInfo, opt => opt.MapFrom(s => s.ResidentialCareBrokerageInfo))
                .ForMember(d => d.OriginalPackage, opt => opt.MapFrom(s => s));

            #endregion Invoicing
        }
    }
}
