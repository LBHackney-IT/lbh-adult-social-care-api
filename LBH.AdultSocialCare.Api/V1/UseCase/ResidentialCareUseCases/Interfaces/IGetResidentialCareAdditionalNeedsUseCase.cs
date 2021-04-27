using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces
{
    public interface IGetResidentialCareAdditionalNeedsUseCase
    {
        public Task<ResidentialCareAdditionalNeedsDomain> GetAsync(Guid residentialCareAdditionalNeedsId);
    }
}
