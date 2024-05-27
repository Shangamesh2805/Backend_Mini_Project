using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;

namespace VideoStoreManagmentAPI.Repositories
{
    public class OrderDetailRepository : IRepository<int, OrderDetails>
    {
        private readonly VideoStoreManagementContext _context;

        public OrderDetailRepository(VideoStoreManagementContext context)
        {
            _context = context;
        }

        public async Task<OrderDetails> AddAsync(OrderDetails item)
        {
            _context.OrderDetails.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

    

        public async Task<OrderDetails> Delete(int key)
        {
            var item = await GetByIdAsync(key);
            if (item != null)
            {
                _context.OrderDetails.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
            throw new OrderDetailFoundException();
        }

        public async Task<IEnumerable<OrderDetails>> GetAllAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetails> GetByIdAsync(int key)
        {
            return await _context.OrderDetails.FindAsync(key);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

      

        public async Task<OrderDetails> Update(OrderDetails item)
        {
            var existingOrderDetail = await GetByIdAsync(item.OrderDetailId);
            if (existingOrderDetail == null)
            {
                throw new OrderDetailFoundException();
            }

            _context.Entry(existingOrderDetail).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return existingOrderDetail;
        }
    }
}
