using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServices.Models.Responses
{
    public class SupplierTaxRateResponse
    {
        public int TaxRateId { get; set; }
        public float VATPercentage { get; set; }
        public long SupplierId { get; set; }

        public SupplierMinimalResponse Supplier { get; set; }
    }
}
