using System.ComponentModel.DataAnnotations;

namespace VideoStoreManagmentAPI.DTOs
{
    public class MakePaymentDTO
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public decimal PaymentAmount { get; set; }
    }
}
