using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response
{
    public class ResidentialCareAdditionalNeedsCostResponse
    {
        public Guid ResidentialCareAdditionalNeedsCostId { get; set; }
        public int AdditionalNeedsPaymentTypeId { get; set; }
        public string AdditionalNeedsPaymentTypeName { get; set; }
        public decimal AdditionalNeedsCost { get; set; }
    }
}
