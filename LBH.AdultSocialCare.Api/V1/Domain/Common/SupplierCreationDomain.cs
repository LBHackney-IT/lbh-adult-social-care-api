using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class SupplierCreationDomain
    {
        /// <summary>
        /// Gets or sets the Supplier Name
        /// </summary>
        public string SupplierName { get; set; }

        public string Postcode { get; set; }
        public string CedarName { get; set; }
        public string CedarReferenceNumber { get; set; }
        public int? CedarId { get; set; }
    }
}
