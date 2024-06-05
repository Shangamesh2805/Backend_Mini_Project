using VideoStoreManagmentAPI.Models.DTOs;

public interface ICartService
{
    Task<CartDTO> GetCartAsync(int userId);
    Task AddCartItemAsync(int userId, AddCartItemDTO addCartItemDto);
    Task RemoveCartItemAsync(int userId, int itemId);
    Task ClearCartAsync(int userId);
}
