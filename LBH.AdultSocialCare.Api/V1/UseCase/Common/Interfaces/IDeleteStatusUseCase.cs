using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IDeleteStatusUseCase
    {
        public Task<bool> DeleteAsync(int statusId);
    }
}
