namespace VideoStoreManagmentAPI.Models.DTOs
{
    public class PublisherRegisterDTO
    {
        
        public string PublisherName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
