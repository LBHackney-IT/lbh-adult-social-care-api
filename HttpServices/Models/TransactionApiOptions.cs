using System;

namespace HttpServices.Models
{
    public class TransactionApiOptions
    {
        public Uri TransactionsBaseUrl { get; set; }
        public string TransactionsApiKey { get; set; }
    }
}
