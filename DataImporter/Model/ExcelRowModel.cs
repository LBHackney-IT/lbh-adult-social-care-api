using System;
using System.Globalization;

namespace DataImporter.Model
{
    public class ExcelRowModel
    {
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
                    NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign ;
                    CultureInfo provider = new CultureInfo("en-GB");
                    
                    var d = decimal.Parse(CostPer.Replace("£", string.Empty).Replace(".", string.Empty).Replace(",","."), style, CultureInfo.InvariantCulture);
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
                return DateTime.FromOADate(long.Parse(StartDateOA));
            }
        }

        public string EndDateOA { get; set; }
        public DateTimeOffset? EndDate
        {
            get
            {
                return string.IsNullOrEmpty(EndDateOA) ? null : DateTime.FromOADate(long.Parse(EndDateOA));
            }
        }

        public string BudgetCode { get; set; }
        public string SupplierID { get; set; }
        public string SupplierSite { get; set; }


    }
}
