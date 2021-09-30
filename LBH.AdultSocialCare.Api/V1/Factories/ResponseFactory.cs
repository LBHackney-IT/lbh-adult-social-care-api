using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using System.Collections.Generic;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class ResponseFactory
    {
        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region DayCarePackage

        public static DayCarePackageResponse ToResponse(this DayCarePackageDomain dayCarePackageDomain)
        {
            return _mapper.Map<DayCarePackageResponse>(dayCarePackageDomain);
        }

        public static DayCarePackageForApprovalDetailsResponse ToResponse(this DayCarePackageForApprovalDetailsDomain dayCarePackageForApprovalDetailsDomain)
        {
            return _mapper.Map<DayCarePackageForApprovalDetailsResponse>(dayCarePackageForApprovalDetailsDomain);
        }

        public static IEnumerable<DayCarePackageResponse> ToResponse(this IEnumerable<DayCarePackageDomain> dayCarePackageDomains)
        {
            return _mapper.Map<IEnumerable<DayCarePackageResponse>>(dayCarePackageDomains);
        }

        #endregion DayCarePackage

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

        #endregion TermTimeConsiderations

        #region OpportunityLengthOptions

        public static IEnumerable<OpportunityLengthOptionResponse> ToResponse(this IEnumerable<OpportunityLengthOptionDomain> opportunityLengthOptionDomains)
        {
            return _mapper.Map<IEnumerable<OpportunityLengthOptionResponse>>(opportunityLengthOptionDomains);
        }

        #endregion OpportunityLengthOptions

        #region OpportunityTimesPerMonthOptions

        public static IEnumerable<OpportunityTimesPerMonthOptionResponse> ToResponse(this IEnumerable<OpportunityTimesPerMonthOptionDomain> opportunityTimesPerMonthOptionDomains)
        {
            return _mapper.Map<IEnumerable<OpportunityTimesPerMonthOptionResponse>>(opportunityTimesPerMonthOptionDomains);
        }

        #endregion OpportunityTimesPerMonthOptions

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
                HasRespiteCare = nursingCarePackageDomain.HasRespiteCare,
                HasDischargePackage = nursingCarePackageDomain.HasDischargePackage,
                IsThisAnImmediateService = nursingCarePackageDomain.IsThisAnImmediateService,
                IsThisUserUnderS117 = nursingCarePackageDomain.IsThisUserUnderS117,
                TypeOfStayId = nursingCarePackageDomain.TypeOfStayId,
                NeedToAddress = nursingCarePackageDomain.NeedToAddress,
                TypeOfNursingCareHomeId = nursingCarePackageDomain.TypeOfNursingCareHomeId,
                CreatorId = nursingCarePackageDomain.CreatorId,
                UpdaterId = nursingCarePackageDomain.UpdaterId,
                StatusId = nursingCarePackageDomain.StatusId,
                ClientName = nursingCarePackageDomain.ClientName,
                ClientHackneyId = nursingCarePackageDomain.ClientHackneyId,
                ClientPostCode = nursingCarePackageDomain.ClientPostCode,
                ClientDateOfBirth = nursingCarePackageDomain.ClientDateOfBirth,
                ClientCanSpeakEnglish = nursingCarePackageDomain.ClientCanSpeakEnglish,
                ClientPreferredContact = nursingCarePackageDomain.ClientPreferredContact,
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

        #endregion NursingCarePackage

        #region NursingCareAdditionalNeed

        public static IEnumerable<NursingCareAdditionalNeedsResponse> ToResponse(this IEnumerable<NursingCareAdditionalNeedsDomain> nursingCareAdditionalNeedsDomain)
        {
            return _mapper.Map<IEnumerable<NursingCareAdditionalNeedsResponse>>(nursingCareAdditionalNeedsDomain);
        }

        public static IEnumerable<AdditionalNeedsPaymentTypeResponse> ToResponse(this IEnumerable<AdditionalNeedsPaymentTypeDomain> additionalNeedsPaymentTypeDomains)
        {
            return _mapper.Map<IEnumerable<AdditionalNeedsPaymentTypeResponse>>(additionalNeedsPaymentTypeDomains);
        }

        #endregion NursingCareAdditionalNeed

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

        #endregion NursingCareTypeOfStayOptions

        public static IEnumerable<TypeOfNursingCareHomeResponse> ToResponse(this IEnumerable<TypeOfNursingCareHomeDomain> typeOfNursingCareHomeDomain)
        {
            return _mapper.Map<IEnumerable<TypeOfNursingCareHomeResponse>>(typeOfNursingCareHomeDomain);
        }

        #region ResidentialCarePackage

        public static ResidentialCarePackageResponse ToResponse(this ResidentialCarePackageDomain residentialCarePackageDomain)
        {
            // return _mapper.Map<NursingCarePackageResponse>(nursingCarePackageDomain);
            return new ResidentialCarePackageResponse
            {
                Id = residentialCarePackageDomain.Id,
                ClientId = residentialCarePackageDomain.ClientId,
                IsFixedPeriod = residentialCarePackageDomain.IsFixedPeriod,
                StartDate = residentialCarePackageDomain.StartDate,
                EndDate = residentialCarePackageDomain.EndDate,
                HasRespiteCare = residentialCarePackageDomain.HasRespiteCare,
                HasDischargePackage = residentialCarePackageDomain.HasDischargePackage,
                IsThisAnImmediateService = residentialCarePackageDomain.IsThisAnImmediateService,
                IsThisUserUnderS117 = residentialCarePackageDomain.IsThisUserUnderS117,
                TypeOfStayId = residentialCarePackageDomain.TypeOfStayId,
                NeedToAddress = residentialCarePackageDomain.NeedToAddress,
                TypeOfResidentialCareHomeId = residentialCarePackageDomain.TypeOfResidentialCareHomeId,
                CreatorId = residentialCarePackageDomain.CreatorId,
                UpdaterId = residentialCarePackageDomain.UpdaterId,
                StatusId = residentialCarePackageDomain.StatusId,
                ClientName = residentialCarePackageDomain.ClientName,
                ClientHackneyId = residentialCarePackageDomain.ClientHackneyId,
                ClientPostCode = residentialCarePackageDomain.ClientPostCode,
                ClientDateOfBirth = residentialCarePackageDomain.ClientDateOfBirth,
                ClientCanSpeakEnglish = residentialCarePackageDomain.ClientCanSpeakEnglish,
                ClientPreferredContact = residentialCarePackageDomain.ClientPreferredContact,
                StatusName = residentialCarePackageDomain.StatusName,
                CreatorName = residentialCarePackageDomain.CreatorName,
                UpdaterName = residentialCarePackageDomain.UpdaterName,
                PackageName = residentialCarePackageDomain.PackageName,
                TypeOfCareHomeName = residentialCarePackageDomain.TypeOfCareHomeName,
                TypeOfStayOptionName = residentialCarePackageDomain.TypeOfStayOptionName,
                ResidentialCareAdditionalNeeds = residentialCarePackageDomain.ResidentialCareAdditionalNeeds.ToResponse()
            };
        }

        public static IEnumerable<ResidentialCarePackageResponse> ToResponse(this IEnumerable<ResidentialCarePackageDomain> residentialCarePackageDomains)
        {
            return _mapper.Map<IEnumerable<ResidentialCarePackageResponse>>(residentialCarePackageDomains);
        }

        #endregion ResidentialCarePackage

        #region ResidentialCareAdditionalNeed

        public static IEnumerable<ResidentialCareAdditionalNeedsResponse> ToResponse(this IEnumerable<ResidentialCareAdditionalNeedsDomain> residentialCareAdditionalNeedsDomain)
        {
            return _mapper.Map<IEnumerable<ResidentialCareAdditionalNeedsResponse>>(residentialCareAdditionalNeedsDomain);
        }

        #endregion ResidentialCareAdditionalNeed

        #region ResidentialCareTypeOfStayOptions

        public static IEnumerable<ResidentialCareTypeOfStayOptionResponse> ToResponse(this IEnumerable<ResidentialCareTypeOfStayOptionDomain> residentialCareTypeOfStayOptionDomains)
        {
            return residentialCareTypeOfStayOptionDomains.Select(item
                => new ResidentialCareTypeOfStayOptionResponse
                {
                    TypeOfStayOptionId = item.TypeOfStayOptionId,
                    OptionName = item.OptionName,
                    OptionPeriod = item.OptionPeriod
                }).ToList();
        }

        #endregion ResidentialCareTypeOfStayOptions

        public static IEnumerable<TypeOfResidentialCareHomeResponse> ToResponse(this IEnumerable<TypeOfResidentialCareHomeDomain> typeOfResidentialCareHomeDomain)
        {
            return _mapper.Map<IEnumerable<TypeOfResidentialCareHomeResponse>>(typeOfResidentialCareHomeDomain);
        }

        #region Supplier

        public static SupplierResponse ToResponse(this SupplierDomain supplierDomain)
        {
            return _mapper.Map<SupplierResponse>(supplierDomain);
        }

        public static IEnumerable<SupplierResponse> ToResponse(this IEnumerable<SupplierDomain> supplierDomain)
        {
            return _mapper.Map<IEnumerable<SupplierResponse>>(supplierDomain);
        }

        public static IEnumerable<HomeCareSupplierCostResponse> ToResponse(this IEnumerable<HomeCareSupplierCostDomain> homeCareSupplierCostDomains)
        {
            return _mapper.Map<IEnumerable<HomeCareSupplierCostResponse>>(homeCareSupplierCostDomains);
        }

        #endregion Supplier

        #region HomeCareBrokerage

        public static IEnumerable<StageResponse> ToResponse(this IEnumerable<StageDomain> homeCareStageDomains)
        {
            return _mapper.Map<IEnumerable<StageResponse>>(homeCareStageDomains);
        }

        public static HomeCareBrokerageResponse ToResponse(this HomeCareBrokerageDomain homeCareBrokerageDomain)
        {
            return _mapper.Map<HomeCareBrokerageResponse>(homeCareBrokerageDomain);
        }

        public static HomeCareBrokerageResponse ToResponse(this HomeCareBrokerageCreationDomain homeCareBrokerageDomain)
        {
            return _mapper.Map<HomeCareBrokerageResponse>(homeCareBrokerageDomain);
        }

        public static IEnumerable<HomeCareApprovalHistoryResponse> ToResponse(this IEnumerable<HomeCareApprovalHistoryDomain> homeCareApprovalHistoryDomain)
        {
            return _mapper.Map<IEnumerable<HomeCareApprovalHistoryResponse>>(homeCareApprovalHistoryDomain);
        }

        #endregion HomeCareBrokerage

        #region HomeCareApprovePackage

        public static HomeCareApprovePackageResponse ToResponse(this HomeCareApprovePackageDomain homeCareApprovePackageDomain)
        {
            return _mapper.Map<HomeCareApprovePackageResponse>(homeCareApprovePackageDomain);
        }

        #endregion HomeCareApprovePackage

        #region HomeCareApproveBrokered

        public static HomeCareApproveBrokeredResponse ToResponse(this HomeCareApproveBrokeredDomain homeCareApproveBrokeredDomain)
        {
            return _mapper.Map<HomeCareApproveBrokeredResponse>(homeCareApproveBrokeredDomain);
        }

        #endregion HomeCareApproveBrokered

        #region DayCareApproveBrokered

        public static DayCareApproveBrokeredResponse ToResponse(this DayCareApproveBrokeredDomain dayCareApproveBrokeredDomain)
        {
            return _mapper.Map<DayCareApproveBrokeredResponse>(dayCareApproveBrokeredDomain);
        }

        #endregion DayCareApproveBrokered

        #region DayCareApprovePackage

        public static DayCareApprovePackageResponse ToResponse(this DayCareApprovePackageDomain dayCareApprovePackageDomain)
        {
            return _mapper.Map<DayCareApprovePackageResponse>(dayCareApprovePackageDomain);
        }

        #endregion DayCareApprovePackage

        #region NursingCareApprovePackage

        public static NursingCareApprovePackageResponse ToResponse(this NursingCareApprovePackageDomain nursingCareApprovePackageDomain)
        {
            return _mapper.Map<NursingCareApprovePackageResponse>(nursingCareApprovePackageDomain);
        }

        #endregion NursingCareApprovePackage

        #region NursingCareApproveCommercial

        public static NursingCareApproveCommercialResponse ToResponse(this NursingCareApproveCommercialDomain nursingCareApproveCommercialDomain)
        {
            return _mapper.Map<NursingCareApproveCommercialResponse>(nursingCareApproveCommercialDomain);
        }

        #endregion NursingCareApproveCommercial

        #region ResidentialCareApprovePackage

        public static ResidentialCareApprovePackageResponse ToResponse(this ResidentialCareApprovePackageDomain residentialCareApprovePackageDomain)
        {
            return _mapper.Map<ResidentialCareApprovePackageResponse>(residentialCareApprovePackageDomain);
        }

        #endregion ResidentialCareApprovePackage

        #region ResidentialCareApproveBrokered

        public static ResidentialCareApproveBrokeredResponse ToResponse(this ResidentialCareApproveBrokeredDomain residentialCareApproveBrokeredDomain)
        {
            return _mapper.Map<ResidentialCareApproveBrokeredResponse>(residentialCareApproveBrokeredDomain);
        }

        #endregion ResidentialCareApproveBrokered

        #region NursingCareBrokerage

        public static IEnumerable<NursingCareApprovalHistoryResponse> ToResponse(this IEnumerable<NursingCareApprovalHistoryDomain> nursingCareApprovalHistoryDomain)
        {
            return _mapper.Map<IEnumerable<NursingCareApprovalHistoryResponse>>(nursingCareApprovalHistoryDomain);
        }

        public static NursingCareBrokerageInfoResponse ToResponse(this NursingCareBrokerageInfoDomain nursingCareBrokerageInfoDomain)
        {
            return _mapper.Map<NursingCareBrokerageInfoResponse>(nursingCareBrokerageInfoDomain);
        }

        #endregion NursingCareBrokerage

        #region ResidentialCareBrokerage

        public static IEnumerable<ResidentialCareApprovalHistoryResponse> ToResponse(this IEnumerable<ResidentialCareApprovalHistoryDomain> residentialCareApprovalHistoryDomain)
        {
            return _mapper.Map<IEnumerable<ResidentialCareApprovalHistoryResponse>>(residentialCareApprovalHistoryDomain);
        }

        public static ResidentialCareBrokerageInfoResponse ToResponse(this ResidentialCareBrokerageInfoDomain residentialCareBrokerageInfoDomain)
        {
            return _mapper.Map<ResidentialCareBrokerageInfoResponse>(residentialCareBrokerageInfoDomain);
        }

        #endregion ResidentialCareBrokerage

        #region DayCareCollege

        public static DayCareCollegeResponse ToResponse(this DayCareCollegeDomain dayCareCollegeDomain)
        {
            return _mapper.Map<DayCareCollegeResponse>(dayCareCollegeDomain);
        }

        public static IEnumerable<DayCareCollegeResponse> ToResponse(this IEnumerable<DayCareCollegeDomain> dayCareCollegeDomain)
        {
            return _mapper.Map<IEnumerable<DayCareCollegeResponse>>(dayCareCollegeDomain);
        }

        #endregion DayCareCollege

        #region PackageReclaim

        public static HomeCarePackageClaimResponse ToResponse(this HomeCarePackageClaimDomain homeCarePackageClaimDomain)
        {
            return _mapper.Map<HomeCarePackageClaimResponse>(homeCarePackageClaimDomain);
        }

        public static IEnumerable<ReclaimFromResponse> ToResponse(this IEnumerable<ReclaimFromDomain> reclaimFromDomain)
        {
            return _mapper.Map<IEnumerable<ReclaimFromResponse>>(reclaimFromDomain);
        }

        public static IEnumerable<ReclaimCategoryResponse> ToResponse(this IEnumerable<ReclaimCategoryDomain> homeCarePackageReclaimCategoryDomain)
        {
            return _mapper.Map<IEnumerable<ReclaimCategoryResponse>>(homeCarePackageReclaimCategoryDomain);
        }

        public static IEnumerable<ReclaimAmountOptionResponse> ToResponse(this IEnumerable<ReclaimAmountOptionDomain> reclaimAmountOptionDomain)
        {
            return _mapper.Map<IEnumerable<ReclaimAmountOptionResponse>>(reclaimAmountOptionDomain);
        }

        public static DayCarePackageClaimResponse ToResponse(this DayCarePackageClaimDomain dayCarePackageClaimDomain)
        {
            return _mapper.Map<DayCarePackageClaimResponse>(dayCarePackageClaimDomain);
        }

        public static NursingCarePackageClaimResponse ToResponse(this NursingCarePackageClaimDomain nursingCarePackageClaimDomain)
        {
            return _mapper.Map<NursingCarePackageClaimResponse>(nursingCarePackageClaimDomain);
        }

        public static ResidentialCarePackageClaimResponse ToResponse(this ResidentialCarePackageClaimDomain residentialCarePackageClaimDomain)
        {
            return _mapper.Map<ResidentialCarePackageClaimResponse>(residentialCarePackageClaimDomain);
        }

        #endregion PackageReclaim

        #region DayCareBrokerage

        public static DayCarePackageForBrokerageResponse ToResponse(this DayCarePackageForBrokerageDomain dayCarePackageForBrokerageDomain)
        {
            return _mapper.Map<DayCarePackageForBrokerageResponse>(dayCarePackageForBrokerageDomain);
        }

        public static IEnumerable<DayCareBrokerageStageResponse> ToResponse(this IEnumerable<DayCareBrokerageStageDomain> dayCareBrokerageStageDomains)
        {
            return _mapper.Map<IEnumerable<DayCareBrokerageStageResponse>>(dayCareBrokerageStageDomains);
        }

        #endregion DayCareBrokerage

        #region HomeCare

        public static HomeCarePackageResponse ToResponse(this HomeCarePackageDomain homeCarePackageDomain)
        {
            return new HomeCarePackageResponse
            {
                Id = homeCarePackageDomain.Id,
                ClientId = homeCarePackageDomain.ClientId,
                Client = homeCarePackageDomain.Client,
                StartDate = homeCarePackageDomain.StartDate,
                EndDate = homeCarePackageDomain.EndDate,
                IsFixedPeriod = homeCarePackageDomain.IsFixedPeriod,
                IsOngoingPeriod = homeCarePackageDomain.IsOngoingPeriod,
                IsThisAnImmediateService = homeCarePackageDomain.IsThisAnImmediateService,
                IsThisuserUnderS117 = homeCarePackageDomain.IsThisuserUnderS117,
                CreatorId = homeCarePackageDomain.CreatorId,
                UpdaterId = homeCarePackageDomain.UpdaterId,
                StatusId = homeCarePackageDomain.StatusId,
                Status = homeCarePackageDomain.Status,
                StageId = homeCarePackageDomain.StageId,
                SupplierId = homeCarePackageDomain.SupplierId
            };
        }

        public static IList<HomeCarePackageResponse> ToResponse(this IList<HomeCarePackageDomain> homeCarePackagesDomain)
        {
            return _mapper.Map<IList<HomeCarePackageResponse>>(homeCarePackagesDomain);
        }

        public static HomeCarePackageSlotsResponseList ToResponse(
            this HomeCarePackageSlotListDomain homeCarePackageSlotListDomain)
        {
            return new HomeCarePackageSlotsResponseList
            {
                Id = homeCarePackageSlotListDomain.Id,
                HomeCarePackageId = homeCarePackageSlotListDomain.HomeCarePackageId,
                HomeCarePackageSlots = homeCarePackageSlotListDomain.HomeCarePackageSlots.Select(item
                        => new HomeCarePackageSlotResponse
                        {
                            ServiceId = item.ServiceId,
                            NeedToAddress = item.NeedToAddress,
                            WhatShouldBeDone = item.WhatShouldBeDone,
                            PrimaryInMinutes = item.PrimaryInMinutes,
                            SecondaryInMinutes = item.SecondaryInMinutes,
                            TimeSlotShiftId = item.TimeSlotShiftId,
                            TimeSlotShift = item.TimeSlotShift,
                            DayId = item.DayId
                        })
                    .ToList()
            };
        }

        #endregion HomeCare

        #region Clients

        public static ClientsResponse ToResponse(this ClientsDomain clientsDomain)
        {
            return new ClientsResponse
            {
                Id = clientsDomain.Id,
                FirstName = clientsDomain.FirstName,
                MiddleName = clientsDomain.MiddleName,
                LastName = clientsDomain.LastName,
                DateOfBirth = clientsDomain.DateOfBirth,
                HackneyId = clientsDomain.HackneyId,
                AddressLine1 = clientsDomain.AddressLine1,
                AddressLine2 = clientsDomain.AddressLine2,
                AddressLine3 = clientsDomain.AddressLine3,
                Town = clientsDomain.Town,
                County = clientsDomain.County,
                PostCode = clientsDomain.PostCode,
                CreatorId = clientsDomain.CreatorId,
                DateCreated = clientsDomain.DateCreated,
                UpdaterId = clientsDomain.UpdaterId,
                DateUpdated = clientsDomain.DateUpdated
            };
        }

        #endregion Clients

        #region NursingCareAdditionalNeeds

        public static NursingCareAdditionalNeedsResponse ToResponse(this NursingCareAdditionalNeedsDomain nursingCareAdditionalNeedsDomain)
        {
            return new NursingCareAdditionalNeedsResponse
            {
                Id = nursingCareAdditionalNeedsDomain.Id,
                NursingCarePackageId = nursingCareAdditionalNeedsDomain.NursingCarePackageId,
                AdditionalNeedsPaymentTypeId = nursingCareAdditionalNeedsDomain.AdditionalNeedsPaymentTypeId,
                AdditionalNeedsPaymentTypeName = nursingCareAdditionalNeedsDomain.AdditionalNeedsPaymentTypeName,
                NeedToAddress = nursingCareAdditionalNeedsDomain.NeedToAddress,
                CreatorId = nursingCareAdditionalNeedsDomain.CreatorId,
                UpdatorId = nursingCareAdditionalNeedsDomain.UpdaterId,
            };
        }

        #endregion NursingCareAdditionalNeeds

        #region Packages

        public static PackageResponse ToResponse(this PackageTypeDomain packageTypeDomain)
        {
            return new PackageResponse
            {
                Id = packageTypeDomain.Id,
                PackageName = packageTypeDomain.PackageType,
                Sequence = packageTypeDomain.Sequence
            };
        }

        #endregion Packages

        #region ResidentialCareAdditionalNeeds

        public static ResidentialCareAdditionalNeedsResponse ToResponse(this ResidentialCareAdditionalNeedsDomain residentialCareAdditionalNeedsDomain)
        {
            return new ResidentialCareAdditionalNeedsResponse
            {
                Id = residentialCareAdditionalNeedsDomain.Id,
                ResidentialCarePackageId = residentialCareAdditionalNeedsDomain.ResidentialCarePackageId,
                AdditionalNeedsPaymentTypeId = residentialCareAdditionalNeedsDomain.AdditionalNeedsPaymentTypeId,
                AdditionalNeedsPaymentTypeName = residentialCareAdditionalNeedsDomain.AdditionalNeedsPaymentTypeName,
                NeedToAddress = residentialCareAdditionalNeedsDomain.NeedToAddress,
                CreatorId = residentialCareAdditionalNeedsDomain.CreatorId,
                UpdatorId = residentialCareAdditionalNeedsDomain.UpdatorId,
            };
        }

        #endregion ResidentialCareAdditionalNeeds

        #region ResidentialCarePackage

        public static IList<ResidentialCarePackageResponse> ToResponse(this IList<CarePackageForCreationDomain> residentialCarePackagesDomain)
        {
            return _mapper.Map<IList<ResidentialCarePackageResponse>>(residentialCarePackagesDomain);
        }

        public static IList<TypeOfResidentialCareHomeResponse> ToResponse(this IList<TypeOfResidentialCareHomeDomain> typeOfResidentialCareHomesDomain)
        {
            return typeOfResidentialCareHomesDomain.Select(item
                => new TypeOfResidentialCareHomeResponse
                {
                    TypeOfCareHomeId = item.TypeOfCareHomeId,
                    TypeOfCareHomeName = item.TypeOfCareHomeName
                }).ToList();
        }

        #endregion ResidentialCarePackage

        #region Roles

        public static RoleResponse ToResponse(this RolesDomain rolesDomain)
        {
            return new RoleResponse
            {
                Id = rolesDomain.Id,
                ConcurrencyStamp = rolesDomain.ConcurrencyStamp,
                Name = rolesDomain.Name,
                NormalizedName = rolesDomain.NormalizedName
            };
        }

        public static IList<RoleResponse> ToResponse(this IList<RolesDomain> roleDomains)
        {
            return _mapper.Map<IList<RoleResponse>>(roleDomains);
        }

        #endregion Roles

        #region HomeCareServiceTypes

        public static HomeCareServiceResponse ToResponse(this HomeCareServiceDomain homeCareServiceDomain)
        {
            return new HomeCareServiceResponse
            {
                Id = homeCareServiceDomain.Id,
                ServiceName = homeCareServiceDomain.ServiceName,
                PackageId = homeCareServiceDomain.PackageId,
                Package = homeCareServiceDomain.Package,
                CreatorId = homeCareServiceDomain.CreatorId,
                DateCreated = homeCareServiceDomain.DateCreated,
                UpdaterId = homeCareServiceDomain.UpdaterId,
                DateUpdated = homeCareServiceDomain.DateUpdated
            };
        }

        #endregion HomeCareServiceTypes

        #region ServiceUsers

        public static UsersResponse ToResponse(this UsersDomain usersDomain)
        {
            return new UsersResponse
            {
                Id = usersDomain.Id,
                Name = usersDomain.Name,
                Email = usersDomain.Email
            };
        }

        public static IEnumerable<UsersMinimalResponse> ToResponse(this IEnumerable<UsersMinimalDomain> usersDomains)
        {
            return _mapper.Map<IEnumerable<UsersMinimalResponse>>(usersDomains);
        }

        #endregion ServiceUsers

        #region PackageStatus

        public static StatusResponse ToResponse(this StatusDomain statusDomain)
        {
            return new StatusResponse
            {
                Id = statusDomain.Id,
                StatusName = statusDomain.StatusName,
                CreatorId = statusDomain.CreatorId,
                UpdaterId = statusDomain.UpdaterId
            };
        }

        public static IEnumerable<StatusResponse> ToResponse(this IEnumerable<StatusDomain> statusDomains)
        {
            return _mapper.Map<IEnumerable<StatusResponse>>(statusDomains);
        }

        #endregion PackageStatus

        #region TimeSlotShifts

        public static TimeSlotShiftsResponse ToResponse(this TimeSlotShiftsDomain timeSlotShiftsDomain)
        {
            return new TimeSlotShiftsResponse
            {
                Id = timeSlotShiftsDomain.Id,
                TimeSlotShiftName = timeSlotShiftsDomain.TimeSlotShiftName,
                TimeSlotTimeLabel = timeSlotShiftsDomain.TimeSlotTimeLabel,
                CreatorId = timeSlotShiftsDomain.CreatorId,
                DateCreated = timeSlotShiftsDomain.DateCreated,
                UpdaterId = timeSlotShiftsDomain.UpdaterId,
                DateUpdated = timeSlotShiftsDomain.DateUpdated
            };
        }

        #endregion TimeSlotShifts

        #region SupplierBill

        public static SupplierBillResponse ToResponse(this SupplierBillDomain supplierBillDomain)
        {
            return _mapper.Map<SupplierBillResponse>(supplierBillDomain);
        }

        #endregion SupplierBill

        #region PrimaryReasonSupport

        public static IEnumerable<PrimarySupportReasonResponse> ToResponse(this IEnumerable<PrimarySupportReasonDomain> primarySupportReasonDomains)
        {
            return _mapper.Map<IEnumerable<PrimarySupportReasonResponse>>(primarySupportReasonDomains);
        }

        #endregion PrimaryReasonSupport

        #region SubmittedPackageRequests

        public static IEnumerable<SubmittedPackageRequestsResponse> ToResponse(this IEnumerable<SubmittedPackageRequestsDomain> submittedPackageRequestsDomains)
        {
            return _mapper.Map<IEnumerable<SubmittedPackageRequestsResponse>>(submittedPackageRequestsDomains);
        }

        #endregion SubmittedPackageRequests

        #region ApprovedPackages

        public static IEnumerable<ApprovedPackagesResponse> ToResponse(this IEnumerable<ApprovedPackagesDomain> approvedPackagesDomains)
        {
            return _mapper.Map<IEnumerable<ApprovedPackagesResponse>>(approvedPackagesDomains);
        }

        #endregion ApprovedPackages

        #region ApprovedPackages

        public static IEnumerable<BrokeredPackagesResponse> ToResponse(this IEnumerable<BrokeredPackagesDomain> brokeredPackagesDomains)
        {
            return _mapper.Map<IEnumerable<BrokeredPackagesResponse>>(brokeredPackagesDomains);
        }

        #endregion ApprovedPackages

        #region Invoice

        public static InvoiceResponse ToResponse(this InvoiceDomain invoiceDomain)
        {
            return _mapper.Map<InvoiceResponse>(invoiceDomain);
        }

        #endregion Invoice

        #region Clients

        public static ClientMinimalResponse ToResponse(this ClientMinimalDomain clientMinimalDomain)
        {
            return _mapper.Map<ClientMinimalResponse>(clientMinimalDomain);
        }

        public static IEnumerable<ClientMinimalResponse> ToResponse(this IEnumerable<ClientMinimalDomain> clientMinimalDomain)
        {
            return _mapper.Map<IEnumerable<ClientMinimalResponse>>(clientMinimalDomain);
        }

        public static IEnumerable<ClientsResponse> ToResponse(this IEnumerable<ClientsDomain> clientsDomain)
        {
            return _mapper.Map<IEnumerable<ClientsResponse>>(clientsDomain);
        }

        #endregion Clients

        #region FncCollectors

        public static IEnumerable<FundedNursingCareCollectorResponse> ToResponse(this IEnumerable<FundedNursingCareCollectorDomain> collectors)
        {
            return _mapper.Map<IEnumerable<FundedNursingCareCollectorResponse>>(collectors);
        }

        #endregion FncCollectors

        #region CareCharges

        public static ProvisionalCareChargeAmountPlainResponse ToResponse(this ProvisionalCareChargeAmountPlainDomain provisionalCareChargeDomain)
        {
            return _mapper.Map<ProvisionalCareChargeAmountPlainResponse>(provisionalCareChargeDomain);
        }

        #endregion CareCharges
    }
}
