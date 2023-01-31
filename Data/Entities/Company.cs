using System.ComponentModel.DataAnnotations;

namespace TripApplication.Data.Entities
{
    public class Company
    {
        [Required]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyMail { get; set; }
        public string CompanyAddress { get; set; }

        public virtual ICollection<CompanyPoint> CompanyPoints { get; set; }
        public virtual ICollection<Follow> Follows { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
