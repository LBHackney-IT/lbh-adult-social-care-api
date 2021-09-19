using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class CarePackageResponse
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public bool IsFixedPeriod { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public bool HasRespiteCare { get; set; }
        public bool HasDischargePackage { get; set; }
        public bool IsThisAnImmediateService { get; set; }
        public bool IsThisUserUnderS117 { get; set; }
        public int? TypeOfStayId { get; set; }
        public string TypeOfStay { get; set; }
        public int? SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}
