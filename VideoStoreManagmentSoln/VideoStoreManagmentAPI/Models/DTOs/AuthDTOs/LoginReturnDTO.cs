namespace VideoStoreManagmentAPI.Models.DTOs.AuthDTOs
{
    public class LoginReturnDTO
    {

        public int UserId { get; set; }
        public string Token { get; set; }

        public Role Role { get; set; }

    }
}
