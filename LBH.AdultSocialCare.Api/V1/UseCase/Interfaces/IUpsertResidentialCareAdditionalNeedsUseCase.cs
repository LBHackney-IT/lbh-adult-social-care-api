using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IUpsertResidentialCareAdditionalNeedsUseCase
    {
        public Task<ResidentialCareAdditionalNeedsDomain> ExecuteAsync(ResidentialCareAdditionalNeedsDomain residentialCareAdditionalNeeds);
    }
}
