using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces
{
    public interface IUpsertResidentialCareAdditionalNeedsUseCase
    {
        public Task<ResidentialCareAdditionalNeedsDomain> ExecuteAsync(ResidentialCareAdditionalNeedsDomain residentialCareAdditionalNeeds);
    }
}