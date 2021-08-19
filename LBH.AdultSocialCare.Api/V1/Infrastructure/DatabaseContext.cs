using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCarePackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCarePackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCarePackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.PackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCarePackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Extensions;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure
{
    public class DatabaseContext : IdentityDbContext<User, Role, Guid>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        // TODO: rename DatabaseContext to reflect the data source it is representing. eg. MosaicContext.
        public DatabaseContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<DayCarePackage> DayCarePackages { get; set; }
        public DbSet<EscortPackage> EscortPackages { get; set; }
        public DbSet<TransportPackage> TransportPackages { get; set; }
        public DbSet<TransportEscortPackage> TransportEscortPackages { get; set; }
        public DbSet<DayCareBrokerageInfo> DayCareBrokerageInfo { get; set; }
        public DbSet<DayCarePackageOpportunity> DayCarePackageOpportunities { get; set; }
        public DbSet<DayCarePackageStatus> DayCarePackageStatuses { get; set; }
        public DbSet<DayCareApprovalHistory> DayCareApprovalHistory { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<TimeSlotShifts> TimeSlotShifts { get; set; }
        public DbSet<HomeCarePackage> HomeCarePackage { get; set; }
        public DbSet<HomeCareServiceType> HomeCareServiceTypes { get; set; }
        public DbSet<HomeCareServiceTypeMinutes> HomeCareServiceTypeMinutes { get; set; }
        public DbSet<HomeCarePackageSlots> HomeCarePackageSlots { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<PackageStatus> PackageStatuses { get; set; }
        public DbSet<TermTimeConsiderationOption> TermTimeConsiderationOptions { get; set; }
        public DbSet<ResidentialCarePackage> ResidentialCarePackages { get; set; }
        public DbSet<NursingCarePackage> NursingCarePackages { get; set; }
        public DbSet<OpportunityLengthOption> OpportunityLengthOptions { get; set; }
        public DbSet<OpportunityTimesPerMonthOption> OpportunityTimesPerMonthOptions { get; set; }
        public DbSet<NursingCareAdditionalNeed> NursingCareAdditionalNeeds { get; set; }
        public DbSet<ResidentialCareAdditionalNeed> ResidentialCareAdditionalNeeds { get; set; }
        public DbSet<HomeCarePackageCost> HomeCarePackageCosts { get; set; }
        public DbSet<TypeOfNursingCareHome> TypesOfNursingCareHomes { get; set; }
        public DbSet<TypeOfResidentialCareHome> TypesOfResidentialCareHomes { get; set; }
        public DbSet<NursingCareTypeOfStayOption> NursingCareTypeOfStayOptions { get; set; }
        public DbSet<ResidentialCareTypeOfStayOption> ResidentialCareTypeOfStayOptions { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<HomeCareSupplierCost> HomeCareSupplierCosts { get; set; }
        public DbSet<Stage> HomeCareStages { get; set; }
        public DbSet<CarerType> CarerTypes { get; set; }
        public DbSet<HomeCareApprovalHistory> HomeCareApprovalHistories { get; set; }
        public DbSet<NursingCareApprovalHistory> NursingCareApprovalHistories { get; set; }
        public DbSet<ResidentialCareApprovalHistory> ResidentialCareApprovalHistories { get; set; }
        public DbSet<HomeCareRequestMoreInformation> HomeCareRequestMoreInformations { get; set; }
        public DbSet<DayCareRequestMoreInformation> DayCareRequestMoreInformations { get; set; }
        public DbSet<ResidentialCareRequestMoreInformation> ResidentialCareRequestMoreInformations { get; set; }
        public DbSet<NursingCareRequestMoreInformation> NursingCareRequestMoreInformations { get; set; }
        public DbSet<DayCareCollege> DayCareColleges { get; set; }
        public DbSet<HomeCarePackageReclaim> HomeCarePackageReclaims { get; set; }
        public DbSet<ReclaimAmountOption> ReclaimAmountOptions { get; set; }
        public DbSet<ReclaimCategory> ReclaimCategories { get; set; }
        public DbSet<ReclaimFrom> ReclaimFroms { get; set; }
        public DbSet<DayCarePackageReclaim> DayCarePackageReclaims { get; set; }
        public DbSet<NursingCarePackageReclaim> NursingCarePackageReclaims { get; set; }
        public DbSet<ResidentialCarePackageReclaim> ResidentialCarePackageReclaims { get; set; }
        public DbSet<NursingCareBrokerageInfo> NursingCareBrokerageInfos { get; set; }
        public DbSet<ResidentialCareBrokerageInfo> ResidentialCareBrokerageInfos { get; set; }
        public DbSet<PrimarySupportReason> PrimarySupportReasons { get; set; }


        #region CustomFunctions

#pragma warning disable CA1801, CA1822
        public int CompareDates(DateTimeOffset? date1, DateTimeOffset? date2) => throw new InvalidOperationException("This method should be called by EF only");
#pragma warning restore CA1801, CA1822

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Database Seeds

            // Seed term time consideration options
            modelBuilder.ApplyConfiguration(new TermTimeConsiderationOptionsSeed());

            // Seed day care how long options
            modelBuilder.ApplyConfiguration(new OpportunityLengthOptionsSeed());

            // Seed day care how many times per month options
            modelBuilder.ApplyConfiguration(new OpportunityTimesPerMonthOptionsSeed());

            // Seed home care service types
            modelBuilder.ApplyConfiguration(new HomeCareServiceTypesSeed());
            modelBuilder.ApplyConfiguration(new HomeCareServiceTypeMinutesSeed());

            // Seed home care time slot shifts
            modelBuilder.ApplyConfiguration(new TimeSlotShiftsSeed());
            // Seed package status types
            modelBuilder.ApplyConfiguration(new PackageStatusSeed());

            // Seed package types
            modelBuilder.ApplyConfiguration(new PackageTypesSeed());

            // Seed Type Of Nursing Care Home
            modelBuilder.ApplyConfiguration(new TypeOfNursingCareHomeSeed());

            // Seed Type Of Residential Care Home
            modelBuilder.ApplyConfiguration(new TypeOfResidentialCareHomeSeed());

            // Seed User
            modelBuilder.ApplyConfiguration(new UserSeed());

            // Seed Roles
            modelBuilder.ApplyConfiguration(new RolesSeed());

            // Seed User Roles
            modelBuilder.ApplyConfiguration(new UserRolesSeed());

            // Seed Client
            modelBuilder.ApplyConfiguration(new ClientSeed());

            // Seed NursingCareTypeOfStayOptionSeed
            modelBuilder.ApplyConfiguration(new NursingCareTypeOfStayOptionSeed());

            // Seed ResidentialCareTypeOfStayOptionSeed
            modelBuilder.ApplyConfiguration(new ResidentialCareTypeOfStayOptionSeed());

            // Seed Supplier
            modelBuilder.ApplyConfiguration(new SupplierSeed());

            // Seed HomeCareStage
            modelBuilder.ApplyConfiguration(new StageSeed());

            // Seed CarerType
            modelBuilder.ApplyConfiguration(new CarerTypeSeed());

            // Seed day care package status
            modelBuilder.ApplyConfiguration(new DayCarePackageStatusSeed());

            // Seed package reclaim amount option
            modelBuilder.ApplyConfiguration(new PackageReclaimAmountOptionSeed());

            // Seed package reclaim category
            modelBuilder.ApplyConfiguration(new PackageReclaimCategorySeed());

            // Seed package reclaim from
            modelBuilder.ApplyConfiguration(new PackageReclaimFromSeed());

            // Seed primary support reason
            modelBuilder.ApplyConfiguration(new PrimarySupportReasonSeed());

            #endregion Database Seeds

            #region Entity Config

            #region DB Functions

            modelBuilder
                .HasDbFunction(typeof(DatabaseContext).GetMethod(nameof(CompareDates), new[] { typeof(DateTimeOffset?), typeof(DateTimeOffset?) }))
                .HasName("comparedates");

            #endregion

            // Home care
            modelBuilder.Entity<HomeCareServiceType>().HasMany(item => item.Minutes);

            modelBuilder.Entity<OpportunityLengthOption>(entity =>
            {
                entity.HasKey(e => e.OpportunityLengthOptionId);

                entity.HasIndex(e => e.OptionName).IsUnique();
            });

            modelBuilder.Entity<TermTimeConsiderationOption>(entity =>
            {
                entity.HasIndex(e => e.OptionName).IsUnique();
            });

            modelBuilder.Entity<OpportunityTimesPerMonthOption>(entity =>
            {
                entity.HasKey(e => e.OpportunityTimePerMonthOptionId);

                entity.HasIndex(e => e.OptionName).IsUnique();
            });

            modelBuilder.Entity<DayCarePackage>(entity =>
            {
                entity.HasOne(d => d.Status)
                    .WithMany()
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);

                entity.HasOne(a => a.DayCareBrokerageInfo)
                    .WithOne(b => b.DayCarePackage)
                    .HasForeignKey<DayCareBrokerageInfo>(b => b.DayCarePackageId);
            });

            modelBuilder.Entity<NursingCarePackage>(entity =>
            {
                entity.HasOne(n => n.Status)
                    .WithMany()
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);

                entity.HasOne(a => a.NursingCareBrokerageInfo)
                    .WithOne(b => b.NursingCarePackage)
                    .HasForeignKey<NursingCareBrokerageInfo>(b => b.NursingCarePackageId);
            });

            modelBuilder.Entity<HomeCarePackage>(entity =>
            {
                entity.HasOne(h => h.Status)
                    .WithMany()
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<ResidentialCarePackage>(entity =>
            {
                entity.HasOne(r => r.Status)
                    .WithMany()
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<NursingCareAdditionalNeed>(entity =>
            {
                entity.HasOne(n => n.NursingCarePackage)
                    .WithMany(n => n.NursingCareAdditionalNeeds)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<ResidentialCareAdditionalNeed>(entity =>
            {
                entity.HasOne(r => r.ResidentialCarePackage)
                    .WithMany(r => r.ResidentialCareAdditionalNeeds)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<DayCareApprovalHistory>(entity =>
            {
                entity.HasOne(r => r.DayCarePackage)
                    .WithMany(da => da.DayCareApprovalHistories)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);

                entity.HasOne(r => r.PackageStatus)
                    .WithMany()
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<DayCarePackageStatus>(entity =>
            {
                entity.HasIndex(e => new { e.SequenceNumber, e.Stage, e.PackageAction })
                    .IsUnique();
            });

            #endregion Entity Config
        }

        public override int SaveChanges()
        {
            SetEntitiesAuditInfo();

            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetEntitiesAuditInfo();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            SetEntitiesAuditInfo();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            SetEntitiesAuditInfo();

            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        private void SetEntitiesAuditInfo()
        {
            SetEntitiesCreatedOnSave();
            SetEntitiesUpdatedOnSave();
        }

        private void SetEntitiesCreatedOnSave()
        {
            var entitiesToCreate = FilterTrackedEntriesByState(EntityState.Added);

            foreach (var entity in entitiesToCreate)
            {
                entity.DateCreated = DateTimeOffset.UtcNow;
                entity.CreatorId = new Guid(_httpContextAccessor.HttpContext.User.Identity.GetUserId());
            }
        }

        private void SetEntitiesUpdatedOnSave()
        {
            var entitiesToUpdate = FilterTrackedEntriesByState(EntityState.Modified);

            foreach (var entity in entitiesToUpdate)
            {
                entity.DateUpdated = DateTimeOffset.UtcNow;
                entity.UpdaterId = new Guid(_httpContextAccessor.HttpContext.User.Identity.GetUserId());
            }
        }

        private IEnumerable<BaseEntity> FilterTrackedEntriesByState(EntityState entityState)
        {
            return ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && e.State == entityState)
                .Select(e => (BaseEntity) e.Entity);
        }
    }
}
