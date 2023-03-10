using System.ComponentModel.DataAnnotations;

namespace TripApplication.Data.DTO.TripDTO
{
    public class TripInfoDTO
    {
        [Required]
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
    }
}
