using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Interfaces
{
    public interface IUserServices
    {
        //Task<IEnumerable<Videos>> GetAllVideosAsync();
        //Task<Cart> GetCartByUserIdAsync(int userId);
        //Task<CartItem> AddToCartAsync(int userId, int videoId);
        //Task<CartItem> RemoveFromCartAsync(int userId, int cartItemId);
        //Task<Orders> PlaceOrderAsync(int userId);
        //Task<IEnumerable<Orders>> GetUserOrdersAsync(int userId);

        Task<IEnumerable<Videos>> GetAvailableVideosAsync();
        Task<Orders> PlaceOrderAsync(int userId, int cartId);
        Task<IEnumerable<Orders>> GetUserOrdersAsync(int userId);
        Task<Cart> GetUserCartAsync(int userId);
    }
}
