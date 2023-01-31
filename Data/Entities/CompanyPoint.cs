namespace TripApplication.Data.Entities
{
    public class CompanyPoint
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int CompanyPoints { get; set; }

        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
    }
}
