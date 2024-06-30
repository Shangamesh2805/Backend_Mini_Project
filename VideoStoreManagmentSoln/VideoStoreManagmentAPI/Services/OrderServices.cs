using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.DTOs;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs.OrderDTOs;
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

        public async Task<OrderDTO> PlaceOrderFromCartAsync(int userId, decimal paymentAmount)
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
                RentalExpireDate = DateTime.UtcNow.AddDays(7),
                Status = "Pending"
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

            _context.CartItems.RemoveRange(cart.CartItems);
            await _context.SaveChangesAsync();

            var orderDTO = new OrderDTO
            {
                OrderId = order.OrderId,
                UserId = userId,
                TotalAmount = totalAmount,
                OrderDate = order.OrderDate,
                RentalExpireDate = order.RentalExpireDate,
                Status = order.Status,
                OrderDetails = videos.Select(v => new OrderDetailDTO { VideoId = v.VideoId }).ToList()
            };

            return orderDTO;
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _context.Orders
                                       .Where(o => o.UserId == userId)
                                       .Include(o => o.OrderDetails)
                                       .ToListAsync();

            var orderDTOs = orders.Select(order => new OrderDTO
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                TotalAmount = order.TotalAmount,
                OrderDate = order.OrderDate,
                RentalExpireDate = order.RentalExpireDate,
                Status = order.Status,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailDTO { VideoId = od.VideoId }).ToList()
            });

            return orderDTOs;
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            var orderDTO = new OrderDTO
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                TotalAmount = order.TotalAmount,
                OrderDate = order.OrderDate,
                RentalExpireDate = order.RentalExpireDate,
                Status = order.Status,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailDTO { VideoId = od.VideoId }).ToList()
            };
            return orderDTO;
        }
    }
}
