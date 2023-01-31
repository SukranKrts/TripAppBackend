using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TripApplication.Data.Entities;

namespace TripApplication.Configurations
{
    public class FavouriteConfig : IEntityTypeConfiguration<Favourite>
    {
        public void Configure(EntityTypeBuilder<Favourite> builder)
        {
            builder.ToTable("Favourite");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Trip)
                .WithMany(x => x.Favourites)
                .HasForeignKey(x => x.TripId)
                .HasConstraintName("Favourie_Trip")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Favourites)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("Favourite_User")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
