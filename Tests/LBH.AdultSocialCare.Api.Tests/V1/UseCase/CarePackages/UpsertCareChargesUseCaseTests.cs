using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Xunit;
using UserConstants = LBH.AdultSocialCare.Data.Constants.UserConstants;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class UpsertCareChargesUseCaseTests : BaseTest
    {
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly Mock<ICarePackageGateway> _carePackageGateway;
        private readonly Mock<ICarePackageReclaimGateway> _carePackageReclaimGateway;
        private readonly IUpsertCareChargesUseCase _useCase;
        private CarePackage _defaultPackage;
        private CarePackageDetail _coreCost;
        private readonly DateTimeOffset _today = DateTimeOffset.UtcNow.Date;

        public UpsertCareChargesUseCaseTests()
        {
            _coreCost = new CarePackageDetail
            {
                Cost = 34.12m,
                Type = PackageDetailType.CoreCost,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(30)
            };

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
                Details = { _coreCost }
            };

            _dbManager = new Mock<IDatabaseManager>();
            _carePackageReclaimGateway = new Mock<ICarePackageReclaimGateway>();
            _carePackageGateway = new Mock<ICarePackageGateway>();

            _carePackageGateway
                .Setup(g => g.GetPackageAsync(_defaultPackage.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_defaultPackage);

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

        [Fact]
        public async Task ShouldNotAllowOverlapBetweenCareCharges()
        {
            _defaultPackage.Details.Clear();
            _defaultPackage.Details.Add(new CarePackageDetail
            {
                Cost = 34.12m,
                Type = PackageDetailType.CoreCost,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(300)
            });

            var careChargesCreateDomain = new CareChargesCreateDomain()
            {
                CareCharges = new List<CareChargeReclaimCreationDomain>()
                {
                    new CareChargeReclaimCreationDomain
                    {
                        CarePackageId = _defaultPackage.Id,
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
                        StartDate = _today.AddDays(5),
                        EndDate = _today.AddDays(30)
                    },
                    new CareChargeReclaimCreationDomain()
                    {
                        CarePackageId = _defaultPackage.Id,
                        Cost = 2m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks,
                        StartDate = _today.AddDays(25),
                        EndDate = _today.AddDays(300)
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

        [Fact]
        public async Task ShouldAllowUpdateCareChargesIfNoOverlap()
        {
            var provisionalCareCharge = new CarePackageReclaim
            {
                Cost = 1m,
                Type = ReclaimType.CareCharge,
                SubType = ReclaimSubType.CareChargeProvisional,
                Status = ReclaimStatus.Active,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(-1),
                Id = Guid.NewGuid(),
                CarePackageId = _defaultPackage.Id,
                ClaimCollector = ClaimCollector.Supplier
            };
            var OneTo12CareCharge = new CarePackageReclaim
            {
                Cost = 1m,
                Type = ReclaimType.CareCharge,
                SubType = ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks,
                Status = ReclaimStatus.Active,
                StartDate = _today.AddDays(0),
                EndDate = _today.AddDays(84),
                Id = Guid.NewGuid(),
                CarePackageId = _defaultPackage.Id,
                ClaimCollector = ClaimCollector.Supplier
            };
            var ThirteenPlusCareCharge = new CarePackageReclaim
            {
                Cost = 1m,
                Type = ReclaimType.CareCharge,
                SubType = ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks,
                Status = ReclaimStatus.Active,
                StartDate = _today.AddDays(85),
                EndDate = _today.AddDays(200),
                Id = Guid.NewGuid(),
                CarePackageId = _defaultPackage.Id,
                ClaimCollector = ClaimCollector.Supplier
            };

            _defaultPackage.Details.Clear();
            _defaultPackage.Details.Add(new CarePackageDetail
            {
                Cost = 34.12m,
                Type = PackageDetailType.CoreCost,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(300)
            });

            _defaultPackage.Reclaims.Add(provisionalCareCharge);
            _defaultPackage.Reclaims.Add(OneTo12CareCharge);
            _defaultPackage.Reclaims.Add(ThirteenPlusCareCharge);

            var careChargesUpdateDomain = new CareChargesCreateDomain()
            {
                CareCharges = new List<CareChargeReclaimCreationDomain>()
                {
                    new CareChargeReclaimCreationDomain
                    {
                        CarePackageId = _defaultPackage.Id,
                        Id = provisionalCareCharge.Id,
                        Cost = 1m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeProvisional,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(0),
                        Status = ReclaimStatus.Active,
                        ClaimCollector = ClaimCollector.Hackney
                    },
                    new CareChargeReclaimCreationDomain()
                    {
                        CarePackageId = _defaultPackage.Id,
                        Id = OneTo12CareCharge.Id,
                        Cost = 2m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks,
                        StartDate = _today.AddDays(1),
                        EndDate = _today.AddDays(85),
                        Status = ReclaimStatus.Pending,
                        ClaimCollector = ClaimCollector.Hackney
                    },
                    new CareChargeReclaimCreationDomain()
                    {
                        CarePackageId = _defaultPackage.Id,
                        Id = ThirteenPlusCareCharge.Id,
                        Cost = 2m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks,
                        StartDate = _today.AddDays(86),
                        EndDate = _today.AddDays(300),
                        Status = ReclaimStatus.Pending,
                        ClaimCollector = ClaimCollector.Hackney
                    }
                }
            };

            await _useCase.ExecuteAsync(_defaultPackage.Id, careChargesUpdateDomain);

            _defaultPackage.Reclaims.Count.Should().Be(3);
            foreach (var reclaim in _defaultPackage.Reclaims)
            {
                reclaim.ClaimCollector.Should().Be(ClaimCollector.Hackney);
            }
            _defaultPackage.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeProvisional).Status.Should().Be(ReclaimStatus.Active);
            _defaultPackage.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks).Status.Should().Be(ReclaimStatus.Pending);
            _defaultPackage.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks).Status.Should().Be(ReclaimStatus.Pending);

            _defaultPackage.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeProvisional).Cost.Should().Be(1m);
            _defaultPackage.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks).Cost.Should().Be(2m);
            _defaultPackage.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks).Cost.Should().Be(2m);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldFailIfGapBetweenProvisionalAndCareChargeWithoutPropertyOneToTwelveWeeks()
        {
            _defaultPackage.Details.Clear();
            _defaultPackage.Details.Add(new CarePackageDetail
            {
                Cost = 34.12m,
                Type = PackageDetailType.CoreCost,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(300)
            });

            var provisionalCareCharge = new CarePackageReclaim
            {
                Cost = 1m,
                Type = ReclaimType.CareCharge,
                SubType = ReclaimSubType.CareChargeProvisional,
                Status = ReclaimStatus.Active,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(300)
            };
            _defaultPackage.Reclaims.Add(provisionalCareCharge);

            var careChargesUpdateDomain = new CareChargesCreateDomain()
            {
                CareCharges = new List<CareChargeReclaimCreationDomain>()
                {
                    new CareChargeReclaimCreationDomain
                    {
                        CarePackageId = _defaultPackage.Id,
                        Id = provisionalCareCharge.Id,
                        Cost = 1m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeProvisional,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(-1),
                        Status = ReclaimStatus.Active,
                        ClaimCollector = ClaimCollector.Hackney
                    },
                    new CareChargeReclaimCreationDomain()
                    {
                        CarePackageId = _defaultPackage.Id,
                        Id = Guid.NewGuid(),
                        Cost = 2m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks,
                        StartDate = _today.AddDays(1),
                        EndDate = _today.AddDays(85),
                        Status = ReclaimStatus.Pending,
                        ClaimCollector = ClaimCollector.Hackney
                    }
                }
            };

            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _useCase.ExecuteAsync(_defaultPackage.Id, careChargesUpdateDomain);
            });

            exception.StatusCode.Should().Be(400);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task ShouldSetCancelledProvisionalIfCareChargeWithoutPropertyOneToTwelveWeeksOverlap()
        {
            _defaultPackage.Details.Clear();
            _defaultPackage.Details.Add(new CarePackageDetail
            {
                Cost = 34.12m,
                Type = PackageDetailType.CoreCost,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(300)
            });

            var provisionalCareCharge = new CarePackageReclaim
            {
                Cost = 1m,
                Type = ReclaimType.CareCharge,
                SubType = ReclaimSubType.CareChargeProvisional,
                Status = ReclaimStatus.Active,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(300)
            };
            _defaultPackage.Reclaims.Add(provisionalCareCharge);

            var careChargesUpdateDomain = new CareChargesCreateDomain()
            {
                CareCharges = new List<CareChargeReclaimCreationDomain>()
                {
                    new CareChargeReclaimCreationDomain
                    {
                        CarePackageId = _defaultPackage.Id,
                        Id = provisionalCareCharge.Id,
                        Cost = 1m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeProvisional,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(-1),
                        Status = ReclaimStatus.Active,
                        ClaimCollector = ClaimCollector.Hackney
                    },
                    new CareChargeReclaimCreationDomain()
                    {
                        CarePackageId = _defaultPackage.Id,
                        Cost = 2m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(54),
                        Status = ReclaimStatus.Pending,
                        ClaimCollector = ClaimCollector.Hackney
                    }
                }
            };

            await _useCase.ExecuteAsync(_defaultPackage.Id, careChargesUpdateDomain);

            _defaultPackage.Reclaims.Count.Should().Be(2);
            _defaultPackage.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeProvisional).Should().NotBeNull();
            _defaultPackage.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeProvisional).Status.Should().Be(ReclaimStatus.Cancelled);
            _defaultPackage.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeProvisional).EndDate.Should().Be(_today.AddDays(300));
            _defaultPackage.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks).Status.Should().Be(ReclaimStatus.Active);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(0, true)]
        [InlineData(-10, true)]
        [InlineData(-1, false)]
        public void ShouldValidateOverlappingProvisionalAnd13PlusChargesForMigratedPackage(int daysDelta, bool shouldFail)
        {
            _defaultPackage.CreatorId = UserConstants.MigrationUserId;
            _coreCost.EndDate = _today.AddDays(365);

            AddCareCharge(
                ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks,
                _coreCost.EndDate.GetValueOrDefault().AddDays(-100),
                _coreCost.EndDate);

            var request = CreateUpsertRequest();
            AddRequestedCareCharge(request,
                ReclaimSubType.CareChargeProvisional,
                _coreCost.StartDate,
                _defaultPackage.Reclaims
                    .First(r => r.SubType is ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks)
                    .StartDate.AddDays(daysDelta));

            var invocation = _useCase.Invoking(async useCase => await useCase.ExecuteAsync(_defaultPackage.Id, request));

            if (shouldFail)
            {
                invocation.Should().Throw<ApiException>();
            }
            else
            {
                invocation.Should().NotThrow();
            }
        }

        private void AddRequestedCareCharge(CareChargesCreateDomain request, ReclaimSubType subType, DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            request.CareCharges.Add(new CareChargeReclaimCreationDomain
            {
                CarePackageId = _defaultPackage.Id,
                Cost = 1m,
                Type = ReclaimType.CareCharge,
                SubType = subType,
                StartDate = startDate,
                EndDate = endDate,
                Status = ReclaimStatus.Active,
                ClaimCollector = ClaimCollector.Supplier
            });
        }

        private void AddCareCharge(ReclaimSubType subType, DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            _defaultPackage.Reclaims.Add(new CarePackageReclaim
            {
                Id = Guid.NewGuid(),
                CarePackageId = _defaultPackage.Id,
                Type = ReclaimType.CareCharge,
                SubType = subType,
                Status = ReclaimStatus.Active,
                ClaimCollector = ClaimCollector.Supplier,
                StartDate = startDate,
                EndDate = endDate
            });
        }

        private CareChargesCreateDomain CreateUpsertRequest()
        {
            var request = new CareChargesCreateDomain { CareCharges = new List<CareChargeReclaimCreationDomain>() };

            // TODO: VK: Reorganize and unify reclaim creation entities, use mapper
            foreach (var reclaim in _defaultPackage.Reclaims)
            {
                request.CareCharges.Add(
                    new CareChargeReclaimCreationDomain
                    {
                        CarePackageId = reclaim.CarePackageId,
                        Id = reclaim.Id,
                        Type = reclaim.Type,
                        SubType = reclaim.SubType.GetValueOrDefault(),
                        Status = reclaim.Status,
                        Cost = reclaim.Cost,
                        Description = reclaim.Description,
                        ClaimCollector = reclaim.ClaimCollector,
                        ClaimReason = reclaim.ClaimReason,
                        StartDate = reclaim.StartDate,
                        EndDate = reclaim.EndDate
                    });
            }

            return request;
        }
    }
}
