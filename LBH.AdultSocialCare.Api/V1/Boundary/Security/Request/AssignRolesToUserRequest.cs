using LBH.AdultSocialCare.Api.V1.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Security.Request
{
    public class AssignRolesToUserRequest
    {
        [Required, GuidNotEmpty] public Guid UserId { get; set; }
        public IEnumerable<string> Roles { get; set; } = new List<string>();
    }
}
