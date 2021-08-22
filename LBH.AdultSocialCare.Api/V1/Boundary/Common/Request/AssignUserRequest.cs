using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
    public class AssignUserRequest
    {
        public Guid PackageId { get; set; }
        public Guid UserId { get; set; }
    }
}
