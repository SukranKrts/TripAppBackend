using System.ComponentModel.DataAnnotations;

namespace TripApplication.Data.DTO.UserDTO
{
    public class CreateUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserMail { get; set; }
        [Required]
        public string UserPhone { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}
