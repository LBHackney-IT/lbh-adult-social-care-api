using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
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
        public DbSet<DayCarePackageStatus> DayCarePackageStatuses { get; set; }
        public DbSet<DayCareApprovalHistory> DayCareApprovalHistory { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TimeSlotShifts> TimeSlotShifts { get; set; }
        public DbSet<HomeCarePackage> HomeCarePackage { get; set; }
        public DbSet<HomeCareServiceType> HomeCareServiceTypes { get; set; }
        public DbSet<HomeCareServiceTypeMinutes> HomeCareServiceTypeMinutes { get; set; }
        public DbSet<HomeCarePackageSlots> HomeCarePackageSlots { get; set; }
        public DbSet<User> Users { get; set; }
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
        public DbSet<HomeCareStage> HomeCareStages { get; set; }
        public DbSet<CarerType> CarerTypes { get; set; }
        public DbSet<HomeCareApprovalHistory> HomeCareApprovalHistories { get; set; }

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

            // Seed role types
            modelBuilder.ApplyConfiguration(new RoleTypesSeed());

            // Seed Type Of Nursing Care Home
            modelBuilder.ApplyConfiguration(new TypeOfNursingCareHomeSeed());

            // Seed Type Of Residential Care Home
            modelBuilder.ApplyConfiguration(new TypeOfResidentialCareHomeSeed());

            // Seed User
            modelBuilder.ApplyConfiguration(new UserSeed());

            // Seed Client
            modelBuilder.ApplyConfiguration(new ClientSeed());

            // Seed NursingCareTypeOfStayOptionSeed
            modelBuilder.ApplyConfiguration(new NursingCareTypeOfStayOptionSeed());

            // Seed ResidentialCareTypeOfStayOptionSeed
            modelBuilder.ApplyConfiguration(new ResidentialCareTypeOfStayOptionSeed());

            // Seed Supplier
            modelBuilder.ApplyConfiguration(new SupplierSeed());

            // Seed HomeCareStage
            modelBuilder.ApplyConfiguration(new HomeCareStageSeed());

            // Seed CarerType
            modelBuilder.ApplyConfiguration(new CarerTypeSeed());

            // Seed day care package status
            modelBuilder.ApplyConfiguration(new DayCarePackageStatusSeed());

            #endregion

            #region Entity Config

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
            });

            modelBuilder.Entity<NursingCarePackage>(entity =>
            {
                entity.HasOne(n => n.Status)
                    .WithMany()
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);
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
                    .WithMany()
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);

                entity.HasOne(r => r.PackageStatus)
                    .WithMany()
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<DayCarePackageStatus>(entity =>
            {
                entity.HasIndex(e => new {e.SequenceNumber, e.Stage, e.PackageAction})
                    .IsUnique();
            });

            #endregion
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
