
using LBH.AdultSocialCare.Data.Constants.Enums;
using System;
using System.Linq;

namespace DataImporter.Model
{
    public class ExcelPackageModel
    {
        private readonly string[] _corePackageType = new string[] { "Long Stay Residential Care", "Residential Placement", "Short Stay Residential Care" };
        private readonly string[] _anpPackageType = new string[] { "Additional Needs Payment", "Agreed Council Top Up Payment", "Day Care (weekly)", "Personal Allowance Payment" };
        private readonly string[] _careChargeProvisionalNetPackageType = new string[] { "Client contribution", "CRAG Income (net off)", "CRAG Provisional to Home (Net Off)" };
        private readonly string[] _careChargeProvisionalGrossPackageType = new string[] { "CRAG Provisional (to Auth)", "CRAG Income" };
        private readonly string[] _careCharge13PlusNetPackageType = new string[] { "Weeks 13 onwards - Net" };
        private readonly string[] _careCharge13PlusGrossPackageType = new string[] { "Short Stay Residential Charge (To Auth)", "Third Party top up (to Authority)", "Weeks 13 Onwards" };

        private readonly ExcelPackageType _excelPackageType;
        private readonly PackageDetailType _packageDetailType;
        private readonly ClaimCollector _claimCollector;
        private readonly ReclaimSubType _reclaimSubType;
        public ExcelPackageModel(string elementType)
        {
            if (_corePackageType.Contains(elementType, StringComparer.OrdinalIgnoreCase))
            {
                _excelPackageType = ExcelPackageType.Detail;
                _packageDetailType = PackageDetailType.CoreCost;
            }
            else if (_anpPackageType.Contains(elementType, StringComparer.OrdinalIgnoreCase))
            {
                _excelPackageType = ExcelPackageType.Detail;
                _packageDetailType = PackageDetailType.AdditionalNeed;
            }
            else if (_careChargeProvisionalNetPackageType.Contains(elementType, StringComparer.OrdinalIgnoreCase))
            {
                _excelPackageType = ExcelPackageType.CareCharge;
                _reclaimSubType = ReclaimSubType.CareChargeProvisional;
                _claimCollector = ClaimCollector.Supplier;
            }
            else if (_careChargeProvisionalGrossPackageType.Contains(elementType, StringComparer.OrdinalIgnoreCase))
            {
                _excelPackageType = ExcelPackageType.CareCharge;
                _reclaimSubType = ReclaimSubType.CareChargeProvisional;
                _claimCollector = ClaimCollector.Hackney;
            }
            else if (_careCharge13PlusNetPackageType.Contains(elementType, StringComparer.OrdinalIgnoreCase))
            {
                _excelPackageType = ExcelPackageType.CareCharge;
                _reclaimSubType = ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks;
                _claimCollector = ClaimCollector.Supplier;

            }
            else if (_careCharge13PlusGrossPackageType.Contains(elementType, StringComparer.OrdinalIgnoreCase))
            {
                _excelPackageType = ExcelPackageType.CareCharge;
                _reclaimSubType = ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks;
                _claimCollector = ClaimCollector.Hackney;
            }

        }

        public enum ExcelPackageType
        {
            Detail,
            CareCharge
        }

        public ExcelPackageType PackageType { get { return _excelPackageType; } }
        public PackageDetailType PackageDetailType { get { return _packageDetailType; } }
        public ClaimCollector ClaimCollector { get { return _claimCollector; } }
        public ReclaimSubType ReclaimSubType { get { return _reclaimSubType; } }


    }
}
