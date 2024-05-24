using VideoStoreManagmentAPI.Interfaces;
using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Repositories
{
    public class CartItemRepository : IRepository<int, CartItem>
    {
        public Task<CartItem> AddAsync(CartItem item)
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartItem>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> GetByIdAsync(int key)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> Update(CartItem item)
        {
            throw new NotImplementedException();
        }
    }
}
