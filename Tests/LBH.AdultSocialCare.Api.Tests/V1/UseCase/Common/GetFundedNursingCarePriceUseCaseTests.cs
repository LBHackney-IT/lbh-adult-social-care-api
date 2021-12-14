using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete;
using Moq;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.TestFramework;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Common
{
    public class GetFundedNursingCarePriceUseCaseTests
    {
        [Fact]
        public async Task ShouldQueryActiveFncPrice()
        {
            var gateway = new Mock<IFundedNursingCareGateway>();
            var useCase = new GetFundedNursingCarePriceUseCase(gateway.Object);

            var currentTime = DateTime.Now;

            useCase.CurrentDateProvider = new MockCurrentDateProvider { Now = currentTime };
            await useCase.GetActiveFundedNursingCarePriceAsync().ConfigureAwait(false);

            gateway.Verify(g => g.GetFundedNursingCarePriceAsync(currentTime), Times.Once);
        }
    }
}
