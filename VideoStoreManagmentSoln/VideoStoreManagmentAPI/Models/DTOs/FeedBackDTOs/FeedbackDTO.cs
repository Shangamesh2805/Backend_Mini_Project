namespace VideoStoreManagmentAPI.Models.DTOs.FeedBackDTOs
{
    public class FeedbackDTO
    {
        
        public decimal Rating { get; set; }
        public string Comments { get; set; }
        public int UserId { get; set; }
        public int VideoId { get; set; }

    }
}
