using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments
{
    [GenerateMappingFor(typeof(DepartmentFlatDomain))]
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
