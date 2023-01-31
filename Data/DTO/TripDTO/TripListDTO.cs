using System;
using System.Drawing;

namespace TripApplication.Data.DTO.TripDTO
{
    public class TripListDTO
    {
        public int Id { get; set; }
        public string TripName { get; set; }
        public string TripImage { get; set; }
        public int TripDays { get; set; }
        public int TripPrice { get; set; }  
    }
}
