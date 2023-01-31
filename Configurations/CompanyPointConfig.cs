using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TripApplication.Data.Entities;

namespace TripApplication.Configurations
{
    public class CompanyPointConfig : IEntityTypeConfiguration<CompanyPoint>
    {
        public void Configure(EntityTypeBuilder<CompanyPoint> builder)
        {
            builder.ToTable("CompanyPoint");
            builder.HasKey(x => x.CompanyId);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.CompanyPoints)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName("CompanyPoint_Company")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.CompanyPoints)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("CompanyPoint_User")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
