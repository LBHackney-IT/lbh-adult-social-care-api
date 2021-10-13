using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class ServiceUserBasicResponse
    {
        public Guid Id { get; set; }
        public int HackneyId { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public string PostCode { get; set; }

        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
