<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
﻿using System.ComponentModel.DataAnnotations;

namespace VideoStoreManagmentAPI.Models.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
<<<<<<< HEAD
=======
=======
﻿namespace VideoStoreManagmentAPI.Models.DTOs
{
    public class UserLoginDTO
    {
        public int UserId { get; set; }
        public string Password { get; set; } = string.Empty;
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
    }
}
