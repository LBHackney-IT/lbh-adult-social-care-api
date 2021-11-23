using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Data.Constants.Enums;

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

        public IFormFile CarePlanFile { get; set; }

        public Guid CarePlanFileId { get; set; }
    }
}
