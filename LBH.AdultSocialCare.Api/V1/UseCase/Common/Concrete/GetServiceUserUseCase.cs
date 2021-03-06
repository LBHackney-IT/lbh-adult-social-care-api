using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetServiceUserUseCase : IGetServiceUserUseCase
    {
        private readonly IResidentsService _residentsService;
        private readonly IServiceUserGateway _serviceUserGateway;

        public GetServiceUserUseCase(IResidentsService residentsService, IServiceUserGateway serviceUserGateway)
        {
            _residentsService = residentsService;
            _serviceUserGateway = serviceUserGateway;
        }

        public async Task<ServiceUserResponse> GetServiceUserInformation(int hackneyId)
        {
            var serviceUserCount = await _serviceUserGateway.GetServiceUserCountAsync(hackneyId);

            if (serviceUserCount is 0)
            {
                var serviceUserResponse = await _residentsService.GetServiceUserInformationAsync(hackneyId);

                if (serviceUserResponse is null)
                    throw new ApiException($"service user with hackney Id : {hackneyId} not found");

                foreach (var item in serviceUserResponse.Residents)
                {
                    var newServiceUserDomain = new ServiceUserDomain()
                    {
                        HackneyId = hackneyId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        DateOfBirth = item.DateOfBirth,
                        AddressLine1 = item.Address?.Address,
                        PostCode = item.Address?.Postcode
                    };

                    await _serviceUserGateway.CreateAsync(newServiceUserDomain.ToEntity());
                }
            }

            var serviceUserDomain = await _serviceUserGateway.GetAsync(hackneyId)
                .EnsureExistsAsync($"service user with hackney Id : {hackneyId} not found");

            return serviceUserDomain.ToResponse();
        }
    }
}
