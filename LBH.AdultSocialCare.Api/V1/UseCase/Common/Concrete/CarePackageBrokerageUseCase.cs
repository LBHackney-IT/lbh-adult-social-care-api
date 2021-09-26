using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class CarePackageBrokerageUseCase : ICarePackageBrokerageUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _databaseManager;
        private readonly IMapper _mapper;

        public CarePackageBrokerageUseCase(ICarePackageGateway carePackageGateway, IDatabaseManager databaseManager, IMapper mapper)
        {
            _carePackageGateway = carePackageGateway;
            _databaseManager = databaseManager;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(Guid packageId, CarePackageBrokerageDomain brokerageInfo)
        {
            var package = await EnsurePackage(packageId);

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

            await _databaseManager.SaveAsync();
        }

        private static void AddCoreCost(CarePackage package, CarePackageBrokerageDomain brokerageInfo)
        {
            var coreCostDetail = package.Details.FirstOrDefault(d => d.Type is PackageDetailType.CoreCost);

            if (coreCostDetail is null)
            {
                coreCostDetail = new CarePackageDetail();
                package.Details.Add(coreCostDetail);
            }

            coreCostDetail.Type = PackageDetailType.CoreCost;
            coreCostDetail.Cost = brokerageInfo.CoreCost;
            coreCostDetail.CostPeriod = PaymentPeriod.Weekly;
            coreCostDetail.StartDate = brokerageInfo.StartDate;
            coreCostDetail.EndDate = brokerageInfo.EndDate;
        }

        private static void AddDetail(CarePackage package, CarePackageDetailDomain requestedDetail)
        {
            if (requestedDetail.Type == PackageDetailType.CoreCost)
            {
                throw new ApiException("Core cost cannot be specified in Details list", HttpStatusCode.BadRequest);
            }

            var newDetail = requestedDetail.ToEntity();
            // TODO: VK: Use single type for Additional Weekly and Additional One Off, and handle CostPeriod separately, they repeat each other
            newDetail.CostPeriod = newDetail.Type.ToPaymentPeriod();

            package.Details.Add(newDetail);
        }

        private void UpdateDetail(CarePackage package, CarePackageDetailDomain requestedDetail)
        {
            var existingDetail = package.Details.FirstOrDefault(d => d.Id == requestedDetail.Id);

            if (existingDetail != null)
            {
                _mapper.Map(requestedDetail, existingDetail);
                existingDetail.CostPeriod = existingDetail.Type.ToPaymentPeriod();
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

        private async Task<CarePackage> EnsurePackage(Guid packageId)
        {
            var package = await _carePackageGateway.GetPackageAsync(packageId);

            if (package is null)
            {
                throw new ApiException($"Care package {packageId} not found", HttpStatusCode.NotFound);
            }

            return package;
        }
    }
}
