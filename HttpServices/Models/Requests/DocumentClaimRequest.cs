using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServices.Models.Requests
{
    public class DocumentClaimRequest
    {
        public string ServiceAreaCreatedBy { get; set; }
        public string UserCreatedBy { get; set; }
        public string ApiCreatedBy { get; set; }
        public DateTime RetentionExpiresAt { get; set; }
        public DateTime ValidUntil { get; set; }
        public string Base64Document { get; set; }
    }
}
