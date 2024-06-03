using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Models;
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

        public async Task<IEnumerable<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await _context.OrderDetails.Where(od => od.OrderId == orderId).ToListAsync();
        }
    }
}