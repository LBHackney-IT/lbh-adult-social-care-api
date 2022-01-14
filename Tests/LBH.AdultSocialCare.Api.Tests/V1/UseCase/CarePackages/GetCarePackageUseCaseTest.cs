using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class GetCarePackageUseCaseTest : BaseTest
    {
        private readonly Mock<ICarePackageGateway> _gatewayMock;
        private readonly GetCarePackageUseCase _useCase;
        private Fixture _fixture;
        private BrokerPackageViewDomain _brokerViewDomain;
        private BrokerPackageViewQueryParameters _queryFilter;


        public GetCarePackageUseCaseTest()
        {
            _fixture = new Fixture();
            _brokerViewDomain = _fixture.Build<BrokerPackageViewDomain>()
                .Create();

            _queryFilter = new BrokerPackageViewQueryParameters
            {
                PageNumber = 1,
                PageSize = 10
            };

            _gatewayMock = new Mock<ICarePackageGateway>();
            _gatewayMock
                .Setup(m => m.GetBrokerPackageViewListAsync(_queryFilter))
                .ReturnsAsync(_brokerViewDomain);

            _useCase = new GetCarePackageUseCase(
                _gatewayMock.Object);
        }

        [Fact]
        public async Task ShouldReturnBrokerPackageViewList()
        {
            var result = await _useCase.GetBrokerPackageViewListAsync(_queryFilter);

            result.Packages.Count().Should().Be(_brokerViewDomain.Packages.Count());
            result.PagingMetaData.Should().NotBeNull();
        }

        [Fact]
        public void ShouldFilterBrokerPackageViewList()
        {
            _queryFilter.ServiceUserId = _brokerViewDomain.Packages.FirstOrDefault()?.ServiceUserId;

            _useCase.Invoking(useCase => useCase.GetBrokerPackageViewListAsync(_queryFilter)).Should().NotBeNull();
        }
    }
}
