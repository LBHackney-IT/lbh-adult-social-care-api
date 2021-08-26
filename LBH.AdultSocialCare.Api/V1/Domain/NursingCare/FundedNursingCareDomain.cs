using System;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Domain.NursingCare
{
    public class FundedNursingCareDomain : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid NursingCarePackageId { get; set; }

        public int CollectorId { get; set; }
        public int ReclaimTargetInstitutionId { get; set; }
    }
}
