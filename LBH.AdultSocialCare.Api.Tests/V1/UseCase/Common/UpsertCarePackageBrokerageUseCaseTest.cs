using System;
using System.Collections.Generic;
using System.Linq;
using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Common
{
    public class UpsertCarePackageBrokerageUseCaseTest : BaseTest
    {
        private readonly Mock<ICarePackageGateway> _gatewayMock;
        private readonly Mock<IDatabaseManager> _dbManagerMock;
        private readonly UpsertCarePackageBrokerageUseCase _useCase;
        private readonly CarePackage _package;

        public UpsertCarePackageBrokerageUseCaseTest()
        {
            _package = new CarePackage
            {
                Id = Guid.NewGuid(),
                Details = new List<CarePackageDetail>()
            };

            _gatewayMock = new Mock<ICarePackageGateway>();
            _dbManagerMock = new Mock<IDatabaseManager>();

            _gatewayMock
                .Setup(gateway => gateway.GetPackageAsync(_package.Id))
                .ReturnsAsync(_package);

            _useCase = new UpsertCarePackageBrokerageUseCase(_gatewayMock.Object, _dbManagerMock.Object, Mapper);
        }

        [Fact]
        public void ShouldCreateCarePackageDetails()
        {
            var brokerageInfo = new CarePackageBrokerageDomain
            {
                Details = TestDataHelper.CreateCarePackageDetailDomainList(3, PackageDetailType.AdditionalNeed)
            };

            _useCase.ExecuteAsync(_package.Id, brokerageInfo);

            VerifyPackageDetails(brokerageInfo);
            VerifyDatabaseCalls();
        }

        [Fact]
        public void ShouldCreateCoreCostWhenNoDetailsProvided()
        {
            var brokerageInfo = new CarePackageBrokerageDomain
            {
                CoreCost = 12.34m,
                StartDate = DateTimeOffset.Now.Date,
                EndDate = DateTimeOffset.Now.Date.AddDays(100)
            };

            _useCase.ExecuteAsync(_package.Id, brokerageInfo);

            VerifyPackageDetails(brokerageInfo);
            VerifyDatabaseCalls();
        }

        [Fact]
        public void ShouldUpdateCarePackageSupplier()
        {
            var brokerageInfo = new CarePackageBrokerageDomain
            {
                SupplierId = 2
            };

            _useCase.ExecuteAsync(_package.Id, brokerageInfo);

            _package.SupplierId.Should().Be(2);
            VerifyDatabaseCalls();
        }

        [Fact]
        public void ShouldUpdateCarePackageDetails()
        {
            var existingDetails = FillPackageDetails();

            var brokerageInfo = new CarePackageBrokerageDomain
            {
                Details = existingDetails.DeepCopy()
            };

            foreach (var detail in brokerageInfo.Details)
            {
                detail.Cost += 10;
                detail.StartDate = detail.StartDate?.AddDays(-10) ?? DateTimeOffset.Now.Date.AddDays(-100);
                detail.EndDate = detail.EndDate?.AddDays(10) ?? DateTimeOffset.Now.Date.AddDays(100);
            }

            _useCase.ExecuteAsync(_package.Id, brokerageInfo);

            VerifyPackageDetails(brokerageInfo);
            VerifyDatabaseCalls();
        }

        [Fact]
        public void ShouldRemoveCarePackageDetails()
        {
            var existingDetails = FillPackageDetails();

            var brokerageInfo = new CarePackageBrokerageDomain
            {
                Details = existingDetails.DeepCopy()
            };

            brokerageInfo.Details.RemoveAt(0);
            brokerageInfo.Details.RemoveAt(1);

            _useCase.ExecuteAsync(_package.Id, brokerageInfo);

            VerifyPackageDetails(brokerageInfo);
            VerifyDatabaseCalls();
        }

        [Fact]
        public void ShouldFailOnMissingPackage()
        {
            var brokerageInfo = new CarePackageBrokerageDomain
            {
                Details = TestDataHelper.CreateCarePackageDetailDomainList(1, PackageDetailType.AdditionalNeed)
            };

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(Guid.NewGuid(), brokerageInfo))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status404NotFound);

            _dbManagerMock.Verify(mock => mock.SaveAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void ShouldNotRemoveCoreCost()
        {
            FillPackageDetails();

            var brokerageInfo = new CarePackageBrokerageDomain { /* let's remove'em all */ };

            _useCase.ExecuteAsync(_package.Id, brokerageInfo);

            VerifyPackageDetails(brokerageInfo);
            VerifyDatabaseCalls();
        }

        [Fact]
        public void ShouldFailOnSecondCoreCostCreation()
        {
            FillPackageDetails();

            var brokerageInfo = new CarePackageBrokerageDomain
            {
                Details = TestDataHelper.CreateCarePackageDetailDomainList(1, PackageDetailType.CoreCost)
            };

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_package.Id, brokerageInfo))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status400BadRequest);

            _dbManagerMock.Verify(mock => mock.SaveAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void ShouldFailOnUnknownDetailUpdate()
        {
            var existingDetails = FillPackageDetails();

            var brokerageInfo = new CarePackageBrokerageDomain
            {
                Details = existingDetails.DeepCopy()
            };

            foreach (var detail in brokerageInfo.Details.Where(detail => detail.Type != PackageDetailType.CoreCost))
            {
                detail.Id = Guid.NewGuid();
            }

            _useCase
                .Invoking(useCase => useCase.ExecuteAsync(_package.Id, brokerageInfo))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status400BadRequest);

            _dbManagerMock.Verify(mock => mock.SaveAsync(It.IsAny<string>()), Times.Never);
        }

        private List<CarePackageDetailDomain> FillPackageDetails()
        {
            var packageDetails = TestDataHelper.CreateCarePackageDetailDomainList(3, PackageDetailType.AdditionalNeed);

            foreach (var detail in packageDetails)
            {
                detail.Id = Guid.NewGuid();
            }

            _package.Details.AddRange(packageDetails.ToEntity());

            return packageDetails;
        }

        private void VerifyPackageDetails(CarePackageBrokerageDomain request)
        {
            _package.Details.Count.Should().Be(request.Details.Count + 1); // +1 for core cost detail

            var coreCostDetail = _package.Details.FirstOrDefault(d => d.Type is PackageDetailType.CoreCost);

            coreCostDetail.Should().NotBeNull();
            coreCostDetail?.Cost.Should().Be(request.CoreCost);
            coreCostDetail?.CostPeriod.Should().Be(PaymentPeriod.Weekly);
            coreCostDetail?.StartDate.Should().Be(request.StartDate);
            coreCostDetail?.EndDate.Should().Be(request.EndDate);

            foreach (var requestedDetail in request.Details)
            {
                _package.Details.Should().ContainEquivalentOf(requestedDetail, opt => opt.Excluding(d => d.Id));
            }
        }

        private void VerifyDatabaseCalls()
        {
            _gatewayMock.Verify(mock => mock.GetPackageAsync(_package.Id), Times.Once);
            _dbManagerMock.Verify(mock => mock.SaveAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
