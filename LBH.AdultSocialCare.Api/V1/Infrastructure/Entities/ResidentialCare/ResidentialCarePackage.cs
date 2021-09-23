using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCarePackageReclaims;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare
{
    public class ResidentialCarePackage : BaseEntity
    {
        public ResidentialCarePackage()
        {
            ResidentialCareAdditionalNeeds = new HashSet<ResidentialCareAdditionalNeed>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }
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
        public int? StageId { get; set; }
        public int? SupplierId { get; set; }
        public Guid? AssignedUserId { get; set; }
        public DateTimeOffset? PaidUpTo { get; set; }
        public DateTimeOffset? PreviousPaidUpTo { get; set; }

        [ForeignKey(nameof(ClientId))] public Client Client { get; set; }
        [ForeignKey(nameof(StatusId))] public PackageStatusOption Status { get; set; }
        [ForeignKey(nameof(StageId))] public Stage Stage { get; set; }
        [ForeignKey(nameof(SupplierId))] public Supplier Supplier { get; set; }
        [ForeignKey(nameof(TypeOfResidentialCareHomeId))] public TypeOfResidentialCareHome TypeOfCareHome { get; set; }
        [ForeignKey(nameof(TypeOfStayId))] public ResidentialCareTypeOfStayOption TypeOfStayOption { get; set; }
        public virtual ICollection<ResidentialCareAdditionalNeed> ResidentialCareAdditionalNeeds { get; set; }

        public virtual ICollection<ResidentialCarePackageReclaim> PackageReclaims { get; set; }
        public ICollection<ResidentialCareApprovalHistory> ResidentialCareApprovalHistories { get; set; }
        public virtual ResidentialCareBrokerageInfo ResidentialCareBrokerageInfo { get; set; }
    }
}
