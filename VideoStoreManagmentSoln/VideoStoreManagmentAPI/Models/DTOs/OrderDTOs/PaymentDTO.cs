using System;

namespace VideoStoreManagmentAPI.DTOs
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal PaymentAmount { get; set; }
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
