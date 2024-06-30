using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Exceptions;
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

        /// <summary>
        /// Adds a new cart item.
        /// </summary>
        /// <param name="cartItem">The cart item to add.</param>
        /// <returns>The added cart item.</returns>

        public async Task<CartItem> RemoveCartItemAsync(int cartItemId)
        {
            var cartItem = await _context.CartItems.FindAsync(cartItemId);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
                return cartItem;
            }
            throw new CartItemNotFoundException();
        }
        /// <summary>
        /// Removes a cart item by its ID.
        /// </summary>
        /// <param name="cartItemId">The ID of the cart item to remove.</param>
        /// <returns>The removed cart item.</returns>
        /// <exception cref="CartItemNotFoundException">Thrown when the cart item is not found.</exception>


        public async Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId)
        {
            return await _context.CartItems.Where(ci => ci.CartId == cartId).ToListAsync();
        }

        /// <summary>
        /// Retrieves all cart items associated with a specific cart ID.
        /// </summary>
        /// <param name="cartId">The ID of the cart.</param>
        /// <returns>A list of cart items.</returns>
    }
}
