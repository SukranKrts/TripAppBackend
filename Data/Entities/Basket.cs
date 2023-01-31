namespace TripApplication.Data.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
