using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServices.Models.Responses
{
    public class DocumentResponse
    {
        public Guid FileId { get; set; }
        public string FileName { get; set; }
    }
}
