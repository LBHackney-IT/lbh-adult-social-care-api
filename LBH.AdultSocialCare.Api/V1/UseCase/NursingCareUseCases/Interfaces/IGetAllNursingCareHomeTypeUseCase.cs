using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces
{
    public interface IGetAllNursingCareHomeTypeUseCase
    {
        public Task<IEnumerable<TypeOfNursingCareHomeResponse>> GetAllAsync();
    }
}
