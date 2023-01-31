using System.ComponentModel.DataAnnotations;

namespace TripApplication.Data.DTO.UserDTO
{
    public class UserLoginDTO
    {
        [Required]
        public string UserMail { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}
