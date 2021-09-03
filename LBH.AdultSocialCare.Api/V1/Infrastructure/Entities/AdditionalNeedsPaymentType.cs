using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{
    public class AdditionalNeedsPaymentType
    {
        [Key]
        public int AdditionalNeedsPaymentTypeId { get; set; }

        public string OptionName { get; set; }

    }
}
