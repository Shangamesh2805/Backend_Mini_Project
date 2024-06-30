using System.ComponentModel.DataAnnotations.Schema;

namespace VideoStoreManagmentAPI.Models
{
    public class FeedBack
    {

        public int FeedbackId { get; set; }

        public decimal Rating { get; set; }

        public string Comments {  get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("VideoId")]
        public int VideoId {  get; set; }
        public Videos Videos { get; set; }
    }
}
