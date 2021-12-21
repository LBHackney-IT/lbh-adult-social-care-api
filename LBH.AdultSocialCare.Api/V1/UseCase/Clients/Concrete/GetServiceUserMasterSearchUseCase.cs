using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Extensions;

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

        public async Task<ServiceUserSearchResponse> GetServiceUsers(ServiceUserQueryRequest request)
        {
            var serviceUserInformation = await _residentsService.SearchServiceUserInformationAsync(request)
                .EnsureExistsAsync($"service user with hackney Id : {request.HackneyId} not found");

            var hackneyIds = serviceUserInformation.Residents.Select(s => int.Parse(s.MosaicId)).ToList();
            var carePackages = await _carePackageGateway.GetServiceUserActivePackages(hackneyIds);

            foreach (var serviceUser in serviceUserInformation.Residents)
            {
                var carePackage = carePackages.FirstOrDefault(c => c.ServiceUser?.HackneyId == Convert.ToInt32(serviceUser.MosaicId));
                if (carePackage != null)
                {
                    serviceUser.ActivePackage = carePackage.PackageType.GetDisplayName();
                    serviceUser.ActivePackageId = carePackage.Id;
                }
            }

            var pagedResidentsResponse = PagedList<ResidentResponse>.ToPagedList(serviceUserInformation.Residents,
                serviceUserInformation.totalCount, request.PageNumber, request.PageSize);

            return new ServiceUserSearchResponse
            {
                Residents = new PagedResponse<ResidentResponse>()
                {
                    PagingMetaData = pagedResidentsResponse.PagingMetaData,
                    Data = serviceUserInformation.Residents
                },
                nextCursor = serviceUserInformation.nextCursor,
                totalCount = serviceUserInformation.totalCount
            };
        }
    }
}
