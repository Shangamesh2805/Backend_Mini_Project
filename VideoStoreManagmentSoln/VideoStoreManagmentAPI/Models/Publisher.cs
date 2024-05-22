using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VideoStoreManagmentAPI.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public ICollection<Videos> Videos { get; set; }= new List<Videos>();
    }
}
