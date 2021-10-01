using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HttpServices.Models.Responses;

namespace HttpServices.Services.Contracts
{
    public interface IResidentsService
    {
        Task<ServiceUserInformationResponse> GetServiceUserInformationAsync(int hackneyId);
    }
}
