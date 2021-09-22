using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.Gateways.CarePackages
{
    public class CarePackageDetailGatewayTests : BaseInMemoryDatabaseTest
    {
        private readonly ICarePackageDetailGateway _gateway;

        public CarePackageDetailGatewayTests()
        {
            _gateway = new CarePackageDetailGateway(Context, Mapper);
        }

        [Fact]
        public async Task ShouldReturnCarePackageDetailByCarePackageId()
        {
            //Arrange
            var carePackage = await DataGenerator.CarePackages.CreatePackage(Api.V1.AppConstants.Enums.PackageType.ResidentialCare);
            var supplier = await Context.Suppliers.FirstOrDefaultAsync();
            var carePackageDetails = new List<CarePackageDetail>()
            {
                new CarePackageDetail
                {
                    CarePackageId = carePackage.Id,
                    StartDate = DateTime.Now,
                    Period = PaymentPeriod.OneOff,
                    ServiceUserNeeds = "service user needs test-1"
                },
                new CarePackageDetail
                {
                    CarePackageId = carePackage.Id,
                    StartDate = DateTime.Now,
                    Period = PaymentPeriod.OneOff,
                    ServiceUserNeeds = "service user needs test-2"
                },
            };

            Context.CarePackageDetails.AddRange(carePackageDetails);
            await Context.SaveChangesAsync();

            //Act
            var res = await _gateway.GetCarePackageDetails(carePackage.Id);

            //Assert
            res.Should().HaveCount(2);
        }

        [Fact]
        public async Task ShouldReturnEmptyHistoriesForNonExistingPackage()
        {
            //Arrange
            var carePackageId = Guid.NewGuid();

            //Act
            var res = await _gateway.GetCarePackageDetails(carePackageId);

            //Assert
            res.Should().HaveCount(0);
        }
    }
}
