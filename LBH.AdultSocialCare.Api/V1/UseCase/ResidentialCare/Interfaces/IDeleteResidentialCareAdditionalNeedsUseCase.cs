using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces
{
    public interface IDeleteResidentialCareAdditionalNeedsUseCase
    {
        public Task<bool> DeleteAsync(Guid residentialCareAdditionalNeedsId);
    }
}
