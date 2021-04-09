using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure
{

    public class DatabaseContext : DbContext
    {
        //TODO: rename DatabaseContext to reflect the data source it is representing. eg. MosaicContext.
        //Guidance on the context class can be found here https://github.com/LBHackney-IT/lbh-base-api/wiki/DatabaseContext
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DayCarePackage> DayCarePackages { get; set; }
        public DbSet<DatabaseEntity> DatabaseEntities { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageServices> PackageServices { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<TimeSlotType> TimeSlotType { get; set; }
        public DbSet<TimeSlotShifts> TimeSlotShifts { get; set; }
        public DbSet<HomeCarePackage> HomeCarePackage { get; set; }
        public DbSet<HomeCarePackageSlots> HomeCarePackageSlots { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<TermTimeConsiderationOption> TermTimeConsiderationOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed database
            // Seed term time consideration options
            modelBuilder.ApplyConfiguration(new TermTimeConsiderationOptionsSeed());
        }

        public async Task<IList<Package>> GetPackagesAsync()
        => await Packages
        .ToListAsync()
        .ConfigureAwait(false);

        public async Task<IList<PackageServices>> GetServicesAsync()
        => await PackageServices
        .ToListAsync()
        .ConfigureAwait(false);

        public async Task<IList<Roles>> GetRolesAsync()
        => await Roles
        .ToListAsync()
        .ConfigureAwait(false);

        public async Task<IList<TimeSlotType>> GetTimeSlotTypesAsync()
        => await TimeSlotType
        .ToListAsync()
        .ConfigureAwait(false);

        public async Task<IList<TimeSlotShifts>> GetTimeSlotShiftsAsync()
        => await TimeSlotShifts
        .ToListAsync()
        .ConfigureAwait(false);

        public async Task<IList<HomeCarePackage>> GetHomeCarePackagesAsync()
        => await HomeCarePackage
        .ToListAsync()
        .ConfigureAwait(false);

        public async Task<IList<HomeCarePackageSlots>> GetHomeCarePackagesSlotsAsync()
        => await HomeCarePackageSlots
        .ToListAsync()
        .ConfigureAwait(false);

        public async Task<IList<Status>> GetStatusAsync()
        => await Status
        .ToListAsync()
        .ConfigureAwait(false);
    }
}
