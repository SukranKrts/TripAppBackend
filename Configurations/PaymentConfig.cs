using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TripApplication.Data.Entities;

namespace TripApplication.Configurations
{
    public class PaymentConfig : IEntityTypeConfiguration<PaymentInformation>
    {
        public void Configure(EntityTypeBuilder<PaymentInformation> builder)
        {
            builder.ToTable("PaymentInformation");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("Payment_User")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
