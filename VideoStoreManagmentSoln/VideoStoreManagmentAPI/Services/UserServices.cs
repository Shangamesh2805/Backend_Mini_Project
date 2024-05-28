using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Interfaces;
using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Services
{
    public class UserService : IUserServices
    {
        private readonly VideoStoreManagementContext _context;

        public UserService(VideoStoreManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Videos>> GetAvailableVideosAsync()
        {
            return await _context.Videos.Where(v => v.Availability).ToListAsync();
        }

        public async Task<Orders> PlaceOrderAsync(int userId, int cartId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) throw new KeyNotFoundException("User not found");

            var cart = await _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Video).FirstOrDefaultAsync(c => c.UserId == userId && c.CartId == cartId);
            if (cart == null) throw new KeyNotFoundException("Cart not found");

            if (!cart.CartItems.Any()) throw new InvalidOperationException("Cart is empty");

            var order = new Orders
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalAmount = cart.CartItems.Sum(ci => ci.Video.Price * (1 - user.DiscountFactor / 100.0)),
                OrderDetails = cart.CartItems.Select(ci => new OrderDetails { VideoId = ci.VideoId }).ToList()
            };

            _context.Orders.Add(order);
            _context.CartItems.RemoveRange(cart.CartItems);  // Clear the cart items after placing the order

            foreach (var item in cart.CartItems)
            {
                var video = await _context.Videos.FindAsync(item.VideoId);
                if (video != null)
                {
                    video.VideoCount -= 1;
                    if (video.VideoCount == 0) video.Availability = false;
                }
            }

            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Orders>> GetUserOrdersAsync(int userId)
        {
            return await _context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Video).Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task<Cart> GetUserCartAsync(int userId)
        {
            return await _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Video).FirstOrDefaultAsync(c => c.UserId == userId);
        }

        Task<Orders> IUserServices.PlaceOrderAsync(int userId, int cartId)
        {
            throw new NotImplementedException();
        }

       
    }
}
