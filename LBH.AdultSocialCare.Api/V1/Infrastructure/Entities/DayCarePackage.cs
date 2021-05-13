using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCare;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{
    public class DayCarePackage : BaseEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DayCarePackageId { get; set; }
        public int PackageId { get; set; }
        public Guid ClientId { get; set; }
        public bool IsFixedPeriodOrOngoing { get; set; }
        public DateTimeOffset StartDate { get; set; }
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
        public bool EscortNeeded { get; set; }
        public bool TransportEscortNeeded { get; set; }
        public int TermTimeConsiderationOptionId { get; set; }
        public int? CollegeId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdaterId { get; set; }
        public int StatusId { get; set; }

        [ForeignKey(nameof(PackageId))]
        public Package Package { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }

        [ForeignKey(nameof(TermTimeConsiderationOptionId))]
        public TermTimeConsiderationOption TermTimeConsiderationOption { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public User Creator { get; set; }

        [ForeignKey(nameof(UpdaterId))]
        public User Updater { get; set; }

        [ForeignKey(nameof(StatusId))]
        public DayCarePackageStatus Status { get; set; }

        public ICollection<DayCarePackageOpportunity> DayCarePackageOpportunities { get; set; }
        public ICollection<DayCareApprovalHistory> DayCareApprovalHistories { get; set; }
    }

}
