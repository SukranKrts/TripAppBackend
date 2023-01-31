using System.ComponentModel.DataAnnotations;

namespace TripApplication.Data.Entities
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public string UserPhone { get; set; }
        public string UserPassword { get; set; }

        public virtual ICollection<CompanyPoint> CompanyPoints { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<Follow> Follows { get; set; }
        public virtual ICollection<TripComment> TripComments { get; set; }

        public virtual ICollection<PaymentInformation> Payments { get; set; }
    }
}
