using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class SubSupplierDomain
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string CedarName { get; set; }
        public string CedarReferenceNumber { get; set; }
        public int? CedarId { get; set; }
    }
}
