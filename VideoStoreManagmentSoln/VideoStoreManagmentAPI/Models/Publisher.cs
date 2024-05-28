using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace VideoStoreManagmentAPI.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string Email { get; set; }
        public ICollection<Videos> Videos { get; set; }= new List<Videos>();
    }
}
