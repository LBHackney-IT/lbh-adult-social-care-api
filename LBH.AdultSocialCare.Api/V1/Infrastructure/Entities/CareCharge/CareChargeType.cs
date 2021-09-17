using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge
{
    [GenerateMappingFor(typeof(CareChargeElementTypePlainDomain))]
    [GenerateListMappingFor(typeof(CareChargeElementTypePlainDomain))]
    public class CareChargeType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        public string OptionName { get; set; }
    }
}
