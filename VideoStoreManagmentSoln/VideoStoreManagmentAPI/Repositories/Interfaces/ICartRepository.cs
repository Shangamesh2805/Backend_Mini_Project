using VideoStoreManagmentAPI.Models;

public interface ICartRepository
{
    Task<Cart> GetCartAsync(int userId);
    Task<Cart> CreateCartAsync(int userId);
    Task<CartItem> GetCartItemAsync(int cartId, int itemId);
    Task<Videos> GetVideoAsync(int videoId);
    Task SaveChangesAsync();
}
