using VideoStoreManagmentAPI.Models.DTOs.CartDTOs;

public class CartDTO
{
    public int CartId { get; set; }
    public List<CartItemDTO> Items { get; set; }
}
