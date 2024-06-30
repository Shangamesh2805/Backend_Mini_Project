using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Models.DTOs.OrderDTOs;
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI.Services
{
    public class OrderDetailsService : IOrderDetailService
    {
        private readonly VideoStoreManagementContext _context;

        public OrderDetailsService(VideoStoreManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDetailDTO>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            var orderDetails = await _context.OrderDetails
                                             .Where(od => od.OrderId == orderId)
                                             .ToListAsync();

            var orderDetailDTOs = orderDetails.Select(od => new OrderDetailDTO
            {
                VideoId = od.VideoId
            });

            return orderDetailDTOs;
        }
    }
}

/// <summary>
/// Retrieves order details by order ID.
/// </summary>
/// <param name="orderId">The ID of the order.</param>
/// <returns>A list of order details.</returns>
