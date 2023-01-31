using TripApplication.Data.DTO.TripDTO;

namespace TripApplication.Data.Entities
{
    public class Favourite
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
