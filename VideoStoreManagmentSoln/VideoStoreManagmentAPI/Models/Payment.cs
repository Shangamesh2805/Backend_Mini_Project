using System;
using System.ComponentModel.DataAnnotations;

namespace VideoStoreManagmentAPI.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; }

        public Orders Order { get; set; }
    }
}
