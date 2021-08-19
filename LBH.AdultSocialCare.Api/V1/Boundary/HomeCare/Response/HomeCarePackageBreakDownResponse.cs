namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response
{
    public class HomeCarePackageBreakDownResponse
    {
        public double PersonalCareTotalHours { get; set; }

        public double EscortTotalHours { get; set; }

        public double DomesticTotalHours { get; set; }

        public double WakingNightsTotalHours { get; set; }

        public double SleepingNightsTotalHours { get; set; }

        public double NightOwlTotalHours { get; set; }
    }
}
