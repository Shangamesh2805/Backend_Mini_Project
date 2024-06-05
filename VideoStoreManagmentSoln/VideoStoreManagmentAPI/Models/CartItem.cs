using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoStoreManagmentAPI.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        [ForeignKey("CartId")]
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        [ForeignKey("VideoId")]
        public int VideoId { get; set; }
        public Videos Video { get; set; }
        public int Quantity { get; set; }
    }
}
