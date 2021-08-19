using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces
{
    public interface IGetAllNursingCareTypeOfStayOptionUseCase
    {
        public Task<IEnumerable<NursingCareTypeOfStayOptionResponse>> GetAllAsync();
    }
}
