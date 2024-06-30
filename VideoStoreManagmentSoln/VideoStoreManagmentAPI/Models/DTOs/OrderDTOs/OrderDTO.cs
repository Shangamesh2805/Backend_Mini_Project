using VideoStoreManagmentAPI.Models.DTOs.OrderDTOs;

namespace VideoStoreManagmentAPI.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RentalExpireDate { get; set; }
        public int? PaymentId { get; set; }
        public string Status { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}
