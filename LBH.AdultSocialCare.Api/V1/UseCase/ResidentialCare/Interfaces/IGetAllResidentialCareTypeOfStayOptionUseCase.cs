using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces
{
    public interface IGetAllResidentialCareTypeOfStayOptionUseCase
    {
        public Task<IEnumerable<ResidentialCareTypeOfStayOptionResponse>> GetAllAsync();
    }
}