using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces
{
    public interface IDepartmentGateway
    {
        Task<IEnumerable<Department>> GetDepartmentsAsync();
    }
}
