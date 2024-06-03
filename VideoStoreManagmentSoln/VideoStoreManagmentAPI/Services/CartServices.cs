using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI.Services
{
    public class CartServices : ICartServices
    {
        public Task<Cart> AddCartAsync(Cart cart)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> DeleteCartAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cart>> GetAllCartsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCartByIdAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> UpdateCartAsync(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
