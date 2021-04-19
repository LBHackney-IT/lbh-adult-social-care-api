using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure
{

    public class DatabaseContext : DbContext
    {

        // TODO: rename DatabaseContext to reflect the data source it is representing. eg. MosaicContext.
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<DayCarePackage> DayCarePackages { get; set; }
        public DbSet<DayCarePackageOpportunity> DayCarePackageOpportunities { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<TimeSlotShifts> TimeSlotShifts { get; set; }
        public DbSet<HomeCarePackage> HomeCarePackage { get; set; }
        public DbSet<HomeCareServiceType> HomeCareServiceTypes { get; set; }
        public DbSet<HomeCareServiceTypeMinutes> HomeCareServiceTypeMinutes { get; set; }
        public DbSet<HomeCarePackageSlots> HomeCarePackageSlots { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<PackageStatus> Status { get; set; }
        public DbSet<TermTimeConsiderationOption> TermTimeConsiderationOptions { get; set; }
        public DbSet<ResidentialCarePackage> ResidentialCarePackage { get; set; }
        public DbSet<NursingCarePackage> NursingCarePackage { get; set; }
        public DbSet<OpportunityLengthOption> OpportunityLengthOptions { get; set; }
        public DbSet<OpportunityTimesPerMonthOption> OpportunityTimesPerMonthOptions { get; set; }
        public DbSet<NursingCareAdditionalNeeds> NursingCareAdditionalNeeds { get; set; }
        public DbSet<ResidentialCareAdditionalNeeds> ResidentialCareAdditionalNeeds { get; set; }
        public DbSet<HomeCarePackageCost> HomeCarePackageCosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Home care
            modelBuilder.Entity<HomeCareServiceType>().HasMany(item => item.Minutes);

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

            // Seed package status types
            modelBuilder.ApplyConfiguration(new PackageStatusSeed());

            // Seed package types
            modelBuilder.ApplyConfiguration(new PackageTypesSeed());

            // Seed role types
            modelBuilder.ApplyConfiguration(new RoleTypesSeed());
        }

        public override int SaveChanges()
        {
            SetEntitiesUpdatedOnSave();

            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetEntitiesUpdatedOnSave();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            SetEntitiesUpdatedOnSave();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            SetEntitiesUpdatedOnSave();

            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        private void SetEntitiesUpdatedOnSave()
        {
            IList<EntityEntry> entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && e.State == EntityState.Modified)
                .ToList();

            Type baseEntityType = typeof(BaseEntity);

            IList<Type> entityTypes = entries.Select(item => item.GetType())
                .Distinct()
                .Where(item => baseEntityType.IsAssignableFrom(item))
                .ToList();

            IList<EntityEntry> entitiesToUpdate = entries.Where(item => entityTypes.Contains(item.GetType())).ToList();

            foreach (EntityEntry entityEntry in entitiesToUpdate)
            {
                ((BaseEntity) entityEntry.Entity).DateUpdated = DateTimeOffset.UtcNow;
            }
        }

    }

}
