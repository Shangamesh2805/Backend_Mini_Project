using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;

namespace VideoStoreManagmentAPI.Repositories
{
    public class OrderRepository : IRepository<int, Orders>
    {
        private readonly VideoStoreManagementContext _context;

        public OrderRepository(VideoStoreManagementContext context)
        {
            _context = context;
        }

        public async Task<Orders> AddAsync(Orders item)
        {
            _context.Orders.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Orders> Delete(int key)
        {
          
                var item = await GetByIdAsync(key);
            if (item != null)
            {
                _context.Orders.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
            else { 
          
               throw new NoOrderFounDException();
            }
        }


        public async Task<Orders> GetByIdAsync(int key)
        {
            var item = await GetByIdAsync(key);
            if (item != null)
            {
                return item;
            }
            throw new UserNotFoundException();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

       

        public async Task<Orders> Update(Orders item)
        {
            var existingOrder = await GetByIdAsync(item.OrderId);
            if (existingOrder == null)
            {
                throw new NoOrderFounDException();
            }

            _context.Entry(existingOrder).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return existingOrder;
        }

        async Task<Orders> IRepository<int, Orders>.Delete(int key)
        {
            var item = await GetByIdAsync(key);
            if (item != null)
            {
                _context.Orders.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
            throw new NoOrderFounDException();
        }

        async Task<IEnumerable<Orders>> IRepository<int, Orders>.GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        async Task<int> IRepository<int, Orders>.SaveChangesAsync()
        {
            return await _context.SaveChangesAsync(); 
        }
    }
}
