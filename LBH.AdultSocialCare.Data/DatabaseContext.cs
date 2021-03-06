using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Data.SeedConfiguration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Data
{
    public class DatabaseContext : IdentityDbContext<
        User, // TUser
        Role, // TRole
        Guid, // TKey
        IdentityUserClaim<Guid>, // TUserClaim
        AppUserRole, // TUserRole,
        IdentityUserLogin<Guid>, // TUserLogin
        IdentityRoleClaim<Guid>, // TRoleClaim
        IdentityUserToken<Guid>> // TUserToken>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        // TODO: rename DatabaseContext to reflect the data source it is representing. eg. MosaicContext.
        public DatabaseContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DatabaseContext()
        {
        }

        public DbSet<CarePackage> CarePackages { get; set; }
        public DbSet<CarePackageSettings> CarePackageSettings { get; set; }
        public DbSet<CarePackageResource> CarePackageResources { get; set; }

        public DbSet<CarePackageDetail> CarePackageDetails { get; set; }
        public DbSet<CarePackageReclaim> CarePackageReclaims { get; set; }
        public DbSet<CarePackageSchedulingOption> CarePackageSchedulingOptions { get; set; }

        public DbSet<ServiceUser> ServiceUsers { get; set; }
        public DbSet<PackageStatusOption> PackageStatuses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PrimarySupportReason> PrimarySupportReasons { get; set; }

        public DbSet<FundedNursingCarePrice> FundedNursingCarePrices { get; set; }
        public DbSet<ProvisionalCareChargeAmount> ProvisionalCareChargeAmounts { get; set; }

        public DbSet<CarePackageHistory> CarePackageHistories { get; set; }

        public DbSet<Payrun> Payruns { get; set; }
        public DbSet<PayrunHistory> PayrunHistories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<PayrunInvoice> PayrunInvoices { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<HeldInvoice> HeldInvoices { get; set; }

        public bool SupportsPredicates => Database.ProviderName == "Npgsql.EntityFrameworkCore.PostgreSQL";

        #region CustomFunctions

#pragma warning disable CA1801, CA1822

        public int CompareDates(DateTimeOffset? date1, DateTimeOffset? date2) => throw new InvalidOperationException("This method should be called by EF only");

#pragma warning restore CA1801, CA1822

        #endregion CustomFunctions

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Database Seeds

            // Seed package status types
            modelBuilder.ApplyConfiguration(new PackageStatusSeed());

            // Seed User
            modelBuilder.ApplyConfiguration(new UserSeed());

            // Seed Roles
            modelBuilder.ApplyConfiguration(new RolesSeed());

            // Seed User Roles
            modelBuilder.ApplyConfiguration(new UserRolesSeed());

            // Seed Supplier
            modelBuilder.ApplyConfiguration(new SupplierSeed());

            // Seed primary support reason
            modelBuilder.ApplyConfiguration(new PrimarySupportReasonSeed());

            modelBuilder.ApplyConfiguration(new FundedNursingCarePriceSeed());

            // Seed Care Charges
            modelBuilder.ApplyConfiguration(new ProvisionalCareChargeAmountSeed());

            // Seed care package lookups
            modelBuilder.ApplyConfiguration(new CarePackageSchedulingOptionsSeed());

            // Payment departments
            modelBuilder.ApplyConfiguration(new DepartmentSeed());

            #endregion Database Seeds

            #region Entity Config

            #region DB Functions

            modelBuilder
                .HasDbFunction(typeof(DatabaseContext).GetMethod(nameof(CompareDates), new[] { typeof(DateTimeOffset?), typeof(DateTimeOffset?) })!)
                .HasName("comparedates");

            #endregion DB Functions

            modelBuilder.Entity<Invoice>()
                .HasIndex(i => i.Number)
                .IsUnique();

            modelBuilder.Entity<Payrun>()
                .HasIndex(p => p.Number)
                .IsUnique();

            modelBuilder.Entity<PayrunHistory>(entity =>
            {
                entity.Property(e => e.Type).IsRequired().HasDefaultValue(PayRunHistoryType.NormalRecord);
            });

            modelBuilder.Entity<PayrunInvoice>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => new { e.PayrunId, e.InvoiceId }).IsUnique();

                entity.HasOne(pi => pi.Payrun)
                    .WithMany(p => p.PayrunInvoices)
                    .HasForeignKey(pi => pi.PayrunId);

                entity.HasOne(pi => pi.Invoice)
                    .WithMany(i => i.PayrunInvoices)
                    .HasForeignKey(pi => pi.InvoiceId);
            });

            modelBuilder.Entity<CarePackageDetail>()
                .HasMany<InvoiceItem>()
                .WithOne(i => i.CarePackageDetail)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarePackageReclaim>()
                .HasMany<InvoiceItem>()
                .WithOne(i => i.CarePackageReclaim)
                .OnDelete(DeleteBehavior.Cascade);

            //PS: Second time adding the identity config below. Resist the temptation to remove. Serves a purpose
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasMany(role => role.UserRoles).WithOne(e => e.Role).
                    HasForeignKey(userRole => userRole.RoleId).IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(user => user.UserRoles).WithOne(e => e.User).
                    HasForeignKey(userRole => userRole.UserId).IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarePackageHistory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Status).IsRequired().HasDefaultValue(HistoryStatus.PackageInformation);
            });

            #endregion Entity Config

            AddEnumConstrains(modelBuilder);
            AdjustModelForTesting(modelBuilder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetEntitiesAuditInfo();
            TryUpdateEntitiesVersion();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            SetEntitiesAuditInfo();
            TryUpdateEntitiesVersion();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
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

        private void TryUpdateEntitiesVersion()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(entry => entry.State is EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.Entity is BaseVersionedEntity versionedEntity)
                {
                    var shouldIncreaseVersion = entry.Properties.Any(prop =>
                        prop.IsModified &&
                        versionedEntity.VersionedFields.Contains(prop.Metadata.Name));

                    if (shouldIncreaseVersion)
                    {
                        versionedEntity.Version++;
                    }
                }
            }
        }

        private IEnumerable<BaseEntity> FilterTrackedEntriesByState(EntityState entityState)
        {
            return ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && e.State == entityState)
                .Select(e => (BaseEntity) e.Entity);
        }

        private static void AddEnumConstrains(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.GetProperties();

                foreach (var property in properties)
                {
                    var nullableSubType = Nullable.GetUnderlyingType(property.ClrType);
                    var propertyType = nullableSubType ?? property.ClrType;

                    if (propertyType.IsEnum)
                    {
                        var enumValues = Enum.GetValues(propertyType).Cast<int>().ToList();
                        var enumValuesString = String.Join(", ", enumValues);

                        modelBuilder
                            .Entity(entityType.ClrType)
                            .HasCheckConstraint(
                                // generate constrains like CK_CarePackages_Status CHECK ("Status" IN (1, 2, 3))
                                $"CK_{entityType.GetTableName()}_{property.GetColumnName()}",
                                $"\"{property.GetColumnName()}\" IN ({enumValuesString})");
                    }
                }
            }
        }

        private void AdjustModelForTesting(ModelBuilder modelBuilder)
        {
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                // SQLite does not have proper support for DateTimeOffset via Entity Framework Core, see the limitations
                // here: https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
                // To work around this, when the Sqlite database provider is used, all model properties of type DateTimeOffset
                // use the DateTimeOffsetToBinaryConverter
                // Based on: https://github.com/aspnet/EntityFrameworkCore/issues/10784#issuecomment-415769754
                // This only supports millisecond precision, but should be sufficient for most use cases.
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var dateTimes = entityType.ClrType.GetProperties()
                        .Where(p => p.PropertyType == typeof(DateTimeOffset) ||
                                    p.PropertyType == typeof(DateTimeOffset?));

                    foreach (var property in dateTimes)
                    {
                        modelBuilder
                            .Entity(entityType.Name)
                            .Property(property.Name)
                            .HasConversion(new DateTimeOffsetToBinaryConverter());
                    }

                    // the same for decimals
                    var decimals = entityType.ClrType.GetProperties()
                        .Where(p => p.PropertyType == typeof(Decimal) ||
                                    p.PropertyType == typeof(Decimal?));

                    foreach (var property in decimals)
                    {
                        modelBuilder
                            .Entity(entityType.Name)
                            .Property(property.Name)
                            .HasConversion(new NumberToStringConverter<Decimal>());
                    }
                }
            }
        }
    }
}
