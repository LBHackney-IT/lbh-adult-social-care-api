using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare
{
    public class ResidentialCarePackageForUpdateDomain
    {
        public Guid Id { get; set; }
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
        public int StatusId { get; set; }
        public int SupplierId { get; set; }
        public int StageId { get; set; }
    }
}
