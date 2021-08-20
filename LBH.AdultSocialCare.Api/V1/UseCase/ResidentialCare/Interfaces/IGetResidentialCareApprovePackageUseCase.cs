using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces
{
    public interface IGetResidentialCareApprovePackageUseCase
    {
        public Task<ResidentialCareApprovePackageResponse> Execute(Guid residentialCarePackageId);
    }
}
