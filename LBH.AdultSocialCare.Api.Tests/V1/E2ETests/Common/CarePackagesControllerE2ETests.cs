using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.Tests.V1.Constants;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.Common
{
    public class CarePackagesControllerE2ETests : IClassFixture<MockWebApplicationFactory>
    {
        private readonly MockWebApplicationFactory _fixture;

        public CarePackagesControllerE2ETests(MockWebApplicationFactory fixture)
        {
            _fixture = fixture;
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
            response.Content.Status.Should().Be((int) PackageStatus.Draft);
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
        public async Task ShouldUpdateCarePackage()
        {
            var (carePackage, carePackageSettings) =
                DatabaseDataHelper.SaveCarePackageToDatabase(_fixture.DatabaseContext, withCarePackageSettings: true);

            var updatedCarePackageSettings = new CarePackageSettings
            {
                HasRespiteCare = true,
                HasDischargePackage = true,
                IsImmediate = true,
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
            response.Content.PackageType.Should().Be((int) carePackage.PackageType);
            response.Content.Status.Should().Be(carePackage.Status);

            // Check package settings updated
            Assert.NotNull(packageSettingsEntity);
            Assert.Equal(updatedCarePackageSettings.HasRespiteCare, packageSettingsEntity.HasRespiteCare);
            Assert.Equal(updatedCarePackageSettings.HasDischargePackage, packageSettingsEntity.HasDischargePackage);
            Assert.Equal(updatedCarePackageSettings.IsImmediate, packageSettingsEntity.IsImmediate);
            Assert.Equal(updatedCarePackageSettings.IsReEnablement, packageSettingsEntity.IsReEnablement);
            Assert.Equal(updatedCarePackageSettings.IsS117Client, packageSettingsEntity.IsS117Client);
        }
    }
}