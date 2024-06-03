<<<<<<< HEAD
﻿
using System.ComponentModel.DataAnnotations;

namespace VideoStoreManagmentAPI.Models.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Role Role { get; set; } // Customer or Publisher
        public UserType Membership { get; set; }

=======
﻿namespace VideoStoreManagmentAPI.Models.DTOs
{
    public class UserRegisterDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } = string.Empty;
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
    }
}
