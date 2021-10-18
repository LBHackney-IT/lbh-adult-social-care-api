using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces
{
    public interface IGetServiceUserMasterSearchUseCase
    {
        Task<ServiceUserInformationResponse> GetServiceUsers(ServiceUserQueryRequest request);
    }
}
