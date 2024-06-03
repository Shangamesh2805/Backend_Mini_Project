using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
<<<<<<< HEAD
using VideoStoreManagmentAPI.Exceptions;
=======
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
using VideoStoreManagmentAPI.Interfaces;
using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly VideoStoreManagementContext _context;

        public CartItemService(VideoStoreManagementContext context)
        {
            _context = context;
        }

        public async Task<CartItem> AddCartItemAsync(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }

        public async Task<CartItem> RemoveCartItemAsync(int cartItemId)
        {
            var cartItem = await _context.CartItems.FindAsync(cartItemId);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
                return cartItem;
            }
<<<<<<< HEAD
            throw new CartItemNotFoundException();
=======
            throw new KeyNotFoundException("CartItem not found");
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId)
        {
            return await _context.CartItems.Where(ci => ci.CartId == cartId).ToListAsync();
        }
    }
}
