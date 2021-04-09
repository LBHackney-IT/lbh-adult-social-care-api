using LBH.AdultSocialCare.Api.V1.Boundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IGetByIdUseCase
    {
        ResponseObject Execute(int id);
    }
}
