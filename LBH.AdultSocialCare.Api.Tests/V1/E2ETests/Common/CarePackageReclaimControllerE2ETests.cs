using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using HttpServices.Helpers;
using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.Tests.V1.DataGenerators;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.Common
{
    public class CarePackageReclaimControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;
        private readonly DatabaseTestDataGenerator _generator;

        public CarePackageReclaimControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
            _generator = _fixture.Generator;
        }

        [Fact]
        public async Task ShouldCreateFundedNursingCareReclaimForExistingNursingCarePackage()
        {
            var package = _generator.CreateCarePackage(PackageType.NursingCare);

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
            var package = _generator.CreateCarePackage(PackageType.NursingCare);

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
            var package = _generator.CreateCarePackage(PackageType.NursingCare);

            var request = FundedNursingCareCreationRequest(package.Id);

            var createdFncReclaim = await CreateFncReclaim(request);

            var updateRequest = new FundedNursingCareUpdateRequest
            {
                Id = createdFncReclaim.Content.Id,
                Cost = 300M,
                ClaimCollector = createdFncReclaim.Content.ClaimCollector,
                StartDate = createdFncReclaim.Content.StartDate
            };

            var response = await _fixture.RestClient
                .PutAsync<object>($"api/v1/care-packages/{request.CarePackageId}/reclaims/fnc", updateRequest);

            var carePackageReclaim = await _fixture.DatabaseContext.CarePackageReclaims
                .FirstAsync(c => c.CarePackageId == package.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            carePackageReclaim.Cost.Should().Be(updateRequest.Cost);
        }

        [Fact]
        public async Task ShouldBatchUpdateCareCharges()
        {
            var package = _generator.CreateCarePackage();
            5.Times(_ => _generator.CreateCarePackageReclaim(package, ReclaimType.CareCharge, ClaimCollector.Supplier));

            var request = new List<CareChargeReclaimUpdateRequest>();
            3.Times(i =>
            {
                var reclaim = package.Reclaims.ElementAt(i);

                request.Add(new CareChargeReclaimUpdateRequest
                {
                    Id = reclaim.Id,
                    Cost = reclaim.Cost + 12.34m,
                    SubType = ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks,
                    ClaimCollector = ClaimCollector.Hackney
                });
            });

            var response = await _fixture.RestClient
                .PutAsync<IEnumerable<CarePackageReclaimResponse>>(
                    $"api/v1/care-packages/{package.Id}/reclaims/care-charges/batch-update", request);

            var reclaims = _fixture.DatabaseContext.CarePackageReclaims
                .Where(r => r.CarePackageId == package.Id)
                .ToList();

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            reclaims.Count.Should().Be(5 + 3);
            reclaims
                .Where(reclaim => request.Any(requestedReclaim => requestedReclaim.Id == reclaim.Id))
                .Should().OnlyContain(r => r.Status == ReclaimStatus.Ended);
        }

        [Fact]
        public async Task ShouldReturnCareChargePackages()
        {
            var package = _generator.CreateCarePackage(PackageType.NursingCare);
            var careCharge = _generator.CreateCarePackageReclaim(package, ReclaimType.CareCharge, ClaimCollector.Supplier);
            var pageNumber = 1;
            var pageSize = 10;

            var url = new UrlFormatter()
                .SetBaseUrl($"api/v1/care-packages/{package.Id}/reclaims/care-charges/packages")
                .AddParameter("pageNumber", pageNumber)
                .AddParameter("pageSize", pageSize)
                .ToString();

            var response = await _fixture.RestClient
                .GetAsync<PagedResponse<CareChargePackagesResponse>>(url);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ShouldReturnSinglePackageCareCharge()
        {
            var package = _generator.CreateCarePackage();
            var careCharge = _generator.CreateCarePackageReclaim(package, ReclaimType.CareCharge, ClaimCollector.Supplier);

            var response = await _fixture.RestClient
                .GetAsync<SinglePackageCareChargeResponse>($"api/v1/care-packages/{package.Id}/reclaims/care-charges/detail");

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.ServiceUser.HackneyId.Should().Be(package.ServiceUser.HackneyId);
        }

        [Fact]
        public async Task ShouldCancelReclaim()
        {
            var package = _generator.CreateCarePackage();
            var reclaim = _generator.CreateCarePackageReclaim(package, ReclaimType.CareCharge, ClaimCollector.Supplier);

            var response = await _fixture.RestClient
                .PutAsync<CarePackageReclaimResponse>($"api/v1/care-packages/{package.Id}/reclaims/care-charges/{reclaim.Id}/cancel");

            reclaim = _fixture.DatabaseContext.CarePackageReclaims.First(r => r.Id == reclaim.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Status.Should().Be(ReclaimStatus.Cancelled);
            reclaim.Status.Should().Be(ReclaimStatus.Cancelled);
        }

        [Fact]
        public async Task ShouldEndReclaim()
        {
            var package = _generator.CreateCarePackage();
            var reclaim = _generator.CreateCarePackageReclaim(package, ReclaimType.CareCharge, ClaimCollector.Supplier);

            var response = await _fixture.RestClient
                .PutAsync<CarePackageReclaimResponse>($"api/v1/care-packages/{package.Id}/reclaims/care-charges/{reclaim.Id}/end");

            reclaim = _fixture.DatabaseContext.CarePackageReclaims.First(r => r.Id == reclaim.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Status.Should().Be(ReclaimStatus.Ended);
            reclaim.Status.Should().Be(ReclaimStatus.Ended);
        }

        private async Task<TestResponse<CarePackageReclaimResponse>> CreateFncReclaim(FundedNursingCareCreationRequest request)
        {
            var response = await _fixture.RestClient
                .PostAsync<CarePackageReclaimResponse>($"api/v1/care-packages/{request.CarePackageId}/reclaims/fnc", request);
            return response;
        }

        private async Task<TestResponse<CarePackageReclaimResponse>> CreateCareChargesReclaim(CareChargeReclaimCreationRequest request)
        {
            var response = await _fixture.RestClient
                .PostAsync<CarePackageReclaimResponse>($"api/v1/care-packages/{request.CarePackageId}/reclaims/care-charges", request);
            return response;
        }

        private static FundedNursingCareCreationRequest FundedNursingCareCreationRequest(Guid carePackageId)
        {
            var request = new FundedNursingCareCreationRequest
            {
                CarePackageId = carePackageId,
                Cost = 200M,
                ClaimCollector = (ClaimCollector) 1,
                StartDate = DateTimeOffset.Now.Date.AddDays(-1),
                EndDate = null,
                Description = "Test"
            };
            return request;
        }
    }
}
