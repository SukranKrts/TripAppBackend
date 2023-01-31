using Microsoft.EntityFrameworkCore;
using TripApplication.Configurations;
using TripApplication.Data.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TripApplication.Data
{
    public class MainDb: DbContext
    {
        public MainDb(DbContextOptions<MainDb> options) : base(options)
        {

        }

        public DbSet<Trip> Trips { get; set; }    
        public DbSet<User> Users { get; set; }
        public DbSet<TripComment> TripComments { get; set; }
        public DbSet<PaymentInformation> PaymentInformations { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<CompanyPoint> CompanyPoints { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>().ToTable("BasketTable");
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<CompanyPoint>().ToTable("CompanyPoint");
            modelBuilder.Entity<Favourite>().ToTable("Favourite");
            modelBuilder.Entity<Follow>().ToTable("Follow");
            modelBuilder.Entity<PaymentInformation>().ToTable("Paymentİnformation");
            modelBuilder.Entity<Trip>().ToTable("Trip");
            modelBuilder.Entity<TripComment>().ToTable("TripComment");
            modelBuilder.Entity<User>().ToTable("UserTable");
        }
    }
}
