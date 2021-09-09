using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.NursingCare
{
    public class GetFundedNursingCarePriceUseCaseTests
    {
        [Fact]
        public async Task ShouldQueryActiveFncPrice()
        {

            var gateway = new Mock<IFundedNursingCaseGateway>();
            var useCase = new GetFundedNursingCarePriceUseCase(gateway.Object);

            var currentTime = DateTime.Now;

            useCase.CurrentDateTimeOffsetProvider = new MockCurrentDateTimeOffsetProvider { Now = currentTime };
            await useCase.GetActiveFundedNursingCarePriceAsync().ConfigureAwait(false);

            gateway.Verify(g => g.GetFundedNursingCarePriceAsync(currentTime), Times.Once);
        }
    }
}
