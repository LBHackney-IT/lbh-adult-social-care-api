using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces
{
    public interface IGetAllResidentialCareTypeOfStayOptionUseCase
    {
        public Task<IEnumerable<ResidentialCareTypeOfStayOptionResponse>> GetAllAsync();
    }
}
