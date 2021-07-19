using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces
{
    public interface IGetAllResidentialCarePackageUseCase
    {
        public Task<IEnumerable<ResidentialCarePackageResponse>> GetAllAsync();
    }
}
