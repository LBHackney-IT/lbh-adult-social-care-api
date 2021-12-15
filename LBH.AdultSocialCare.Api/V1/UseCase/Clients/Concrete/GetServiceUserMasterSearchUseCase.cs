using System;
using Common.Extensions;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Concrete
{
    public class GetServiceUserMasterSearchUseCase : IGetServiceUserMasterSearchUseCase
    {
        private readonly IResidentsService _residentsService;
        private readonly ICarePackageGateway _carePackageGateway;

        public GetServiceUserMasterSearchUseCase(IResidentsService residentsService, ICarePackageGateway carePackageGateway)
        {
            _residentsService = residentsService;
            _carePackageGateway = carePackageGateway;
        }
        public async Task<ServiceUserInformationResponse> GetServiceUsers(ServiceUserQueryRequest request)
        {
            return await _residentsService.SearchServiceUserInformationAsync(request)
                .EnsureExistsAsync($"service user with hackney Id : {request.HackneyId} not found");
        }

        public async Task<ServiceUserInformationResponse> GetServiceUsersNew(ServiceUserQueryRequest request)
        {
            var serviceUserInformation = await _residentsService.SearchServiceUserInformationAsync(request)
                .EnsureExistsAsync($"service user with hackney Id : {request.HackneyId} not found");

            foreach (var serviceUser in serviceUserInformation.Residents)
            {
                var carePackage = await _carePackageGateway.GetServiceUserActivePackages(Convert.ToInt32(serviceUser.MosaicId));
                if (carePackage != null)
                {
                    serviceUser.ActivePackage = carePackage.PackageType.GetDisplayName();
                    serviceUser.ActivePackageId = carePackage.Id;
                }
            }

            return serviceUserInformation;
        }
    }
}
