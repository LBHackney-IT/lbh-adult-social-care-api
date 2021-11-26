using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response
{
    public class PackagePaymentViewResponse
    {
        public Guid PackageId { get; set; }
        public string ServiceUserName { get; set; }
        public int CedarId { get; set; }
        public string SupplierName { get; set; }
        public PackageType PackageType { get; set; }
        public string PackageTypeName => PackageType.GetDisplayName();
        public PagedResponse<PackagePaymentItemResponse> Payments { get; set; }
        public PackageTotalPaymentResponse PackagePayment { get; set; }
    }
}
