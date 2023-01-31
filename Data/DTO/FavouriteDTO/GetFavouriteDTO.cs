using TripApplication.Data.DTO.TripDTO;

namespace TripApplication.Data.DTO.FavouriteDTO
{
    public class GetFavouriteDTO
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public int UserId { get; set; }

        public ICollection<TripListDTO> TripListDTOs { get; set; }
    }
}
