using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.Gateways.Common
{
    public class CarePackageHistoryGatewayTests : BaseInMemoryDatabaseTest
    {
        private readonly ICarePackageHistoryGateway _gateway;

        public CarePackageHistoryGatewayTests()
        {
            _gateway = new CarePackageHistoryGateway(Context);
        }

        [Fact]
        public async Task ShouldReturnHistoriesForPackage()
        {
            //Arrange
            var carePackageId = new Guid();
            var historyList = new List<CarePackageHistory>();

            for (var i = 0; i < 10; i++)
            {
                historyList.Add(TestDataHelper.CreateCarePackageHistory(carePackageId: carePackageId));
            }

            var carePackageHistory = historyList.AsAsyncQueryable();

            var mockSet = new Mock<DbSet<CarePackageHistory>>();
            mockSet.As<IQueryable<CarePackageHistory>>().Setup(m => m.Provider).Returns(carePackageHistory.Provider);
            mockSet.As<IQueryable<CarePackageHistory>>().Setup(m => m.Expression).Returns(carePackageHistory.Expression);
            mockSet.As<IQueryable<CarePackageHistory>>().Setup(m => m.ElementType).Returns(carePackageHistory.ElementType);
            mockSet.As<IQueryable<CarePackageHistory>>().Setup(m => m.GetEnumerator()).Returns(carePackageHistory.GetEnumerator());

            Context.CarePackageHistories = mockSet.Object;

            //Act
            var histories = await _gateway.ListAsync(carePackageId);

            //Assert
            histories.Should().HaveCount(10);
        }

        [Fact]
        public async Task ShouldReturnEmptyHistoriesForNonExistingPackage()
        {
            //Arrange
            var carePackageId = Guid.NewGuid();

            //Act
            var res = await _gateway.ListAsync(carePackageId).ConfigureAwait(false);

            //Assert
            res.Should().HaveCount(0);
        }
    }
}
