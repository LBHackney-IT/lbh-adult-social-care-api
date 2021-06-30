using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.TransactionsUseCases.PayRunUseCases.Interfaces
{
    public interface IPayRunUseCase
    {
        Task<Guid?> CreateNewPayRunUseCase(string payRunType);
    }
}
