using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TripApplication.Data.Entities;

namespace TripApplication.Configurations
{
    public class FollowConfig : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.ToTable("Follow");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Follows)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName("Follow_Company")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Follows)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("Follow_User")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
