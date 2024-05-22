using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VideoStoreManagmentAPI.Models
{
    public class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Orders Order { get; set; }
        public int VideoId { get; set; }
        public Videos Video { get; set; }
    }
}
