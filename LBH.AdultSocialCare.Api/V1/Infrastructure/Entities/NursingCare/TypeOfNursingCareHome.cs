using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare
{
    public class TypeOfNursingCareHome
    {
        [Key]
        public int TypeOfCareHomeId { get; set; }

        public string TypeOfCareHomeName { get; set; }
    }
}
