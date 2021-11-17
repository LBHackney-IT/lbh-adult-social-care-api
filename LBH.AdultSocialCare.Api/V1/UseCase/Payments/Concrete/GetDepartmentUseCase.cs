using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Factories;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetDepartmentUseCase : IGetDepartmentUseCase
    {
        private readonly IDepartmentGateway _gateway;

        public GetDepartmentUseCase(IDepartmentGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<IEnumerable<DepartmentFlatResponse>> GetAll()
        {
            var result = await _gateway.GetDepartmentsAsync();
            return result.ToFlatDomain().ToResponse();
        }
    }
}
