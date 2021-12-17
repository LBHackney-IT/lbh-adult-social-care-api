using LBH.AdultSocialCare.Api.Tests.V1.DataGenerators;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Concrete;
using System;
using System.Collections.Generic;
using FluentAssertions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.Gateways.CarePackages
{
    public class CarePackageReclaimGatewayTests : BaseInMemoryDatabaseTest
    {
        private readonly DatabaseTestDataGenerator _generator;
        private readonly CarePackageReclaimGateway _gateway;

        public CarePackageReclaimGatewayTests()
        {
            _gateway = new CarePackageReclaimGateway(Context);
            _generator = new DatabaseTestDataGenerator(Context);
        }

        //Todo FK:
        //[Theory]
        //[MemberData(nameof(ReclaimStatusExpectations))]
        //public void ShouldReturnCorrectStatus(ReclaimStatus currentStatus, DateTimeOffset startDate, ReclaimStatus expectedStatus)
        //{
        //    var package = _generator.CreateCarePackage();
        //    var reclaim = _generator.CreateCarePackageReclaim(package, ClaimCollector.Supplier, ReclaimType.CareCharge);

        //    reclaim.Status = currentStatus;
        //    reclaim.StartDate = startDate;
        //    Context.SaveChanges();

        //    _gateway.GetAsync(reclaim.Id);

        //    reclaim.Status.Should().Be(expectedStatus);
        //}

        public static IEnumerable<object[]> ReclaimStatusExpectations() =>
            new List<object[]>
            {
                new object[] { ReclaimStatus.Cancelled, DateTimeOffset.Now.AddDays(100), ReclaimStatus.Cancelled },
                new object[] { ReclaimStatus.Ended, DateTimeOffset.Now.AddDays(100), ReclaimStatus.Ended },
                new object[] { ReclaimStatus.Pending, DateTimeOffset.Now.AddDays(-50), ReclaimStatus.Active },
                new object[] { ReclaimStatus.Active, DateTimeOffset.Now.AddDays(50), ReclaimStatus.Pending },
                new object[] { ReclaimStatus.Pending, DateTimeOffset.Now.AddDays(50), ReclaimStatus.Pending },
                new object[] { ReclaimStatus.Active, DateTimeOffset.Now.AddDays(-50), ReclaimStatus.Active }
            };
    }
}
