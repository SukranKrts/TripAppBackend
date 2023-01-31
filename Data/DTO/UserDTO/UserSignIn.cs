using System.ComponentModel.DataAnnotations;

namespace TripApplication.Data.DTO.UserDTO
{
    public class UserSignIn
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserMail { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}
