using AutoMapper;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Constants;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class UpsertCarePackageBrokerageUseCase : IUpsertCarePackageBrokerageUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _databaseManager;
        private readonly IMapper _mapper;

        public UpsertCarePackageBrokerageUseCase(ICarePackageGateway carePackageGateway, IDatabaseManager databaseManager, IMapper mapper)
        {
            _carePackageGateway = carePackageGateway;
            _databaseManager = databaseManager;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(Guid packageId, CarePackageBrokerageDomain brokerageInfo)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.Details, true)
                .EnsureExistsAsync($"Care package {packageId} not found");

            package.SupplierId = brokerageInfo.SupplierId;

            AddCoreCost(package, brokerageInfo);
            RemoveDetails(package, brokerageInfo.Details);

            foreach (var requestedDetail in brokerageInfo.Details)
            {
                if (requestedDetail.Id is null)
                {
                    AddDetail(package, requestedDetail);
                }
                else
                {
                    UpdateDetail(package, requestedDetail);
                }
            }

            // Change status of package to in-progress
            package.Status = PackageStatus.InProgress;

            await _databaseManager.SaveAsync();
        }

        private static void AddCoreCost(CarePackage package, CarePackageBrokerageDomain brokerageInfo)
        {
            var coreCostDetail = package.Details.FirstOrDefault(d => d.Type is PackageDetailType.CoreCost);

            string subjective = package.PackageType == PackageType.ResidentialCare ? SubjectiveConstants.ResidentialCarePackageSubjectiveCode : SubjectiveConstants.NursingCarePackageSubjectiveCode;

            if (coreCostDetail is null)
            {
                coreCostDetail = new CarePackageDetail()
                {
                    Subjective = subjective
                };
                package.Details.Add(coreCostDetail);
            }

            coreCostDetail.Type = PackageDetailType.CoreCost;
            coreCostDetail.Cost = brokerageInfo.CoreCost;
            coreCostDetail.CostPeriod = PaymentPeriod.Weekly;
            coreCostDetail.StartDate = brokerageInfo.StartDate;
            coreCostDetail.EndDate = brokerageInfo.EndDate;
            coreCostDetail.Subjective = subjective;
        }

        private static void AddDetail(CarePackage package, CarePackageDetailDomain requestedDetail)
        {
            if (requestedDetail.Type == PackageDetailType.CoreCost)
            {
                throw new ApiException("Core cost cannot be specified in Details list", HttpStatusCode.BadRequest);
            }

            var detail = requestedDetail.ToEntity();
            detail.Subjective = package.PackageType == PackageType.ResidentialCare ? SubjectiveConstants.ResidentialCarePackageSubjectiveCode : SubjectiveConstants.NursingCarePackageSubjectiveCode;

            package.Details.Add(detail);
        }

        private void UpdateDetail(CarePackage package, CarePackageDetailDomain requestedDetail)
        {
            var existingDetail = package.Details.FirstOrDefault(d => d.Id == requestedDetail.Id);

            if (existingDetail != null)
            {
                _mapper.Map(requestedDetail, existingDetail);
                existingDetail.Subjective = package.PackageType == PackageType.ResidentialCare ? SubjectiveConstants.ResidentialCarePackageSubjectiveCode : SubjectiveConstants.NursingCarePackageSubjectiveCode;
            }
            else
            {
                throw new ApiException($"Unable to find care package detail {requestedDetail.Id}", HttpStatusCode.BadRequest);
            }
        }

        private static void RemoveDetails(CarePackage package, List<CarePackageDetailDomain> requestedDetails)
        {
            // TODO: VK: Consider moving Core Cost to package level,
            // it's a non-removable and 1-1-related unlike others, it can error-prone to keep it among other details
            var detailsToRemove = package.Details
                .Where(packageDetail => packageDetail.Type != PackageDetailType.CoreCost)
                .Where(packageDetail => !requestedDetails.Any(detail => detail.Id.HasValue && detail.Id == packageDetail.Id))
                .ToList();

            foreach (var detail in detailsToRemove)
            {
                package.Details.Remove(detail);
            }
        }
    }
}
