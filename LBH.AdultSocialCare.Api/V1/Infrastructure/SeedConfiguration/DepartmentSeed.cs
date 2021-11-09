using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class DepartmentSeed : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department { Id = 1, Name = "Brokerage" },
                new Department { Id = 2, Name = "Finance" });
        }
    }
}
