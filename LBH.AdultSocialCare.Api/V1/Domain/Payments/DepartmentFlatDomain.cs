using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    [GenerateMappingFor(typeof(DepartmentFlatResponse))]
    [GenerateListMappingFor(typeof(DepartmentFlatResponse))]
    public class DepartmentFlatDomain
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
