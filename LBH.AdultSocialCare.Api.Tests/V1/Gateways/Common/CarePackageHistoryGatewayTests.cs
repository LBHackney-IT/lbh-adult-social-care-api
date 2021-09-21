using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.Constants;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
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
            var user = new Client() { Id = Guid.Parse(UserConstants.DefaultApiUserId) };
            Context.Clients.Add(user);
            await Context.SaveChangesAsync().ConfigureAwait(false);

            var carePackage = new CarePackage() {ServiceUserId = Guid.Parse(UserConstants.DefaultApiUserId)};
            Context.CarePackages.Add(carePackage);
            await Context.SaveChangesAsync().ConfigureAwait(false);

            var carePackageId = carePackage.Id;
            var carePackageHistory = new List<CarePackageHistory>()
            {
                new CarePackageHistory
                {
                    CarePackageId = carePackageId,
                    Description = "test"
                },
                new CarePackageHistory
                {
                    CarePackageId = carePackageId,
                    Description = "test 1"
                },
            };

            Context.CarePackageHistories.AddRange(carePackageHistory);
            await Context.SaveChangesAsync().ConfigureAwait(false);

            //Act
            var res = await _gateway.ListAsync(carePackageId).ConfigureAwait(false);

            //Assert
            res.Should().HaveCount(2);
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
