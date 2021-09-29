using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
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
            var package = await CreatePackage();

            var request = FundedNursingCareCreationRequest(package.Id);

            var response = await CreateFncReclaim(request);

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

            var request = FundedNursingCareCreationRequest(packageId);

            var response = await CreateFncReclaim(request);

            response.Message.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task ShouldReturnFundedNursingCareReclaim()
        {
            var package = await CreatePackage();

            var request = FundedNursingCareCreationRequest(package.Id);

            await CreateFncReclaim(request);

            var response = await _fixture.RestClient
                .GetAsync<CarePackageReclaimResponse>($"api/v1/care-packages/{request.CarePackageId}/reclaims/fnc");

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            response.Content.Should().BeEquivalentTo(request, opt => opt
                .Excluding(reclaim => reclaim.EndDate));
            response.Content.EndDate.Should().BeNull();
        }

        [Fact]
        public async Task ShouldUpdateFundedNursingCareReclaim()
        {
            var package = await CreatePackage();

            var request = FundedNursingCareCreationRequest(package.Id);

            var createdFncReclaim = await CreateFncReclaim(request);

            var updateRequest = new FundedNursingCareUpdateRequest
            {
                Id = createdFncReclaim.Content.Id,
                Cost = 300M,
                ClaimCollector = createdFncReclaim.Content.ClaimCollector,
                SupplierId = createdFncReclaim.Content.SupplierId,
                Status = createdFncReclaim.Content.Status,
                Type = createdFncReclaim.Content.Type,
                StartDate = createdFncReclaim.Content.StartDate
            };

            var response = await _fixture.RestClient
                .PutAsync<bool>($"api/v1/care-packages/{request.CarePackageId}/reclaims/fnc", updateRequest);

            var carePackageReclaim = await _fixture.DatabaseContext.CarePackageReclaims
                .FirstAsync(c => c.CarePackageId == package.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            carePackageReclaim.Cost.Should().Be(updateRequest.Cost);
        }

        private async Task<CarePackage> CreatePackage()
        {
            return await _fixture.DataGenerator.CarePackages.CreatePackage(PackageType.NursingCare);
        }

        private async Task<TestResponse<CarePackageReclaimResponse>> CreateFncReclaim(FundedNursingCareCreationRequest request)
        {
            var response = await _fixture.RestClient
                .PostAsync<CarePackageReclaimResponse>($"api/v1/care-packages/{request.CarePackageId}/reclaims/fnc", request);
            return response;
        }

        private static FundedNursingCareCreationRequest FundedNursingCareCreationRequest(Guid carePackageId)
        {
            var request = new FundedNursingCareCreationRequest
            {
                CarePackageId = carePackageId,
                Cost = 200M,
                ClaimCollector = (ClaimCollector) 1,
                SupplierId = 1,
                Status = (ReclaimStatus) 1,
                Type = (ReclaimType) 1,
                StartDate = DateTimeOffset.Now.Date.AddDays(-1),
                EndDate = null,
                Description = "Test"
            };
            return request;
        }
    }
}
