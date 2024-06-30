using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoStoreManagmentAPI.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RentalExpireDate { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderDetails>? OrderDetails { get; set; }
        public int? PaymentId { get; set; }
        public Payment Payment { get; set; }

        public string Status { get; set; } = "Pending";
    }
}
