using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.Constants;
using LBH.AdultSocialCare.Api.Tests.V1.DataGenerators;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HttpServices.Models.Responses;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.Common
{
    public class CarePackagesControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;
        private readonly DatabaseTestDataGenerator _generator;

        public CarePackagesControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
            _generator = _fixture.Generator;
        }

        [Fact]
        public async Task ShouldCreateCarePackage()
        {
            var carePackageCreationRequest = TestDataHelper.CarePackageCreationRequest(
                serviceUserId: Guid.Parse(UserConstants.DefaultApiUserId), packageType: PackageType.ResidentialCare);

            var response = await _fixture.RestClient
                .PostAsync<CarePackagePlainResponse>($"api/v1/care-packages", carePackageCreationRequest)
                .ConfigureAwait(false);

            var carePackages = _fixture.DatabaseContext.CarePackages.ToList();

            Assert.Equal(HttpStatusCode.OK, response.Message.StatusCode);
            Assert.Single(carePackages);
            response.Content.Id.Should().NotBe(Guid.Empty);
            response.Content.PackageType.Should().Be((int) carePackageCreationRequest.PackageType);
            response.Content.Status.Should().Be((int) PackageStatus.New);
        }

        [Fact]
        public async Task ShouldReturnPackageSchedulingOptionsList()
        {
            var response = await _fixture.RestClient
                .GetAsync<IEnumerable<CarePackageSchedulingOptionResponse>>("api/v1/care-packages/package-scheduling-options")
                .ConfigureAwait(false);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            response.Content.Count().Should().Be(Enum.GetNames(typeof(PackageScheduling)).Length);
        }

        [Fact]
        public async Task ShouldReturnPackageStatusOptionsList()
        {
            var response = await _fixture.RestClient
                .GetAsync<IEnumerable<CarePackageStatusOptionResponse>>("api/v1/care-packages/package-status-options");

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            response.Content.Count().Should().Be(Enum.GetNames(typeof(PackageStatus)).Length);
        }

        [Fact]
        public async Task ShouldUpdateCarePackage()
        {
            var carePackage = _fixture.Generator.CreateCarePackage();
            var carePackageSettings = _fixture.Generator.CreateCarePackageSettings(carePackage.Id);

            var updatedCarePackageSettings = new CarePackageSettings
            {
                HasRespiteCare = true,
                HasDischargePackage = true,
                HospitalAvoidance = true,
                IsReEnablement = true,
                IsS117Client = true
            };

            // Update some care package settings
            carePackage.PrimarySupportReasonId = 2;
            carePackage.PackageScheduling = PackageScheduling.LongTerm;

            var carePackageUpdateRequest =
                TestDataHelper.CarePackageUpdateRequest(carePackage, updatedCarePackageSettings);

            var response = await _fixture.RestClient
                .PutAsync<CarePackagePlainResponse>($"api/v1/care-packages/{carePackage.Id}", carePackageUpdateRequest)
                .ConfigureAwait(false);

            var packageSettingsEntity = _fixture.DatabaseContext.CarePackageSettings.SingleOrDefault(ps => ps.CarePackageId.Equals(carePackage.Id));

            Assert.Equal(HttpStatusCode.OK, response.Message.StatusCode);
            response.Content.Id.Should().Be(carePackage.Id);
            response.Content.PackageType.Should().Be((int) carePackageUpdateRequest.PackageType);
            response.Content.Status.Should().Be(PackageStatus.InProgress);

            // Check package settings updated
            Assert.NotNull(packageSettingsEntity);
            var newSettings = new
            {
                updatedCarePackageSettings.HasRespiteCare,
                updatedCarePackageSettings.HasDischargePackage,
                IsImmediate = updatedCarePackageSettings.HospitalAvoidance,
                updatedCarePackageSettings.IsReEnablement,
                updatedCarePackageSettings.IsS117Client
            };
            packageSettingsEntity.Should().BeEquivalentTo(newSettings, opt => opt.ExcludingMissingMembers().ExcludingNestedObjects());
        }

        [Fact]
        public async Task ShouldSubmitPackage()
        {
            var package = _fixture.Generator.CreateCarePackage(type: PackageType.NursingCare);

            var request = new CarePackageSubmissionRequest
            {
                ApproverId = UserConstants.DefaultApiUserGuid,
                Notes = "Hello world"
            };

            var response = await _fixture.RestClient
                .PostAsync<IEnumerable<CarePackageSchedulingOptionResponse>>($"api/v1/care-packages/{package.Id}/submit", request)
                .ConfigureAwait(false);

            package = _fixture.DatabaseContext.CarePackages
                .FirstOrDefault(p => p.Id == package.Id);
            var historyEntry = _fixture.DatabaseContext.CarePackageHistories
                .FirstOrDefault(h => h.CarePackageId == package.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            package?.Should().NotBeNull();
            package?.Status.Should().Be(PackageStatus.SubmittedForApproval);
            package?.ApproverId.Should().Be(request.ApproverId);

            historyEntry?.Should().NotBeNull();
            historyEntry?.Description.Should().Be(request.Notes);
            historyEntry?.Status.Should().Be(HistoryStatus.SubmittedForApproval);
        }

        [Fact]
        public async Task ShouldAssignCarePlan()
        {
            var request = new CarePlanAssignmentRequest
            {
                HackneyUserId = 1,
                BrokerId = UserConstants.DefaultApiUserGuid,
                PackageType = PackageType.ResidentialCare,
                Notes = "Hello world",
                CarePlanFile = null
            };

            _fixture.OutgoingRestClient
                .Setup(c => c.GetAsync<ServiceUserInformationResponse>($"residents?id={request.HackneyUserId}", It.IsAny<string>()))
                .ReturnsAsync(new ServiceUserInformationResponse
                {
                    Residents = new List<ResidentResponse>
                    {
                        TestDataHelper.CreateResidentResponse()
                    }
                });

            var response = await _fixture.RestClient
                .SubmitFormAsync<object>("api/v1/care-packages/assign", request);

            var serviceUser = _fixture.DatabaseContext.ServiceUsers.FirstOrDefault(u => u.HackneyId == 1);
            var package = _fixture.DatabaseContext.CarePackages.SingleOrDefault(p => p.ServiceUserId == serviceUser.Id);
            var historyItems = _fixture.DatabaseContext.CarePackageHistories.Where(h => h.CarePackageId == package.Id).ToList();

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            serviceUser.Should().NotBeNull();
            package.Should().NotBeNull();

            package.Status.Should().Be(PackageStatus.New);
            package.BrokerId.Should().Be(request.BrokerId);
            package.PackageType.Should().Be(request.PackageType);

            historyItems.Count.Should().Be(1);
            historyItems.First().Status.Should().Be(HistoryStatus.NewPackage);
            historyItems.First().Description.Should().Be(request.Notes);
        }

        [Fact]
        public async Task ShouldReturnPackage()
        {
            var package = _generator.CreateCarePackage();
            _generator.CreateCarePackageSettings(package.Id);

            var response = await _fixture.RestClient
                .GetAsync<CarePackageResponse>($"api/v1/care-packages/{package.Id}");

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            response.Content.Id.Should().Be(package.Id);
            response.Content.ServiceUser.HackneyId.Should().Be(package.ServiceUser.HackneyId);
            response.Content.PrimarySupportReasonId.Should().Be(package.PrimarySupportReasonId);
        }

        [Fact]
        public async Task ShouldReturnCorePackage()
        {
            var package = _generator.CreateCarePackage();
            var packageSettings = _generator.CreateCarePackageSettings(package.Id);

            var response = await _fixture.RestClient
                .GetAsync<CarePackageCoreResponse>($"api/v1/care-packages/{package.Id}/core");

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            response.Content.CarePackageId.Should().Be(package.Id);
            response.Content.Should().BeEquivalentTo(packageSettings, opt => opt.ExcludingMissingMembers().ExcludingNestedObjects());
        }

        [Fact]
        public async Task ShouldReturnPackageSummary()
        {
            var package = _generator.CreateCarePackage();

            _generator.CreateCarePackageReclaim(package, ReclaimType.Fnc, ClaimCollector.Hackney);
            _generator.CreateCarePackageReclaim(package, ReclaimType.CareCharge, ClaimCollector.Supplier);

            _generator.CreateCarePackageDetails(package, 1, PackageDetailType.CoreCost);
            _generator.CreateCarePackageDetails(package, 5, PackageDetailType.AdditionalNeed);

            _generator.CreateCarePackageSettings(package.Id);

            var response = await _fixture.RestClient
                .GetAsync<CarePackageSummaryResponse>($"api/v1/care-packages/{package.Id}/summary");

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ShouldApprovePackage()
        {
            var package = _generator.CreateCarePackage();

            var request = new CarePackageChangeStatusRequest
            {
                Notes = "Test"
            };

            var response = await _fixture.RestClient
                .PostAsync<CarePackagePlainResponse>($"api/v1/care-packages/{package.Id}/approve", request);

            package = _fixture.DatabaseContext.CarePackages
                .FirstOrDefault(p => p.Id == package.Id);
            var carePackageHistory = _fixture.DatabaseContext.CarePackageHistories
                .FirstOrDefault(h => h.CarePackageId == package.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            package?.Should().NotBeNull();
            package?.Status.Should().Be(PackageStatus.Approved);

            carePackageHistory?.Should().NotBeNull();
            carePackageHistory?.Description.Should().Be(request.Notes);
            carePackageHistory?.Status.Should().Be(HistoryStatus.PackageApproved);
        }

        [Fact]
        public async Task ShouldCancelPackage()
        {
            var package = _generator.CreateCarePackage();

            var request = new CarePackageChangeStatusRequest
            {
                Notes = "Test"
            };

            var response = await _fixture.RestClient
                .PostAsync<CarePackagePlainResponse>($"api/v1/care-packages/{package.Id}/cancel", request);

            package = _fixture.DatabaseContext.CarePackages
                .FirstOrDefault(p => p.Id == package.Id);
            var carePackageHistory = _fixture.DatabaseContext.CarePackageHistories
                .FirstOrDefault(h => h.CarePackageId == package.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            package?.Should().NotBeNull();
            package?.Status.Should().Be(PackageStatus.Cancelled);

            carePackageHistory?.Should().NotBeNull();
            carePackageHistory?.Description.Should().Be(request.Notes);
            carePackageHistory?.Status.Should().Be(HistoryStatus.CancelledId);
        }

        [Fact]
        public async Task ShouldEndPackage()
        {
            var package = _generator.CreateCarePackage();

            var request = new CarePackageChangeStatusRequest
            {
                Notes = "Test"
            };

            var response = await _fixture.RestClient
                .PostAsync<CarePackagePlainResponse>($"api/v1/care-packages/{package.Id}/end", request);

            package = _fixture.DatabaseContext.CarePackages
                .FirstOrDefault(p => p.Id == package.Id);
            var carePackageHistory = _fixture.DatabaseContext.CarePackageHistories
                .FirstOrDefault(h => h.CarePackageId == package.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            package?.Should().NotBeNull();
            package?.Status.Should().Be(PackageStatus.Ended);

            carePackageHistory?.Should().NotBeNull();
            carePackageHistory?.Description.Should().Be(request.Notes);
            carePackageHistory?.Status.Should().Be(HistoryStatus.BrokeredEndedId);
        }

        [Fact]
        public async Task ShouldDeclinePackage()
        {
            var package = _generator.CreateCarePackage();

            var request = new CarePackageChangeStatusRequest
            {
                Notes = "Test"
            };

            var response = await _fixture.RestClient
                .PostAsync<CarePackagePlainResponse>($"api/v1/care-packages/{package.Id}/decline", request);

            package = _fixture.DatabaseContext.CarePackages
                .FirstOrDefault(p => p.Id == package.Id);
            var carePackageHistory = _fixture.DatabaseContext.CarePackageHistories
                .FirstOrDefault(h => h.CarePackageId == package.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            package?.Should().NotBeNull();
            package?.Status.Should().Be(PackageStatus.Rejected);

            carePackageHistory?.Should().NotBeNull();
            carePackageHistory?.Description.Should().Be(request.Notes);
            carePackageHistory?.Status.Should().Be(HistoryStatus.RejectedId);
        }

        [Fact]
        public async Task ShouldConfirmS117ServiceUser()
        {
            var package = _generator.CreateCarePackage();
            var packageSettings = _generator.CreateCarePackageSettingsForS117Client(package.Id,true);

            var response = await _fixture.RestClient
                .PutAsync<CarePackagePlainResponse>($"api/v1/care-packages/{package.Id}/confirm-s117");

            package = _fixture.DatabaseContext.CarePackages
                .Include(p => p.Settings)
                .FirstOrDefault(p => p.Id == package.Id);

            response.Message.StatusCode.Should().Be(HttpStatusCode.OK);

            package?.Should().NotBeNull();
            package?.Settings.IsS117ClientConfirmed.Should().BeTrue();
        }

        [Fact]
        public async Task ShouldRaiseAnErrorWhenS117ServiceUserSettingFalse()
        {
            var package = _generator.CreateCarePackage();
            _generator.CreateCarePackageSettingsForS117Client(package.Id,false);

            var response = await _fixture.RestClient
                .PutAsync<CarePackagePlainResponse>($"api/v1/care-packages/{package.Id}/confirm-s117");

            response.Message.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }
    }
}
