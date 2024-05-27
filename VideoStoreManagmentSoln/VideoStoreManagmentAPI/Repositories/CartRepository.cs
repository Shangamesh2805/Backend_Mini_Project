using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;

namespace VideoStoreManagmentAPI.Repositories
{
    public class CartRepository : IRepository<int, Cart>
    {
        private readonly VideoStoreManagementContext _context;
        public CartRepository(VideoStoreManagementContext context)
        {
            _context = context;
        }

        public async Task<Cart> AddAsync(Cart item)
        {
            _context.Carts.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Cart> Delete(int key)
        {
            
            var item = await GetByIdAsync(key);
            if (item != null) { 
                _context.Carts.Remove(item);
                await _context.SaveChangesAsync(true);
                return item; 
            }
            throw new NoVideoWithGivenVideoIDException();
        }

        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            var result = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Video)
                .ToListAsync();
            if (result.Count == 0)
            {
                throw new CartEmpytyException();
            }
            return result;
        }

        public async Task<Cart> GetByIdAsync(int key)
        {
            var item = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Video)
                .FirstOrDefaultAsync(c => c.CartId == key);
            if (item != null)
            {
                return item;
            }
            throw new NoVideoWithGivenVideoIDException();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> Update(Cart item)
        {
            var existingCart = await GetByIdAsync(item.CartId);
            if (existingCart != null)
            {
                _context.Entry(existingCart).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return existingCart;
            }
            throw new NoVideoWithGivenVideoIDException();
        }
    }
}
