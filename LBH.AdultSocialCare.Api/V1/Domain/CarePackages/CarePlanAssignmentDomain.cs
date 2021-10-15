using System;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    public class CarePlanAssignmentDomain
    {
        public int HackneyUserId { get; set; }
        public Guid BrokerId { get; set; }

        public PackageType PackageType { get; set; }

        public string Notes { get; set; }

        public IFormFile CarePlanFile { get; set; }
    }
}
