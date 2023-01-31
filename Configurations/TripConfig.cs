using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TripApplication.Data.Entities;

namespace TripApplication.Configurations
{
    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("Trip");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Trips)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName("Trip_Company")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
