using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IGetReleasedInvoiceCountUseCase
    {
        Task<int> GetAsync();
    }
}
