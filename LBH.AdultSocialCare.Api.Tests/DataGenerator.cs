using LBH.AdultSocialCare.Api.Tests.V1.DataGenerators;
using LBH.AdultSocialCare.Api.V1.Infrastructure;

namespace LBH.AdultSocialCare.Api.Tests
{
    public class DataGenerator
    {
        private readonly DatabaseContext _context;

        public DataGenerator(DatabaseContext context)
        {
            _context = context;

            NursingCare = new NursingCareGenerator(_context);
        }

        public NursingCareGenerator NursingCare { get; }
    }
}
