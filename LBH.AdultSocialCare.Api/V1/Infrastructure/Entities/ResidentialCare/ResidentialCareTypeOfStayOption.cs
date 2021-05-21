using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare
{
    public class ResidentialCareTypeOfStayOption
    {
        [Key]
        public int TypeOfStayOptionId { get; set; }

        public string OptionName { get; set; }

        public string OptionPeriod { get; set; }
    }
}
