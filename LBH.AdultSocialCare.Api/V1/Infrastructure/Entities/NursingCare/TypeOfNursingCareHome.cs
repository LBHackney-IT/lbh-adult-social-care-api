using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare
{
    public class TypeOfNursingCareHome
    {
        [Key]
        public int TypeOfCareHomeId { get; set; }

        public string TypeOfCareHomeName { get; set; }
    }
}
