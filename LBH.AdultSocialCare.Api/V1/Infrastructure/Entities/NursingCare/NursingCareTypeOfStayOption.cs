using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare
{
    public class NursingCareTypeOfStayOption
    {
        [Key]
        public int TypeOfStayOptionId { get; set; }

        public string OptionName { get; set; }

        public string OptionPeriod { get; set; }
    }
}
