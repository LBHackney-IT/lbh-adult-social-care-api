using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface ICreateDraftPayRunUseCase
    {
        Task CreateDraftPayRun(DraftPayRunCreationDomain reclaimCreationDomain);
    }
}
