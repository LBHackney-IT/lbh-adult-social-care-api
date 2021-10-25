using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class CreateCarePackageReclaimUseCase : ICreateCarePackageReclaimUseCase
    {
        private readonly ICarePackageReclaimGateway _carePackageReclaimGateway;
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;

        public CreateCarePackageReclaimUseCase(ICarePackageReclaimGateway carePackageReclaimGateway, ICarePackageGateway carePackageGateway, IDatabaseManager dbManager)
        {
            _carePackageReclaimGateway = carePackageReclaimGateway;
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
        }

        public async Task<CarePackageReclaimResponse> CreateCarePackageReclaim(CarePackageReclaimCreationDomain carePackageReclaimCreationDomain, ReclaimType reclaimType)
        {
            var carePackage = await _carePackageGateway.GetPackageAsync(carePackageReclaimCreationDomain.CarePackageId, PackageFields.Details).EnsureExistsAsync($"Care package with id {carePackageReclaimCreationDomain.CarePackageId} not found");

            if (carePackageReclaimCreationDomain.SubType == ReclaimSubType.CareChargeProvisional)
            {
                var coreCostDetail = carePackage.Details.FirstOrDefault(d => d.Type is PackageDetailType.CoreCost);
                if (coreCostDetail != null) carePackageReclaimCreationDomain.StartDate = coreCostDetail.StartDate;
            }

            var carePackageReclaim = carePackageReclaimCreationDomain.ToEntity();
            carePackageReclaim.Type = reclaimType;

            await _carePackageReclaimGateway.CreateAsync(carePackageReclaim);
            await _dbManager.SaveAsync("Could not save care package reclaim to database");
            return carePackageReclaim.ToDomain().ToResponse();
        }
    }
}
