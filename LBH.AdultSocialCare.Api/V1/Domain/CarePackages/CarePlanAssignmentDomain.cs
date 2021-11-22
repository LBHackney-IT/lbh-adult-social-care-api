using Microsoft.AspNetCore.Http;
using System;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    public class CarePlanAssignmentDomain
    {
        public int HackneyUserId { get; set; }
        public Guid BrokerId { get; set; }

        public PackageType PackageType { get; set; }

        public string Notes { get; set; }

        public IFormFile CarePlanFile { get; set; }
        public Guid CarePlanFileId { get; set; }
    }
}
