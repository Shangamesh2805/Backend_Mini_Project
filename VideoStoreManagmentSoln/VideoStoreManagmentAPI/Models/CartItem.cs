using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VideoStoreManagmentAPI.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int VideoId { get; set; }
        public Videos Video { get; set; }
        public int Quantity { get; set; }
    }
}
