using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces
{

    public interface IDeleteServiceUseCase
    {

        public Task<bool> DeleteAsync(int serviceId);

    }

}
