using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI.Services
{
    public class OrderService : IOrderServices
    {
        private readonly VideoStoreManagementContext _context;

        public OrderService(VideoStoreManagementContext context)
        {
            _context = context;
        }

        public async Task<Orders> PlaceOrderFromCartAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var cart = await _context.Carts
                                     .Include(c => c.CartItems)
                                     .ThenInclude(ci => ci.Video)
                                     .FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null || !cart.CartItems.Any())
            {
                throw new Exception("Cart is empty");
            }

            decimal totalAmount = 0;
            var videos = new List<Videos>();

            foreach (var cartItem in cart.CartItems)
            {
                var video = cartItem.Video;
                if (!video.Availability || video.VideoCount <= 0)
                {
                    throw new Exception($"Video {video.Title} is not available");
                }

                totalAmount += user.Membership == UserType.GoldenMember ? video.Price * (1 - user.DiscountFactor / 100) : video.Price;
                video.VideoCount -= 1;
                if (video.VideoCount == 0)
                {
                    video.Availability = false;
                }

                videos.Add(video);
                _context.Videos.Update(video);
            }

            var order = new Orders
            {
                UserId = userId,
                TotalAmount = totalAmount,
                OrderDate = DateTime.UtcNow,
                RentalExpireDate = DateTime.UtcNow.AddDays(7)
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach (var video in videos)
            {
                var orderDetail = new OrderDetails
                {
                    OrderId = order.OrderId,
                    VideoId = video.VideoId
                };

                _context.OrderDetails.Add(orderDetail);
            }

            // Clear the cart
            _context.CartItems.RemoveRange(cart.CartItems);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<IEnumerable<Orders>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Orders.Where(o => o.UserId == userId).ToListAsync();
        }

        
    }

        
}
    

