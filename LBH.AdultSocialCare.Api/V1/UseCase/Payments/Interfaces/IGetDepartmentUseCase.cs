using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IGetDepartmentUseCase
    {
        Task<IEnumerable<DepartmentFlatResponse>> GetAll();
    }
}
