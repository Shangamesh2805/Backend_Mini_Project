namespace VideoStoreManagmentAPI.Models.DTOs.VideoDTOs
{
    public class VideoDTO
    {
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public bool Availability { get; set; }
        public VideoFormat VideoFormat { get; set; }
        public decimal Price { get; set; }
        public int VideoCount { get; set; }
        public int PublisherId { get; set; }
    }
}
