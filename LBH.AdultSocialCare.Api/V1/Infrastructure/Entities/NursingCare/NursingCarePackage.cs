using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCarePackageReclaims;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare
{
    public class NursingCarePackage : BaseEntityTmp
    {
        public NursingCarePackage()
        {
            NursingCareAdditionalNeeds = new HashSet<NursingCareAdditionalNeed>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }
        public Guid? ClientId { get; set; }
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
        public int StatusId { get; set; }
        public int? StageId { get; set; }
        public int? SupplierId { get; set; }
        public Guid? AssignedUserId { get; set; }
        public DateTimeOffset? PaidUpTo { get; set; }

        [ForeignKey(nameof(ClientId))] public Client Client { get; set; }
        [ForeignKey(nameof(StatusId))] public PackageStatus Status { get; set; }
        [ForeignKey(nameof(StageId))] public Stage Stage { get; set; }
        [ForeignKey(nameof(SupplierId))] public Supplier Supplier { get; set; }
        [ForeignKey(nameof(TypeOfNursingCareHomeId))] public TypeOfNursingCareHome TypeOfCareHome { get; set; }
        [ForeignKey(nameof(TypeOfStayId))] public NursingCareTypeOfStayOption TypeOfStayOption { get; set; }
        [ForeignKey(nameof(CreatorId))] public User Creator { get; set; }
        [ForeignKey(nameof(UpdaterId))] public User Updater { get; set; }
        [ForeignKey(nameof(AssignedUserId))] public User AssignedUser { get; set; }

        public virtual ICollection<NursingCareAdditionalNeed> NursingCareAdditionalNeeds { get; set; }
        public virtual ICollection<NursingCarePackageReclaim> PackageReclaims { get; set; }
        public ICollection<NursingCareApprovalHistory> NursingCareApprovalHistories { get; set; }
        public virtual NursingCareBrokerageInfo NursingCareBrokerageInfo { get; set; }
    }
}
