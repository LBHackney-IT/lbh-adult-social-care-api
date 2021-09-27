using Common.Extensions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.Constants;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.E2ETests.CarePackage
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
    }
}
