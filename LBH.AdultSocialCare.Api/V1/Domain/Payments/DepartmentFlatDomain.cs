using Common.Attributes;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    [GenerateMappingFor(typeof(Department))]
    [GenerateMappingFor(typeof(DepartmentFlatResponse))]
    [GenerateListMappingFor(typeof(Department))]
    [GenerateListMappingFor(typeof(DepartmentFlatResponse))]
    public class DepartmentFlatDomain
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
