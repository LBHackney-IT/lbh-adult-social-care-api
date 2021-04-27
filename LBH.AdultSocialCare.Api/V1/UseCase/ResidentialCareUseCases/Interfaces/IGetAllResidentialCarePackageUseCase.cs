using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageBoundary.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces
{
    public interface IGetAllResidentialCarePackageUseCase
    {
        public Task<IEnumerable<ResidentialCarePackageResponse>> GetAllAsync();
    }
}
