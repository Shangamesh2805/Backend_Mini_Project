using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace VideoStoreManagmentAPI.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Orders Order { get; set; }
        public int VideoId { get; set; }
        public Videos Video { get; set; }
    }
}
