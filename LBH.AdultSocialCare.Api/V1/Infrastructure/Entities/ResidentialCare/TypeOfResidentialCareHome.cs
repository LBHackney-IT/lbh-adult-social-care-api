using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare
{
    public class TypeOfResidentialCareHome
    {
        [Key]
        public int TypeOfCareHomeId { get; set; }

        public string TypeOfCareHomeName { get; set; }
    }
}
