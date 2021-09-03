using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Controllers.DayCarePackageControllers;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.Controllers
{

    public class DayCarePackageControllerTest
    {

        [Fact]
        public async Task GetSingleDayCarePackageSuccess()
        {
            // Arrange
            Guid clientId = Guid.NewGuid();
            Mock<IGetDayCarePackageUseCase> useCaseMock = new Mock<IGetDayCarePackageUseCase>();

            useCaseMock.Setup(item => item.Execute(It.IsAny<Guid>()))
                .ReturnsAsync(() => new DayCarePackageResponse
                {
                    ClientId = clientId
                });

            DayCarePackageController controller =
                new DayCarePackageController(null, useCaseMock.Object, null, null, null, null, null, null, null);

            // Act
            var getResult = await controller.GetSingleDayCarePackage(Guid.NewGuid()).ConfigureAwait(false);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(getResult);
            var dayCarePackageResponse = Assert.IsType<DayCarePackageResponse>(okObjectResult.Value);
            Assert.Equal(clientId, dayCarePackageResponse.ClientId);
        }

    }

}
