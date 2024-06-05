using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Models;

public class CartRepository : ICartRepository
{
    private readonly VideoStoreManagementContext _context;

    public CartRepository(VideoStoreManagementContext context)
    {
        _context = context;
    }

    public async Task<Cart> GetCartAsync(int userId)
    {
        try
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Video)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }
        catch  {
            throw new CartException();

        }
    }

    public async Task<Cart> CreateCartAsync(int userId)
    {
        try
        {
            var cart = new Cart { UserId = userId, CartItems = new List<CartItem>() };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
        }
        catch(Exception e) {
            throw new Exception("Error occured",e);

        }
    }

    public async Task<CartItem> GetCartItemAsync(int cartId, int itemId)
    {
        return await _context.CartItems
            .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.CartItemId == itemId);
    }

    public async Task<Videos> GetVideoAsync(int videoId)
    {
        try
        {
            return await _context.Videos.FindAsync(videoId);
        }
        catch (Exception e)
        {
            throw new Exception("Couldn't get the video",e);
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
