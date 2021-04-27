using LBH.AdultSocialCare.Api.V1.Domain.NursingCareAdditionalNeedsDomains;
using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains
{
    public class NursingCarePackageForCreationDomain
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
        public int? TypeOfNursingCareHomeId { get; set; }
        public Guid CreatorId { get; set; }
        public int StatusId { get; set; }
        public IEnumerable<NursingCareAdditionalNeedForCreationDomain> NursingCareAdditionalNeeds { get; set; }
    }
}