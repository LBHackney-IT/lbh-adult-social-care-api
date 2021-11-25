using FluentAssertions;
using HttpServices.Helpers;
using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.Tests.V1.DataGenerators;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.CarePackages
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
            var packageDetails = _generator.CreateCarePackageDetails(package, 1, PackageDetailType.CoreCost);

            var request = FundedNursingCareCreationRequest(package.Id);

            var response = await CreateFncReclaim(request);

            var carePackageReclaim = await _fixture.DatabaseContext.CarePackageReclaims
                .FirstOrDefaultAsync(c => c.CarePackageId == package.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            carePackageReclaim.Should().BeEquivalentTo(request, opt => opt
                .Excluding(reclaim => reclaim.EndDate)
                .Excluding(reclaim => reclaim.AssessmentFile));
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
            _generator.CreateCarePackageDetails(package, 1, PackageDetailType.CoreCost);

            var request = FundedNursingCareCreationRequest(package.Id);

            await CreateFncReclaim(request);

            var response = await _fixture.RestClient
                .GetAsync<CarePackageReclaimResponse>($"api/v1/care-packages/{request.CarePackageId}/reclaims/fnc");

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            response.Content.Should().BeEquivalentTo(request, opt => opt
                .Excluding(reclaim => reclaim.EndDate)
                .Excluding(reclaim => reclaim.AssessmentFile));
        }

        [Fact]
        public async Task ShouldUpdateFundedNursingCareReclaim()
        {
            var package = _generator.CreateCarePackage(PackageType.NursingCare);
            _generator.CreateCarePackageDetails(package, 1, PackageDetailType.CoreCost);

            var request = FundedNursingCareCreationRequest(package.Id);

            var createdFncReclaim = await CreateFncReclaim(request);

            var updateRequest = new FundedNursingCareUpdateRequest
            {
                Id = createdFncReclaim.Content.Id,
                Cost = 300M,
                ClaimCollector = createdFncReclaim.Content.ClaimCollector,
                StartDate = createdFncReclaim.Content.StartDate,
                EndDate = createdFncReclaim.Content.EndDate,
                Description = "test",
                AssessmentFile = null,
            };

            var response = await _fixture.RestClient
                .UpdateFormAsync<object>($"api/v1/care-packages/{request.CarePackageId}/reclaims/fnc", updateRequest);

            var carePackageReclaim = await _fixture.DatabaseContext.CarePackageReclaims
                .FirstAsync(c => c.CarePackageId == package.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            carePackageReclaim.Cost.Should().Be(updateRequest.Cost);
        }

        [Fact]
        public async Task ShouldCreateNewCareCharge()
        {
            var package = _generator.CreateCarePackage();
            _generator.CreateCarePackageDetails(package, 1, PackageDetailType.CoreCost);

            var request = new CareChargeReclaimCreationRequest
            {
                Cost = 12.34m,
                ClaimCollector = ClaimCollector.Hackney,
                SubType = ReclaimSubType.CareChargeProvisional,
                CarePackageId = package.Id,
                AssessmentFile = null,
                StartDate = DateTimeOffset.Now.AddDays(-1),
                EndDate = DateTimeOffset.Now.AddDays(2),
                Description = "test",
                ClaimReason = "test"
            };

            var response = await _fixture.RestClient
                .SubmitFormAsync<object>($"api/v1/care-packages/{request.CarePackageId}/reclaims/care-charges", request);

            var reclaims = _fixture.DatabaseContext.CarePackageReclaims
                .Where(r => r.CarePackageId == package.Id).ToList();

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            reclaims.Count.Should().Be(1);
            reclaims.Should().ContainSingle(r => r.Cost == request.Cost);
        }

        [Fact]
        public async Task ShouldUpdateExistingProvisionalCareCharge()
        {
            var package = _generator.CreateCarePackage();
            _generator.CreateCarePackageDetails(package, 1, PackageDetailType.CoreCost);

            var provisionalCharge = _generator
                .CreateCarePackageReclaim(package, ClaimCollector.Supplier, ReclaimType.CareCharge, ReclaimSubType.CareChargeProvisional);

            var request = new CareChargeReclaimCreationRequest
            {
                Cost = provisionalCharge.Cost + 12.34m,
                ClaimCollector = ClaimCollector.Supplier,
                SubType = ReclaimSubType.CareChargeProvisional,
                CarePackageId = package.Id,
                StartDate = DateTimeOffset.Now.AddDays(-1),
                EndDate = DateTimeOffset.Now.AddDays(2),
                Description = "test",
                ClaimReason = "test",
                AssessmentFile = null
            };

            var response = await _fixture.RestClient
                .SubmitFormAsync<CarePackageReclaimResponse>($"api/v1/care-packages/{request.CarePackageId}/reclaims/care-charges", request);

            var reclaims = _fixture.DatabaseContext.CarePackageReclaims
                .Where(r => r.CarePackageId == package.Id).ToList();

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            reclaims.Count.Should().Be(1);
            reclaims.Should().ContainSingle(r => r.Cost == request.Cost);
        }

        [Fact(Skip = "For unblock FE")]
        public async Task ShouldUpdateCareCharges()
        {
            var package = _generator.CreateCarePackage();
            5.Times(_ => _generator.CreateCarePackageReclaim(package, ClaimCollector.Supplier, ReclaimType.CareCharge));

            var request = new CareChargeReclaimBulkUpdateRequest()
            {
                FileRequest = new CareChargeReclaimFileRequest()
                {
                    AssessmentFile = null,
                    AssessmentFileId = Guid.NewGuid()
                },
                Reclaims = new List<CareChargeReclaimUpdateRequest>()
            };

            var careChargeRequest = new List<CareChargeReclaimUpdateRequest>();
            3.Times(i =>
            {
                var reclaim = package.Reclaims.ElementAt(i);

                careChargeRequest.Add(new CareChargeReclaimUpdateRequest
                {
                    Id = reclaim.Id,
                    Cost = reclaim.Cost + 12.34m,
                    ClaimCollector = ClaimCollector.Hackney
                });
            });

            request.Reclaims.AddRange(careChargeRequest);

            var response = await _fixture.RestClient
                .UpdateFormAsync<IEnumerable<CarePackageReclaimResponse>>(
                    $"api/v1/care-packages/{package.Id}/reclaims/care-charges", request);

            var reclaims = _fixture.DatabaseContext.CarePackageReclaims
                .Where(r => r.CarePackageId == package.Id)
                .ToList();

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            reclaims.Count.Should().Be(5 + 3);
            reclaims
                .Where(reclaim => request.Reclaims.Any(requestedReclaim => requestedReclaim.Id == reclaim.Id))
                .Should().OnlyContain(r => r.Status == ReclaimStatus.Ended);
        }

        [Fact]
        public async Task ShouldReturnCareChargePackages()
        {
            var package = _generator.CreateCarePackage(PackageType.NursingCare);
            var careCharge = _generator.CreateCarePackageReclaim(package, ClaimCollector.Supplier, ReclaimType.CareCharge);
            var pageNumber = 1;
            var pageSize = 10;

            var url = new UrlFormatter()
                .SetBaseUrl($"api/v1/care-charges")
                .AddParameter("pageNumber", pageNumber)
                .AddParameter("pageSize", pageSize)
                .ToString();

            var response = await _fixture.RestClient
                .GetAsync<PagedResponse<CareChargePackagesResponse>>(url);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ShouldReturnCarePackageCharges()
        {
            var package = _generator.CreateCarePackage();
            5.Times(_ => _generator.CreateCarePackageReclaim(package, ClaimCollector.Supplier, ReclaimType.CareCharge));

            var response = await _fixture.RestClient
                .GetAsync<IEnumerable<CarePackageReclaimResponse>>($"api/v1/care-packages/{package.Id}/reclaims/care-charges");

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Count().Should().Be(5);
        }

        [Fact]
        public async Task ShouldReturnCarePackageChargesOfGivenType()
        {
            var package = _generator.CreateCarePackage();

            3.Times(_ => _generator.CreateCarePackageReclaim(package, ClaimCollector.Supplier, ReclaimType.CareCharge));
            2.Times(_ => _generator.CreateCarePackageReclaim(package, ClaimCollector.Supplier, ReclaimType.CareCharge, ReclaimSubType.CareChargeProvisional));

            var response = await _fixture.RestClient
                .GetAsync<IEnumerable<CarePackageReclaimResponse>>($"api/v1/care-packages/{package.Id}/reclaims/care-charges?subType={ReclaimSubType.CareChargeProvisional}");

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Count().Should().Be(2);
            response.Content.Should().OnlyContain(r => r.SubType == ReclaimSubType.CareChargeProvisional);
        }

        [Fact]
        public async Task ShouldReturnSinglePackageCareCharge()
        {
            var package = _generator.CreateCarePackage();
            var careCharge = _generator.CreateCarePackageReclaim(package, ClaimCollector.Supplier, ReclaimType.CareCharge);

            var response = await _fixture.RestClient
                .GetAsync<SinglePackageCareChargeResponse>($"api/v1/care-packages/{package.Id}/reclaims/care-charges/detail");

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.ServiceUser.HackneyId.Should().Be(package.ServiceUser.HackneyId);
        }

        [Fact]
        public async Task ShouldCancelReclaim()
        {
            var package = _generator.CreateCarePackage();
            var reclaim = _generator.CreateCarePackageReclaim(package, ClaimCollector.Supplier, ReclaimType.CareCharge);

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
            var reclaim = _generator.CreateCarePackageReclaim(package, ClaimCollector.Supplier, ReclaimType.CareCharge);

            var endDate = DateTimeOffset.Now;

            var response = await _fixture.RestClient
                .PutAsync<CarePackageReclaimResponse>(
                    $"api/v1/care-packages/{package.Id}/reclaims/care-charges/{reclaim.Id}/end",
                    new CarePackageReclaimEndRequest { EndDate = endDate });

            reclaim = _fixture.DatabaseContext.CarePackageReclaims.First(r => r.Id == reclaim.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Status.Should().Be(ReclaimStatus.Ended);

            reclaim.Status.Should().Be(ReclaimStatus.Ended);
            reclaim.EndDate.Should().Be(endDate.Date);
        }

        private async Task<TestResponse<CarePackageReclaimResponse>> CreateFncReclaim(FundedNursingCareCreationRequest request)
        {
            var response = await _fixture.RestClient
                .SubmitFormAsync<CarePackageReclaimResponse>($"api/v1/care-packages/{request.CarePackageId}/reclaims/fnc", request);
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
                EndDate = DateTimeOffset.Now.Date.AddDays(2),
                Description = "Test",
                AssessmentFile = null
            };
            return request;
        }
    }
}
