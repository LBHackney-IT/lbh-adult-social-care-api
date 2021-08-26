using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare
{
    public class FundedNursingCare
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid NursingCarePackageId { get; set; }

        public int CollectorId { get; set; }

        public int ReclaimTargetInstitutionId { get; set; }

        [ForeignKey(nameof(NursingCarePackageId))] public NursingCarePackage NursingCarePackage { get; set; }
    }
}
