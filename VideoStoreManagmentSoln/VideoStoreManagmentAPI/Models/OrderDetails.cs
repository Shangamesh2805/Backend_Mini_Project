using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoStoreManagmentAPI.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public Orders Order { get; set; }
        [ForeignKey("VideoId")]
        public int VideoId { get; set; }
        public Videos Video { get; set; }
    }
}
