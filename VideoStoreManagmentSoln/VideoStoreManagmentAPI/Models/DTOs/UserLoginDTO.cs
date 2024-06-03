<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;

namespace VideoStoreManagmentAPI.Models.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
=======
﻿namespace VideoStoreManagmentAPI.Models.DTOs
{
    public class UserLoginDTO
    {
        public int UserId { get; set; }
        public string Password { get; set; } = string.Empty;
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
    }
}
