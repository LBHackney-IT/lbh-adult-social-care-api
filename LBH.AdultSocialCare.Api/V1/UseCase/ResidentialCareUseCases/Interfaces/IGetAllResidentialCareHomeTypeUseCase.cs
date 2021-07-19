using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces
{
    public interface IGetAllResidentialCareHomeTypeUseCase
    {
        public Task<IEnumerable<TypeOfResidentialCareHomeResponse>> GetAllAsync();
    }
}
