using System.ComponentModel.DataAnnotations;

namespace VideoStoreManagmentAPI.Models.DTOs.AuthDTOs
{
    public class UserLoginDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
