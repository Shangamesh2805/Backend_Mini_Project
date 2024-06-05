using VideoStoreManagmentAPI.Models.DTOs;

public class CartDTO
{
    public int CartId { get; set; }
    public List<CartItemDTO> Items { get; set; }
}
