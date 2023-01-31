using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TripApplication.Data.Entities;

namespace TripApplication.Configurations
{
    public class TripCommentConfig : IEntityTypeConfiguration<TripComment>
    {
        public void Configure(EntityTypeBuilder<TripComment> builder)
        {
            builder.ToTable("TripComment");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Trip)
                .WithMany(x => x.TripComments)
                .HasForeignKey(x => x.TripId)
                .HasConstraintName("TripComment_Trip")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.TripComments)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("TripComment_User")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
