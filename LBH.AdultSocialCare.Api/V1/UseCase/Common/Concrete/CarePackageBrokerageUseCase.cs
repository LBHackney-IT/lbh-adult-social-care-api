using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

        public CarePackageBrokerageUseCase(ICarePackageGateway carePackageGateway, IDatabaseManager databaseManager)
        {
            _carePackageGateway = carePackageGateway;
            _databaseManager = databaseManager;
        }

        public async Task CreateCarePackageBrokerageAsync(Guid packageId, CarePackageBrokerageDomain brokerageRequest)
        {
            var package = await _carePackageGateway.GetPackageAsync(packageId);

            EnsurePackageCanBeBrokered(package, packageId);

            package.SupplierId = brokerageRequest.SupplierId;

            var detailEntities = brokerageRequest.Details.ToEntity();

            foreach (var detailEntity in detailEntities)
            {
                detailEntity.CostPeriod = detailEntity.Type.ToPaymentPeriod();
                package.Details.Add(detailEntity);
            }

            await _databaseManager.SaveAsync();
        }

        private static void EnsurePackageCanBeBrokered(CarePackage package, Guid packageId)
        {
            if (package is null)
            {
                throw new ApiException($"Care package {packageId} not found", HttpStatusCode.BadRequest);
            }

            if (package.Details.Any(d => d.Type == PackageDetailType.CoreCost))
            {
                throw new ApiException($"Core cost for care package {package.Id} already exists", HttpStatusCode.Conflict);
            }
        }
    }
}
