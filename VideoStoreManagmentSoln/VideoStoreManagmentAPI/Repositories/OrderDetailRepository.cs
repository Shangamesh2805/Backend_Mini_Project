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
            try
            {
                _context.OrderDetails.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Coudln't Add Orderitem ", ex);
            }
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
            throw new NoOrderDetailFoundException();
        }

        public async Task<IEnumerable<OrderDetails>> GetAllAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetails> GetByIdAsync(int key)
        {
            try
            {
                return await _context.OrderDetails.FindAsync(key);
            }
            catch(Exception ex)
            {
                throw new Exception("Couldn't get OrderDetails", ex);
            }
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
                throw new NoOrderDetailFoundException();
            }

            _context.Entry(existingOrderDetail).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return existingOrderDetail;
        }

        async Task<int> IRepository<int, OrderDetails>.SaveChangesAsync()
        {
            return await _context.SaveChangesAsync(); 
        }
    }
}
