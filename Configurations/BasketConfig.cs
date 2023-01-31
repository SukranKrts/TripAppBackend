using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TripApplication.Data.Entities;

namespace TripApplication.Configurations
{
    public class BasketConfig : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.ToTable("Basket");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Baskets)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("Basket_User")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Trip)
                .WithMany(x => x.Baskets)
                .HasForeignKey(x => x.TripId)
                .HasConstraintName("Basket_Trip")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
