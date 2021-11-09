using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces
{
    public interface IDepartmentGateway
    {
        Task<IEnumerable<Department>> GetDepartmentsAsync();
    }
}
