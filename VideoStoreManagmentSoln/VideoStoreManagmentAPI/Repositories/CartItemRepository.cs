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
<<<<<<< HEAD
            try
            {
                _context.CartItems.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Couldn't Add Car Item ",ex);
            }
=======
            _context.CartItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
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

<<<<<<< HEAD
        public Task<int> SaveChangesAsync()
=======
        public Task SaveChangesAsync()
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
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