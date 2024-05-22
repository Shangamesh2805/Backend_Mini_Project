namespace VideoStoreManagmentAPI.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RentalExpireDate { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
