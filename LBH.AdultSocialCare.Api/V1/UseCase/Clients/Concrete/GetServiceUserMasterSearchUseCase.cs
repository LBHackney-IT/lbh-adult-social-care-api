using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Concrete
{
    public class GetServiceUserMasterSearchUseCase : IGetServiceUserMasterSearchUseCase
    {
        private readonly IResidentsService _residentsService;

        public GetServiceUserMasterSearchUseCase(IResidentsService residentsService)
        {
            _residentsService = residentsService;
        }
        public async Task<ServiceUserInformationResponse> GetServiceUsers(ServiceUserQueryRequest request)
        {
            return await _residentsService.SearchServiceUserInformationAsync(request)
                .EnsureExistsAsync($"service user with hackney Id : {request.HackneyId} not found");
        }
    }
}
