using System;

namespace HttpServices.Models.Requests
{
    public class ServiceUserQueryRequest
    {
        public int? HackneyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PostCode { get; set; }
    }
}
