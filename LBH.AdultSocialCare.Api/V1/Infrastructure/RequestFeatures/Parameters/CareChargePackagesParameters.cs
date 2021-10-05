using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters
{
    public class CareChargePackagesParameters : RequestParameters
    {
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public int? MosaicId { get; set; }
        public int? CederId { get; set; }
        public DateTimeOffset? ModifiedAt { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
