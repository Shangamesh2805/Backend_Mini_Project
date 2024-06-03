using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Interfaces
{
    public interface ICartItemService
    {
        Task<CartItem> AddCartItemAsync(CartItem cartItem);
        Task<CartItem> RemoveCartItemAsync(int cartItemId);
        Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId);
    }
}
