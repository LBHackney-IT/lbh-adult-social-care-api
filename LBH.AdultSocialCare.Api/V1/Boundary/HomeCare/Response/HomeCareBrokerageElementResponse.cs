namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response
{
    public class HomeCareBrokerageElementResponse
    {
        public int ElementId { get; set; }

        // Primary Carer, Secondary Carer, Domestic Carer etc.
        public string ElementName { get; set; }
    }
}
