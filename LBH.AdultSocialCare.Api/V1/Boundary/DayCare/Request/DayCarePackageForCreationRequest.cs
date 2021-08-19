using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Request
{
    public class DayCarePackageForCreationRequest
    {
        [Required] public Guid? ClientId { get; set; }
        [Required] public bool IsFixedPeriodOrOngoing { get; set; }
        [Required] public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public bool IsThisAnImmediateService { get; set; }
        public bool IsThisUserUnderS117 { get; set; }
        public string NeedToAddress { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public bool TransportNeeded { get; set; }
        public bool TransportEscortNeeded { get; set; }
        public bool EscortNeeded { get; set; }
        [Required] public int? TermTimeConsiderationOptionId { get; set; }
        public List<DayCarePackageOpportunityForCreationRequest> DayCarePackageOpportunities { get; set; }
        public List<DayCarePackageClaimCreationRequest> PackageReclaims { get; set; }
        public int? CollegeId { get; set; }
    }
}
