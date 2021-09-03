using Bogus;
using LBH.AdultSocialCare.Api.V1.Controllers.NursingCare;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.Controllers.NursingCare
{

    public class NursingCarePackageTests : BaseTest
    {

        [Fact]
        public async Task CreateNursingCarePackageOk()
        {
            // Arrange
            NursingCarePackageForCreationRequest fakeModel = GetNursingCarePackageCreationBogus();
            Guid createResponseId = Guid.NewGuid();

            // Mock create package
            var createNursingCarePackageMock = new Mock<ICreateNursingCarePackageUseCase>();

            createNursingCarePackageMock.Setup(item => item.ExecuteAsync(It.IsAny<NursingCarePackageForCreationDomain>()))
                .ReturnsAsync(() => new NursingCarePackageResponse
                {
                    Id = createResponseId
                });

            // Mock status change package
            var changeStatusMock = new Mock<IChangeStatusNursingCarePackageUseCase>();

            changeStatusMock.Setup(item => item.UpdateAsync(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(() => null);

            using NursingCarePackageController controller =
                GetController(changeStatusNursingCarePackageUseCase: changeStatusMock.Object,
                    createNursingCarePackageUseCase: createNursingCarePackageMock.Object);

            // Act
            var result = await controller.CreateNursingCarePackage(fakeModel).ConfigureAwait(false);

            // Assert
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
            NursingCarePackageResponse packageResponseModel = Assert.IsType<NursingCarePackageResponse>(okResult.Value);
            Assert.Equal(createResponseId, packageResponseModel.Id);
        }

        private static NursingCarePackageController GetController(
            IUpdateNursingCarePackageUseCase updateNursingCarePackageUseCase = null,
            IGetNursingCarePackageUseCase getNursingCarePackageUseCase = null,
            IChangeStatusNursingCarePackageUseCase changeStatusNursingCarePackageUseCase = null,
            IGetAllNursingCarePackageUseCase getAllNursingCarePackageUseCase = null,
            IGetAllNursingCareHomeTypeUseCase getAllNursingCareHomeTypeUseCase = null,
            IGetAllNursingCareTypeOfStayOptionUseCase getAllNursingCareTypeOfStayOptionUseCase = null,
            ICreateNursingCarePackageUseCase createNursingCarePackageUseCase = null,
            IGetAllNursingCareApprovalHistoryUseCase getAllNursingCareApprovalHistoryUseCase = null)
        {
            return new NursingCarePackageController(updateNursingCarePackageUseCase, getNursingCarePackageUseCase,
                changeStatusNursingCarePackageUseCase, getAllNursingCarePackageUseCase, getAllNursingCareHomeTypeUseCase,
                getAllNursingCareTypeOfStayOptionUseCase, createNursingCarePackageUseCase,
                getAllNursingCareApprovalHistoryUseCase);
        }

        private static NursingCarePackageForCreationRequest GetNursingCarePackageCreationBogus()
        {
            var packageFaker = new Faker<NursingCarePackageForCreationRequest>()
                .RuleFor(item => item.ClientId, _ => Guid.NewGuid())
                .RuleFor(item => item.StartDate, faker => faker.Date.PastOffset());

            return packageFaker.Generate();
        }

    }

}
