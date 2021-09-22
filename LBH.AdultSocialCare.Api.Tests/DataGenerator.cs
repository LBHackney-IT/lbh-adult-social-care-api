using LBH.AdultSocialCare.Api.Tests.V1.DataGenerators;
using LBH.AdultSocialCare.Api.V1.Infrastructure;

namespace LBH.AdultSocialCare.Api.Tests
{
    public class DataGenerator
    {
        public DataGenerator(DatabaseContext context)
        {
            NursingCare = new NursingCareGenerator(context);
            ResidentialCare = new ResidentialCareGenerator(context);
            CareCharge = new CareChargeGenerator(context);
            CarePackages = new CarePackageGenerator(context);
        }

        public NursingCareGenerator NursingCare { get; }
        public ResidentialCareGenerator ResidentialCare { get; }
        public CareChargeGenerator CareCharge { get; }
        public CarePackageGenerator CarePackages { get; }
    }
}
