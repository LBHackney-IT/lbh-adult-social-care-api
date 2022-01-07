using LBH.AdultSocialCare.Api.Tests.V1.DataGenerators;
using LBH.AdultSocialCare.Data;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.Payments
{
    public class PayRunsControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;
        private readonly DatabaseTestDataGenerator _generator;
        private readonly DatabaseContext _dbContext;

        public PayRunsControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
            _generator = _fixture.Generator;
            _dbContext = _fixture.DatabaseContext;
        }


    }
}
