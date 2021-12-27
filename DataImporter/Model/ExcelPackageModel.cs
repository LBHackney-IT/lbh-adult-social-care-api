
using LBH.AdultSocialCare.Data.Constants.Enums;
using System;
using System.Linq;

namespace DataImporter.Model
{
    public class ExcelPackageModel
    {

        private readonly string[] _corePackageType = new string[] { "Long Stay Residential Care", "Residential Placement", "Short Stay Residential Care", "Short Stay Nursing Care", "Nursing Care", "Long Stay Nursing Care" };
        private readonly string[] _anpPackageType = new string[] { "Additional Needs Payment", "Agreed Council Top Up Payment", "Day Care (weekly)", "Personal Allowance Payment" };
        private readonly string[] _anpOneOffPackageType = new string[] { "One-Off Cost" };
        private readonly string[] _careChargeProvisionalNetPackageType = new string[] { "Client contribution", "CRAG Income (net off)", "CRAG Provisional to Home (Net Off)", "Client contribution net off" };
        private readonly string[] _careChargeProvisionalGrossPackageType = new string[] { "CRAG Provisional (to Auth)", "CRAG Income" };
        private readonly string[] _careCharge13PlusNetPackageType = new string[] { "Weeks 13 onwards - Net" };
        private readonly string[] _careCharge13PlusGrossPackageType = new string[] { "Short Stay Residential Charge (To Auth)", "Third Party top up (to Authority)", "Weeks 13 Onwards" };

        private readonly string[] _fncNetPackageType = new string[] { "FNCC Payment to Home", "Nursing Care net of FNCC" };
        private readonly string[] _fncGrossPackageType = new string[] { "FNCC Reclaim" };



        private readonly ExcelPackageType _excelPackageType;
        private readonly PackageDetailType _packageDetailType;
        private readonly ClaimCollector _claimCollector;
        private readonly ReclaimSubType? _reclaimSubType;
        private readonly ReclaimType _reclaimType;
        private readonly PaymentPeriod _costPeriod;

        public ExcelPackageModel(string elementType)
        {
            _costPeriod = PaymentPeriod.Weekly;

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
                _excelPackageType = ExcelPackageType.Reclaim;
                _reclaimSubType = LBH.AdultSocialCare.Data.Constants.Enums.ReclaimSubType.CareChargeProvisional;
                _reclaimType = ReclaimType.CareCharge;
                _claimCollector = ClaimCollector.Supplier;
            }
            else if (_careChargeProvisionalGrossPackageType.Contains(elementType, StringComparer.OrdinalIgnoreCase))
            {
                _excelPackageType = ExcelPackageType.Reclaim;
                _reclaimSubType = LBH.AdultSocialCare.Data.Constants.Enums.ReclaimSubType.CareChargeProvisional;
                _reclaimType = ReclaimType.CareCharge;
                _claimCollector = ClaimCollector.Hackney;
            }
            else if (_careCharge13PlusNetPackageType.Contains(elementType, StringComparer.OrdinalIgnoreCase))
            {
                _excelPackageType = ExcelPackageType.Reclaim;
                _reclaimSubType = LBH.AdultSocialCare.Data.Constants.Enums.ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks;
                _reclaimType = ReclaimType.CareCharge;
                _claimCollector = ClaimCollector.Supplier;

            }
            else if (_careCharge13PlusGrossPackageType.Contains(elementType, StringComparer.OrdinalIgnoreCase))
            {
                _excelPackageType = ExcelPackageType.Reclaim;
                _reclaimSubType = LBH.AdultSocialCare.Data.Constants.Enums.ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks;
                _reclaimType = ReclaimType.CareCharge;
                _claimCollector = ClaimCollector.Hackney;
            }
            else if (_anpOneOffPackageType.Contains(elementType, StringComparer.OrdinalIgnoreCase))
            {
                _excelPackageType = ExcelPackageType.Detail;
                _packageDetailType = PackageDetailType.AdditionalNeed;
                _costPeriod = PaymentPeriod.OneOff;
            }
            else if (_fncGrossPackageType.Contains(elementType, StringComparer.OrdinalIgnoreCase))
            {
                _excelPackageType = ExcelPackageType.Reclaim;
                _reclaimSubType = LBH.AdultSocialCare.Data.Constants.Enums.ReclaimSubType.FncReclaim;
                _reclaimType = ReclaimType.Fnc;
                _claimCollector = ClaimCollector.Hackney;
            }
            else if (_fncNetPackageType.Contains(elementType, StringComparer.OrdinalIgnoreCase))
            {
                _excelPackageType = ExcelPackageType.Reclaim;
                _reclaimSubType = LBH.AdultSocialCare.Data.Constants.Enums.ReclaimSubType.FncPayment;
                _reclaimType = ReclaimType.Fnc;
                _claimCollector = ClaimCollector.Supplier;
            }
            else
            {
                throw new Exception($"Undefined element type: {elementType}");
            }
        }

        public enum ExcelPackageType
        {
            Detail,
            Reclaim
        }

        public static PackageType GetPackageType(string elementType)
        {
            var _residentialPackageType = new[] { "Residential", "Interim Residential Bed", "Residential Care", "Short Stay Residential Home" };
            var _nursingPackageType = new[] { "FNCC reclaim", "Interim Nursing Bed", "Nursing Care", "Short Stay Nursing Home" };

            if (_residentialPackageType.Contains(elementType, StringComparer.OrdinalIgnoreCase))
            {
                return PackageType.ResidentialCare;
            }
            else if (_nursingPackageType.Contains(elementType, StringComparer.OrdinalIgnoreCase))
            {
                return PackageType.NursingCare;
            }
            else
            {
                throw new Exception($"Undefined package type: {elementType}");
            }
        }
        public ExcelPackageType SubPackageType { get { return _excelPackageType; } }
        public PackageDetailType PackageDetailType { get { return _packageDetailType; } }
        public ClaimCollector ClaimCollector { get { return _claimCollector; } }
        public ReclaimSubType? ReclaimSubType { get { return _reclaimSubType; } }
        public ReclaimType ReclaimType { get { return _reclaimType; } }
        public PaymentPeriod CostPeriod { get { return _costPeriod; } }


    }
}
