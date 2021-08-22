using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.NursingCare
{
    public class NursingCareAdditionalNeedsDomain
    {
        public Guid Id { get; set; }

        public Guid NursingCarePackageId { get; set; }

        public int AdditionalNeedsPaymentTypeId { get; set; }
        public string AdditionalNeedsPaymentTypeName { get; set; }
        public string NeedToAddress { get; set; }

        public Guid CreatorId { get; set; }
        public Guid? UpdaterId { get; set; }
    }
}
