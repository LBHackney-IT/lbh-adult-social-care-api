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
    public class CarePackageReclaimGatewayTests : BaseInMemoryDatabaseTest
    {
        private readonly ICarePackageReclaimGateway _gateway;

        public CarePackageReclaimGatewayTests()
        {
            _gateway = new CarePackageReclaimGateway(Context, Mapper);
        }

        [Fact]
        public async Task ShouldReturnCarePackageReclaimByCarePackageId()
        {
            //Arrange
            var carePackage = await DataGenerator.CarePackages.CreatePackage(Api.V1.AppConstants.Enums.PackageType.ResidentialCare);
            var supplier = await Context.Suppliers.FirstOrDefaultAsync();
            var carePackageReclaims = new List<CarePackageReclaim>()
            {
                new CarePackageReclaim
                {
                    CarePackageId = carePackage.Id,
                    Description = "test",
                    ClaimCollector = ClaimCollector.Hackney,
                    Status = ReclaimStatus.Active,
                    Type = ReclaimType.CareCharge,
                    SubType = ReclaimSubType.CareChargeProvisional,
                    StartDate = DateTime.Now,
                    SupplierId = supplier.Id
                },
                new CarePackageReclaim
                {
                    CarePackageId = carePackage.Id,
                    Description = "test 1",
                    ClaimCollector = ClaimCollector.Hackney,
                    Status = ReclaimStatus.Active,
                    Type = ReclaimType.CareCharge,
                    SubType = ReclaimSubType.CareChargeProvisional,
                    StartDate = DateTime.Now,
                    SupplierId = supplier.Id
                },
            };

            Context.CarePackageReclaims.AddRange(carePackageReclaims);
            await Context.SaveChangesAsync();

            //Act
            var res = await _gateway.GetCarePackageReclaims(carePackage.Id);

            //Assert
            res.Should().HaveCount(2);
        }

        [Fact]
        public async Task ShouldReturnEmptyCarePackageReclaimForNonExistingPackage()
        {
            //Arrange
            var carePackageId = Guid.NewGuid();

            //Act
            var res = await _gateway.GetCarePackageReclaims(carePackageId);

            //Assert
            res.Should().HaveCount(0);
        }
    }
}
