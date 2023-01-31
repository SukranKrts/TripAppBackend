namespace TripApplication.Data.Entities
{
    public class TripComment
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int Point { get; set; }

        public virtual User User { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
