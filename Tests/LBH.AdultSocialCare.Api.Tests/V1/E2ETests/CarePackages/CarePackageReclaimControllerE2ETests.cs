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
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.TestFramework.Extensions;
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
            var startDate = "01-12-2022".ToUtcDate();
            var endDate = "31-12-2022".ToUtcDate();
            var fncCost = 500M;

            var package = TestDataHelper
                .CreateCarePackage(PackageType.NursingCare)
                .AddCoreCost(fncCost * 2, startDate, endDate)
                .Save(_fixture.DatabaseContext);

            var response = await CreateFncReclaim(package.Id, fncCost, startDate, endDate);

            var reclaims = await _fixture.DatabaseContext.CarePackageReclaims
                .Where(c => c.CarePackageId == package.Id)
                .ToListAsync();

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            reclaims.Count.Should().Be(2);
            reclaims.Should().OnlyContain(r => r.Type == ReclaimType.Fnc && r.StartDate == startDate && r.EndDate == endDate);
            reclaims.Should().ContainSingle(r => r.SubType == ReclaimSubType.FncPayment && r.Cost == fncCost);
            reclaims.Should().ContainSingle(r => r.SubType == ReclaimSubType.FncReclaim && r.Cost == -fncCost);
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
            var packageDetails = _generator.CreateCarePackageDetails(package, 1, PackageDetailType.CoreCost);

            var request = FundedNursingCareCreationRequest(package.Id);
            request.Cost = packageDetails.First().Cost - 10M;
            request.StartDate = packageDetails.First().StartDate;
            request.EndDate = packageDetails.First().EndDate;

            await CreateFncReclaim(request);

            var response = await _fixture.RestClient
                .GetAsync<CarePackageReclaimResponse>($"api/v1/care-packages/{request.CarePackageId}/reclaims/fnc");

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            response.Content.Should().BeEquivalentTo(request, opt => opt
                .Excluding(reclaim => reclaim.EndDate)
                .Excluding(reclaim => reclaim.AssessmentFileId)
                .Excluding(reclaim => reclaim.AssessmentFile));
        }

        [Fact]
        public async Task ShouldUpdateFundedNursingCareReclaim()
        {
            var package = _generator.CreateCarePackage(PackageType.NursingCare);
            var packageDetails = _generator.CreateCarePackageDetails(package, 1, PackageDetailType.CoreCost);

            var request = FundedNursingCareCreationRequest(package.Id);
            request.Cost = packageDetails.First().Cost - 10M;
            request.StartDate = packageDetails.First().StartDate;
            request.EndDate = packageDetails.First().EndDate;

            var createdFncReclaim = await CreateFncReclaim(request);

            var updateRequest = new FundedNursingCareUpdateRequest
            {
                Id = createdFncReclaim.Content.Id,
                Cost = request.Cost + 2,
                ClaimCollector = createdFncReclaim.Content.ClaimCollector,
                StartDate = createdFncReclaim.Content.StartDate,
                EndDate = createdFncReclaim.Content.EndDate,
                Description = "test",
                AssessmentFileId = Guid.NewGuid(),
                HasAssessmentBeenCarried = true
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
            var package = TestDataHelper.CreateCarePackage(packageType: PackageType.ResidentialCare,
                status: PackageStatus.Approved);
            package.Settings = TestDataHelper.CreateCarePackageSettings(carePackageId: package.Id, isS117Client: false);
            package.Details.Add(TestDataHelper.CreateCarePackageDetail(package.Id, type: PackageDetailType.CoreCost, cost: 100M));

            package = _generator.CreateCarePackage(package);

            var request = new CareChargesCreationRequest()
            {
                CareCharges = new List<CareChargeReclaimCreationRequest>()
                 {
                     new CareChargeReclaimCreationRequest()
                     {
                         Cost = 12.34m,
                         ClaimCollector = ClaimCollector.Hackney,
                         SubType = ReclaimSubType.CareCharge1To12Weeks,
                         StartDate = package.Details.First().StartDate,
                         EndDate = package.Details.First().StartDate.AddDays(84),
                         Description = "test",
                         ClaimReason = "test",
                         CarePackageId = package.Id
                     }
                 }
            };

            var response = await _fixture.RestClient
                .PutAsync<object>($"api/v1/care-packages/{package.Id}/reclaims/care-charges", request);

            var reclaims = _fixture.DatabaseContext.CarePackageReclaims
                .Where(r => r.CarePackageId == package.Id).ToList();

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            reclaims.Count.Should().Be(1);
            //reclaims.Should().ContainSingle(r => r.Cost == request.Cost);
        }

        [Fact(Skip = "Refactor")]
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
                StartDate = DateTimeOffset.UtcNow.AddDays(-1),
                EndDate = DateTimeOffset.UtcNow.AddDays(2),
                Description = "test",
                ClaimReason = "test"
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
                AssessmentFile = null,
                AssessmentFileId = Guid.NewGuid(),
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

        [Fact(Skip = "SQLite seems to have problems with PredicateBuilder - to be reviewed")]
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
            var detail = _generator.CreateCarePackageDetails(package, 1, PackageDetailType.CoreCost);

            var endDate = DateTimeOffset.UtcNow;

            var response = await _fixture.RestClient
                .PutAsync<CarePackageReclaimResponse>(
                    $"api/v1/care-packages/{package.Id}/reclaims/care-charges/{reclaim.Id}/end",
                    new CarePackageReclaimEndRequest { EndDate = endDate });

            reclaim = _fixture.DatabaseContext.CarePackageReclaims.First(r => r.Id == reclaim.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Status.Should().Be(ReclaimStatus.Ended);

            reclaim.Status.Should().Be(ReclaimStatus.Ended);
            reclaim.EndDate.Value.Date.Should().Be(endDate.Date);
        }

        [Fact]
        public async Task ShouldRaiseAnErrorWhenProvisionalEndDateOutOfRangePackageDetailDate()
        {
            var package = _generator.CreateCarePackage(PackageType.NursingCare);
            var packageDetails = _generator.CreateCarePackageDetails(package, 1, PackageDetailType.CoreCost);


            var request = new CareChargeReclaimCreationRequest()
            {
                CarePackageId = package.Id,
                ClaimCollector = ClaimCollector.Supplier,
                Cost = 90M,
                SubType = ReclaimSubType.CareChargeProvisional,
                Description = null,
                ClaimReason = null
            };

            request.StartDate = packageDetails.First().StartDate.AddDays(10);
            var coreCostDetailEndDate = packageDetails.First().EndDate;
            if (coreCostDetailEndDate != null)
            {
                var provisionalCareChargeEndDate = (DateTimeOffset) coreCostDetailEndDate;
                request.EndDate = provisionalCareChargeEndDate.AddDays(+10);
            }

            var response = await _fixture.RestClient
                .PostAsync<CarePackageReclaimResponse>($"api/v1/care-packages/{request.CarePackageId}/reclaims/care-charges/provisional", request);

            response.Message.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Fact]
        public async Task ShouldCreateProvisionalCareCharge()
        {
            var package = _generator.CreateCarePackage(PackageType.NursingCare);
            var packageDetails = _generator.CreateCarePackageDetails(package, 1, PackageDetailType.CoreCost);


            var request = new CareChargeReclaimCreationRequest()
            {
                CarePackageId = package.Id,
                ClaimCollector = ClaimCollector.Supplier,
                Cost = 90M,
                SubType = ReclaimSubType.CareChargeProvisional,
                StartDate = packageDetails.First().StartDate,
                EndDate = packageDetails.First().EndDate,
                Description = null,
                ClaimReason = null
            };

            var response = await _fixture.RestClient
                .PostAsync<CarePackageReclaimResponse>($"api/v1/care-packages/{request.CarePackageId}/reclaims/care-charges/provisional", request);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        private async Task<TestResponse<CarePackageReclaimResponse>> CreateFncReclaim(
            Guid packageId, decimal? cost = null, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            var request = FundedNursingCareCreationRequest(packageId, cost, startDate, endDate);
            var response = await _fixture.RestClient
                .SubmitFormAsync<CarePackageReclaimResponse>($"api/v1/care-packages/{request.CarePackageId}/reclaims/fnc", request);

            return response;
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

        private static FundedNursingCareCreationRequest FundedNursingCareCreationRequest(
            Guid carePackageId, decimal? cost = null, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            var request = new FundedNursingCareCreationRequest
            {
                CarePackageId = carePackageId,
                Cost = cost ?? 200M,
                ClaimCollector = (ClaimCollector) 1,
                StartDate = startDate ?? DateTimeOffset.UtcNow.Date.AddDays(-1),
                EndDate = endDate ?? DateTimeOffset.UtcNow.Date.AddDays(2),
                Description = "Test",
                AssessmentFileId = Guid.NewGuid()
            };
            return request;
        }
    }
}
