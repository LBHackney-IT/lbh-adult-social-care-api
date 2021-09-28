using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.Common
{
    public class CarePackageReclaimControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;

        public CarePackageReclaimControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldCreateFundedNursingCareReclaimForExistingNursingCarePackage()
        {
            var package = await _fixture.DataGenerator.CarePackages.CreatePackage(PackageType.NursingCare);

            var request = new FundedNursingCareCreationRequest
            {
                CarePackageId = package.Id,
                Cost = 200M,
                ClaimCollector = (ClaimCollector) 1,
                SupplierId = 1,
                Status = (ReclaimStatus) 1,
                Type = (ReclaimType) 1,
                StartDate = DateTimeOffset.Now.Date.AddDays(-1),
                EndDate = null,
                Description = "Test"
            };

            var response = await _fixture.RestClient
                .PostAsync<CarePackageReclaimResponse>($"api/v1/care-packages/{request.CarePackageId}/reclaims/fnc", request);

            var carePackageReclaim = await _fixture.DatabaseContext.CarePackageReclaims
                .FirstAsync(c => c.CarePackageId == package.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            carePackageReclaim.Should().BeEquivalentTo(request, opt => opt
                .Excluding(reclaim => reclaim.EndDate));
            carePackageReclaim.EndDate.Should().BeNull();
        }

        [Fact]
        public async Task ShouldReturnNotFoundErrorForNonExistingCarePackage()
        {
            var packageId = Guid.NewGuid();

            var request = new FundedNursingCareCreationRequest
            {
                CarePackageId = packageId,
                Cost = 200M,
                ClaimCollector = (ClaimCollector) 1,
                SupplierId = 1,
                Status = (ReclaimStatus) 1,
                Type = (ReclaimType) 1,
                StartDate = DateTimeOffset.Now.Date.AddDays(-1),
                EndDate = null,
                Description = "Test"
            };

            var response = await _fixture.RestClient
                .PostAsync<CarePackageReclaimResponse>($"api/v1/care-packages/{request.CarePackageId}/reclaims/fnc", request);

            response.Message.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
