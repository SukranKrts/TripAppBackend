namespace TripApplication.Data.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string TripName { get; set; }
        public string TripImage { get; set; }
        public string TripType { get; set; }
        public int TripDays { get; set; }
        public DateTime TripDate { get; set; }
        public int TripPrice { get; set; }
        public string WhereFrom { get; set; }
        public string OurServices { get; set; }
        public string TripDetail { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<TripComment> TripComments { get; set; }

        public virtual Company Company { get; set; }
    }
}
