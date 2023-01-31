using System.ComponentModel.DataAnnotations;

namespace TripApplication.Data.DTO.CompanyDTO
{
    public class CompanyCreateDTO
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyPhone { get; set; }
        [Required]
        public string CompanyMail { get; set; }
        [Required]
        public string CompanyAddress { get; set; }
    }
}
