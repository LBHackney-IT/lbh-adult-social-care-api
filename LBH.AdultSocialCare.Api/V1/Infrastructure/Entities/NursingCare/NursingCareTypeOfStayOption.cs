using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
