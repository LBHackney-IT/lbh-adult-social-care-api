using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Payments.Concrete
{
    public class DepartmentGateway : IDepartmentGateway
    {
        private readonly DatabaseContext _dbContext;

        public DepartmentGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _dbContext.Departments.ToListAsync();
        }
    }
}
