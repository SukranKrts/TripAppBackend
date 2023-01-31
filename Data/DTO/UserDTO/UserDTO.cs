using System.ComponentModel.DataAnnotations;

namespace TripApplication.Data.DTO.UserDTO
{
    public class UserDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserMail { get; set; }
    }
}
