using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;

namespace VideoStoreManagmentAPI.Repositories
{
    public class CartItemRepository : IRepository<int, CartItem>
    {
        private readonly VideoStoreManagementContext _context;
        public CartItemRepository(VideoStoreManagementContext context)
        {
            _context = context;
        }

        public async Task<CartItem> AddAsync(CartItem item)
        {
            _context.CartItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

     

        public async Task<CartItem> Delete(int key)
        {
            var item = await GetByIdAsync(key);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
            throw new NoCartItemWithGivenIDException();
        }

        public async Task<IEnumerable<CartItem>> GetAllAsync()
        {
            var result = await _context.CartItems.ToListAsync();
            if (result.Count == 0)
            {
                throw new CartItemEmptyException();
            }
            return result;
        }

        public async Task<CartItem> GetByIdAsync(int key)
        {
            var item = await _context.CartItems.FindAsync(key);
            if (item != null)
            {
                return item;
            }
            throw new NoCartItemWithGivenIDException();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<CartItem> Update(CartItem item)
        {
            if (item == null)
            {
                throw new NoCartItemWithGivenIDException();
            }
            _context.CartItems.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}