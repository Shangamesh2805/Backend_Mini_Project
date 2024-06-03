using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Services.Interfaces
{
    public interface ICartServices
    {
        Task<Cart> AddCartAsync(Cart cart);
        Task<Cart> DeleteCartAsync(int cartId);
        Task<IEnumerable<Cart>> GetAllCartsAsync();
        Task<Cart> GetCartByIdAsync(int cartId);
        Task<Cart> UpdateCartAsync(Cart cart);
    }
}
