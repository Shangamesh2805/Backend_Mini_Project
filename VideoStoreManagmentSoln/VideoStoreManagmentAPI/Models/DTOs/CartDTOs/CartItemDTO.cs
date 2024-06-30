namespace VideoStoreManagmentAPI.Models.DTOs.CartDTOs
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public int VideoId { get; set; }
        public string VideoTitle { get; set; }
        public int Quantity { get; set; }
    }
}
