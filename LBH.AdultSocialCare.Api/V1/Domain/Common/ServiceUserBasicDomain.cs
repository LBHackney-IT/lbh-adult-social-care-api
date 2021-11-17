using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System;
using Common.Attributes;
using LBH.AdultSocialCare.Data.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    // separate entity to keep non-sensitive data
    [GenerateMappingFor(typeof(ServiceUser))]
    [GenerateMappingFor(typeof(ServiceUserBasicResponse))]
    public class ServiceUserBasicDomain
    {
        public Guid Id { get; set; }
        public int HackneyId { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string PostCode { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FullName => $"{FirstName} {MiddleName ?? string.Empty} {LastName}";
        public int Age => DateOfBirth.GetAge(DateTime.Now);
    }
}
