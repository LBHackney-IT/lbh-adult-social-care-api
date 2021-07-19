using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCareBrokerageDomains
{
    public class DayCareRequestMoreInformationDomain
    {
        /// <summary>
        /// Gets or sets the Day Care Package Id
        /// </summary>
        public Guid DayCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Information Text
        /// </summary>
        public string InformationText { get; set; }
    }
}
