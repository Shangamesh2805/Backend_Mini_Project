namespace VideoStoreManagmentAPI.Models
{
    public class FeedBack
    {
        public int FeedbackId { get; set; }

        public decimal Rating { get; set; }

        public string Comments {  get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int VideoId {  get; set; }
        public Videos Videos { get; set; }
    }
}
