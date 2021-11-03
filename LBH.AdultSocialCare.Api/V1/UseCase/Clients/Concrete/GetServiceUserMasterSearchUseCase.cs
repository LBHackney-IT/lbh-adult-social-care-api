using Common.Extensions;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;
using System.Threading.Tasks;

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
