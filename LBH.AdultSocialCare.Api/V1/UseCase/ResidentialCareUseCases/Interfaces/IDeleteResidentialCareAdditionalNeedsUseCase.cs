using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces
{
    public interface IDeleteResidentialCareAdditionalNeedsUseCase
    {
        public Task<bool> DeleteAsync(Guid residentialCareAdditionalNeedsId);
    }
}
