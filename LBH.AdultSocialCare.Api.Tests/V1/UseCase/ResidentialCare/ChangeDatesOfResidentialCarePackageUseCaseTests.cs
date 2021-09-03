using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.UseCase.ResidentialCare.Helpers;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Concrete;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.ResidentialCare
{
    public class ChangeDatesOfResidentialCarePackageUseCaseTests : BaseTest
    {
        private readonly Mock<IResidentialCarePackageGateway> _gateway;
        private readonly ResidentialCareTestData _testData;

        public ChangeDatesOfResidentialCarePackageUseCaseTests()
        {
            _testData = new ResidentialCareTestData();
            /*Context.Users.AddRange(_testData.GetAllUsers());
            Context.Clients.AddRange(_testData.GetAllClients());
            Context.ResidentialCarePackages.AddRange(_testData.GetAllResidentialCarePackages());*/
            _gateway = new Mock<IResidentialCarePackageGateway>();
            // _gateway = new ResidentialCarePackageGateway(Context, Mapper, null, null);
        }

        [Fact]
        public async Task ShouldRaiseExceptionIfResidentialCarePackageDoesNotExist()
        {
            var randomPackageId = new Guid();
            var useCase = InitUseCase(randomPackageId);

            Func<Task> action = () => useCase.UpdateAsync(randomPackageId, null, null);

            await action.Should().ThrowAsync<ApiException>().ConfigureAwait(false);
            _gateway.Verify(
                g => g.UpdateAsync(It.IsAny<ResidentialCarePackageForUpdateDomain>()),
                Times.Never);
        }

        [Fact]
        public async Task ShouldNotChangePackageStartDate()
        {
            var existingPackageId = new Guid("e5109a28-31fb-4e59-b433-0f2745f96a16");
            var useCase = InitUseCase(existingPackageId);
            var newStartDate = DateTimeOffset.Now.AddDays(-10);

            var originalPackage = await _gateway.Object.GetAsync(existingPackageId).ConfigureAwait(false);
            var updatedPackageResponse = await useCase.UpdateAsync(existingPackageId, newStartDate, null).ConfigureAwait(false);

            Assert.Equal(originalPackage.StartDate, updatedPackageResponse.StartDate);
            _gateway.Verify(
                g => g.UpdateAsync(It.IsAny<ResidentialCarePackageForUpdateDomain>()),
                Times.Once);
        }

        [Fact]
        public async Task ShouldUpdateIfDatesAreValid()
        {
            var existingPackageId = new Guid("e5109a28-31fb-4e59-b433-0f2745f96a16");
            var useCase = InitUseCase(existingPackageId);
            var newEndDate = DateTimeOffset.Now.AddDays(1000);

            var originalPackage = await _gateway.Object.GetAsync(existingPackageId).ConfigureAwait(false);
            var updatedPackageResponse = await useCase.UpdateAsync(existingPackageId, null, newEndDate).ConfigureAwait(false);

            Assert.Equal(newEndDate, updatedPackageResponse.EndDate);
            _gateway.Verify(
                g => g.UpdateAsync(It.IsAny<ResidentialCarePackageForUpdateDomain>()),
                Times.Once);
        }

        [Fact]
        public async Task ShouldNotAllowEndDateToBeLessThanStartDate()
        {
            var existingPackageId = new Guid("e5109a28-31fb-4e59-b433-0f2745f96a16");
            var useCase = InitUseCase(existingPackageId);
            var newEndDate = DateTimeOffset.Now.AddDays(-1000);

            Func<Task> action = () => useCase.UpdateAsync(existingPackageId, null, newEndDate);

            await action.Should().ThrowAsync<ApiException>().ConfigureAwait(false);
            _gateway.Verify(
                g => g.UpdateAsync(It.IsAny<ResidentialCarePackageForUpdateDomain>()),
                Times.Never);
        }

        private ChangeDatesOfResidentialCarePackageUseCase InitUseCase(Guid residentialCarePackageId)
        {
            _gateway.Setup(repo => repo.GetAsync(It.Is<Guid>(g => g == residentialCarePackageId)))
                 .ReturnsAsync(_testData.GetSingleResidentialCarePackage(residentialCarePackageId)?.ToDomain());
            _gateway.Setup(repo => repo.UpdateAsync(It.IsAny<ResidentialCarePackageForUpdateDomain>()))
                 .ReturnsAsync((ResidentialCarePackageForUpdateDomain val) => new ResidentialCarePackageDomain
                 {
                     Id = val.Id,
                     ClientId = val.ClientId,
                     StartDate = val.StartDate,
                     EndDate = val.EndDate
                 });

            var useCase = new ChangeDatesOfResidentialCarePackageUseCase(_gateway.Object, Mapper);

            return useCase;
        }
    }
}
