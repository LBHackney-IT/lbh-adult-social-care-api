using System;

namespace LBH.AdultSocialCare.Data.RequestFeatures.Parameters
{
    public class ServiceUserQueryParameters : RequestParameters
    {
        public int? HackneyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public bool HasPackages { get; set; }
    }
}
