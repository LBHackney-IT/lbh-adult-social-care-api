using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{

    public class DayCarePackage : BaseEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DayCarePackageId { get; set; }

        public Guid PackageId { get; set; }
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
        public int TermTimeConsiderationOptionId { get; set; }
        public string HowLong { get; set; }

        // Daily, weekly, monthly
        public string HowManyTimesPerMonth { get; set; }
        public string OpportunitiesNeedToAddress { get; set; }

        public Guid CreatorId { get; set; }
        public Guid? UpdaterId { get; set; }
        public Guid StatusId { get; set; }

        [ForeignKey(nameof(PackageId))]
        public Package Package { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Clients Client { get; set; }

        [ForeignKey(nameof(TermTimeConsiderationOptionId))]
        public TermTimeConsiderationOption TermTimeConsiderationOption { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public Users Creator { get; set; }

        [ForeignKey(nameof(UpdaterId))]
        public Users Updater { get; set; }

        [ForeignKey(nameof(StatusId))]
        public Status Status { get; set; }

    }

}
