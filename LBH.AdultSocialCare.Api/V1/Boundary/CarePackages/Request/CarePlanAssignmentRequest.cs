using System;
using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    [GenerateMappingFor(typeof(CarePlanAssignmentDomain))]
    public class CarePlanAssignmentRequest
    {
        [Required]
        public int? HackneyUserId { get; set; }

        [Required]
        public Guid? BrokerId { get; set; }

        [Required]
        public PackageType? PackageType { get; set; }

        public string Notes { get; set; }
    }
}
