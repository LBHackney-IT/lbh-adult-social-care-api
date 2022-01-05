using System;
using System.Globalization;

namespace DataImporter.Model
{
    public class ExcelRowModel
    {
        public int RowNumber { get; set; }
        public string HackneyID { get; set; }
        public string ServiceTypeGroup { get; set; }
        public string ServiceType { get; set; }
        public string ElementType { get; set; }
        public string CostPer { get; set; }
        public decimal Cost
        {
            get
            {
                try
                {
                    NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign;
                    var d = decimal.Parse(CostPer.Replace("£", string.Empty).Replace(".", string.Empty).Replace(",", "."), style, CultureInfo.InvariantCulture);

                    return d;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public string Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public string StartDateOA { get; set; }
        public DateTimeOffset StartDate
        {
            get
            {
                DateTime sourceDT = DateTime.FromOADate(long.Parse(StartDateOA));
                return new DateTimeOffset(sourceDT.Date, TimeSpan.Zero);
            }
        }

        public string EndDateOA { get; set; }
        public DateTimeOffset? EndDate
        {
            get
            {
                if (string.IsNullOrEmpty(EndDateOA))
                {
                    return null;
                }
                else
                {
                    DateTime sourceDT = DateTime.FromOADate(long.Parse(StartDateOA));
                    return new DateTimeOffset(sourceDT.Date, TimeSpan.Zero);
                }
            }
        }

        public string BudgetCode { get; set; }
        public string Subjective
        {
            get
            {
                return string.IsNullOrEmpty(BudgetCode) ? "" : BudgetCode.Substring(BudgetCode.LastIndexOf("-X") - 6, 6);
            }
        }

        public string SupplierID { get; set; }
        public string SupplierSite { get; set; }
    }
}
