using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response
{
    public class PackagePaymentViewResponse
    {
        public string ServiceUserName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public PackageType PackageType { get; set; }
        public string PackageTypeName => PackageType.GetDisplayName();
        public PagedResponse<PackagePaymentItemResponse> Payments { get; set; }
        public PackageTotalPaymentResponse PackagePayment { get; set; }
    }
}
