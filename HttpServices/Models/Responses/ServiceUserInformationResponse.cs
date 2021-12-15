using System.Collections.Generic;

namespace HttpServices.Models.Responses
{
    public class ServiceUserInformationResponse
    {
        public List<ResidentResponse> Residents { get; set; }
        public int totalCount { get; set; }
        public int nextCursor { get; set; }
    }
}
