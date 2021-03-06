using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class GetCarePackageHistoryUseCase : IGetCarePackageHistoryUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly ICarePackageHistoryGateway _carePackageHistoryGateway;

        public GetCarePackageHistoryUseCase(ICarePackageGateway carePackageGateway, ICarePackageHistoryGateway carePackageHistoryGateway)
        {
            _carePackageGateway = carePackageGateway;
            _carePackageHistoryGateway = carePackageHistoryGateway;
        }

        public async Task<CarePackageHistoryViewResponse> ExecuteAsync(Guid packageId)
        {
            var package = await _carePackageGateway.GetPackageAsync(packageId, PackageFields.Approver | PackageFields.Broker | PackageFields.Resources, false).EnsureExistsAsync($"Package with id {packageId} not found");

            var packageHistory = await _carePackageHistoryGateway.ListAsync(packageId);

            var historyResponse = new CarePackageHistoryViewResponse
            {
                CarePackageId = package.Id,
                PackageType = package.PackageType.GetDisplayName(),
                BrokeredBy = package.Broker?.Name,
                AssignedOn = package.DateAssigned,
                ApprovedBy = package.Approver?.Name,
                ApprovedOn = package.DateApproved,
                SocialWorkerCarePlanFileId = package.Resources?.Where(r => r.Type == PackageResourceType.CarePlanFile).OrderByDescending(x => x.DateCreated).FirstOrDefault()?.FileId,
                SocialWorkerCarePlanFileName = package.Resources?.Where(r => r.Type == PackageResourceType.CarePlanFile).OrderByDescending(x => x.DateCreated).FirstOrDefault()?.Name,
                History = packageHistory.OrderByDescending(h => h.Id).ToResponse()
            };

            return historyResponse;
        }
    }
}
