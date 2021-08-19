namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class CarerTypeResponse
    {
        public int CarerTypeId { get; set; }

        // 30m Call, 45m Call, 60m+ Call
        public string CarerTypeName { get; set; }
    }
}
