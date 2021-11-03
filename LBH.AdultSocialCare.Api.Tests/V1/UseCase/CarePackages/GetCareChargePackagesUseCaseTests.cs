using AutoFixture;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class GetCareChargePackagesUseCaseTests : BaseTest
    {
        private Mock<ICareChargesGateway> _mockGateway;
        private GetCareChargePackagesUseCase _getCareChargePackagesUseCase;
        private Fixture _fixture;

        public GetCareChargePackagesUseCaseTests()
        {
            _mockGateway = new Mock<ICareChargesGateway>();
            _getCareChargePackagesUseCase = new GetCareChargePackagesUseCase(_mockGateway.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task ShouldReturnCareChargePackages()
        {
            // Arrange
            var stubbedEntities = _fixture.Create<PagedList<CareChargePackagesDomain>>();
            var requestParam = new CareChargePackagesParameters() { PageSize = 10, PageNumber = 1 };


            _mockGateway.Setup(x => x.GetCareChargePackages(requestParam))
                .ReturnsAsync(stubbedEntities);

            // Act
            var expectedResponse = new PagedResponse<CareChargePackagesResponse>
            {
                PagingMetaData = stubbedEntities.PagingMetaData,
                Data = stubbedEntities.ToResponse()
            };
            var response = await _getCareChargePackagesUseCase.GetCareChargePackages(requestParam).ConfigureAwait(false);

            // Assert
            _mockGateway.Verify(x => x.GetCareChargePackages
                (It.Is<CareChargePackagesParameters>(d => d.PageSize == 10 && d.PageNumber == 1)));

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
