namespace VideoStoreManagmentAPI.Models
{
    public class Videos
    {
        public int VideoId { get; set; }

        public string Genre {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public bool Availability { get; set; }
        public VideoFormat VideoFormat { get; set; }
        public decimal Price {  get; set; }
        public int PublisherId {  get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<FeedBack> Feedbacks { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }

    public enum VideoFormat
    {
        DVD,
        BlueRay

    }
}
