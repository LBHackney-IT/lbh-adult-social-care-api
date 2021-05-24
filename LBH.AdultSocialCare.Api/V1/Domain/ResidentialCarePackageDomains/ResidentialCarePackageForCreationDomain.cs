using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareAdditionalNeedsDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageReclaimDomains;
using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains
{
    public class ResidentialCarePackageForCreationDomain
    {
        public Guid ClientId { get; set; }
        public bool IsFixedPeriod { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public bool HasRespiteCare { get; set; }
        public bool HasDischargePackage { get; set; }
        public bool IsThisAnImmediateService { get; set; }
        public bool IsThisUserUnderS117 { get; set; }
        public int? TypeOfStayId { get; set; }
        public string NeedToAddress { get; set; }
        public int? TypeOfResidentialCareHomeId { get; set; }
        public Guid CreatorId { get; set; }
        public int StatusId { get; set; }
        public IEnumerable<ResidentialCareAdditionalNeedForCreationDomain> ResidentialCareAdditionalNeeds { get; set; }
        public IEnumerable<ResidentialCarePackageClaimCreationDomain> PackageReclaims { get; set; }
    }
}
