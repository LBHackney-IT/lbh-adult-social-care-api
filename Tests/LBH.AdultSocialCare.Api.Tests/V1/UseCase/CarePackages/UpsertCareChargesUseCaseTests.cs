using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class UpsertCareChargesUseCaseTests : BaseTest
    {
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly Mock<ICarePackageGateway> _carePackageGateway;
        private readonly Mock<ICarePackageReclaimGateway> _carePackageReclaimGateway;
        private readonly IUpsertCareChargesUseCase _useCase;
        private CarePackage _defaultPackage;
        private readonly DateTimeOffset _today = DateTimeOffset.Now.Date;

        public UpsertCareChargesUseCaseTests()
        {
            _defaultPackage = new CarePackage
            {
                Id = Guid.NewGuid(),
                PackageType = PackageType.ResidentialCare,
                Settings = new CarePackageSettings
                {
                    Id = Guid.NewGuid(),
                    HasRespiteCare = false,
                    HasDischargePackage = false,
                    HospitalAvoidance = false,
                    IsReEnablement = false,
                    IsS117Client = false,
                    IsS117ClientConfirmed = false,
                },
                Details =
                {
                    new CarePackageDetail
                    {
                        Cost = 34.12m,
                        Type = PackageDetailType.CoreCost,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(30)
                    }
                }
            };

            _dbManager = new Mock<IDatabaseManager>();

            _carePackageGateway = new Mock<ICarePackageGateway>();
            _carePackageReclaimGateway = new Mock<ICarePackageReclaimGateway>();
            _useCase = new UpsertCareChargesUseCase(_carePackageGateway.Object, _dbManager.Object, Mapper, _carePackageReclaimGateway.Object);
        }


        [Fact]
        public async Task ShouldKeepActiveProvisionalIfCareChargeWithoutPropertyOneToTwelveWeeksStartDateAheadInActualDate()
        {
            var provisionalReclaim = new CarePackageReclaim
            {
                Id = Guid.NewGuid(),
                CarePackageId = _defaultPackage.Id,
                Cost = 1m,
                Type = ReclaimType.CareCharge,
                SubType = ReclaimSubType.CareChargeProvisional,
                Status = ReclaimStatus.Active,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(20)
            };
            _defaultPackage.Reclaims.Add(provisionalReclaim);
            _carePackageGateway
               .Setup(g => g.GetPackageAsync(_defaultPackage.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
               .ReturnsAsync(_defaultPackage);

            var careChargesCreateDomain = new CareChargesCreateDomain()
            {
                CareCharges = new List<CareChargeReclaimCreationDomain>()
                {
                    new CareChargeReclaimCreationDomain
                    {
                        CarePackageId = _defaultPackage.Id,
                        Id = provisionalReclaim.Id,
                        Cost = 1m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeProvisional,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(5)
                    },
                    new CareChargeReclaimCreationDomain()
                    {
                        CarePackageId = _defaultPackage.Id,
                        Cost = 2m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks,
                        StartDate = _today.AddDays(6),
                        EndDate = _today.AddDays(30)
                    }
                }
            };

            await _useCase.ExecuteAsync(_defaultPackage.Id, careChargesCreateDomain);

            _defaultPackage.Reclaims.Count.Should().Be(2);
            _defaultPackage.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeProvisional).Should().NotBeNull();
            _defaultPackage.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeProvisional).Status.Should().Be(ReclaimStatus.Active);
            _defaultPackage.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeProvisional).EndDate.Should().Be(_today.AddDays(5));
            _defaultPackage.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks).StartDate.Should().Be(_today.AddDays(6));
            _defaultPackage.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks).EndDate.Should().Be(_today.AddDays(30));

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldNotAllowAddingCareChargeWithoutPropertyOneToTwelveWeeksIfDaterangeIsMoreThan12Weeks()
        {
            _defaultPackage.Details.Clear();
            _defaultPackage.Details.Add(new CarePackageDetail
            {
                Cost = 34.12m,
                Type = PackageDetailType.CoreCost,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(300)
            });
            _carePackageGateway
               .Setup(g => g.GetPackageAsync(_defaultPackage.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
               .ReturnsAsync(_defaultPackage);

            var careChargesCreateDomain = new CareChargesCreateDomain()
            {
                CareCharges = new List<CareChargeReclaimCreationDomain>()
                {
                    new CareChargeReclaimCreationDomain
                    {
                        CarePackageId = _defaultPackage.Id,
                        Cost = 2m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(90)
                    }
                }
            };

            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _useCase.ExecuteAsync(_defaultPackage.Id, careChargesCreateDomain);
            });

            exception.StatusCode.Should().Be(400);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Never);
        }
    }
}
