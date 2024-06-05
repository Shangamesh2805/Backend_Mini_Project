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
<<<<<<< HEAD
          
                var item = await GetByIdAsync(key);
=======
            var item = await GetByIdAsync(key);
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
            if (item != null)
            {
                _context.Orders.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
<<<<<<< HEAD
            else { 
          
               throw new NoOrderFounDException();
            }
=======
            throw new OrderNotFounDException();
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
        }


        public async Task<Orders> GetByIdAsync(int key)
        {
            var item = await GetByIdAsync(key);
            if (item != null)
            {
                return item;
            }
<<<<<<< HEAD
            throw new UserNotFoundException();
=======
            throw new OrderNotFoundException();
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
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
<<<<<<< HEAD
                throw new NoOrderFounDException();
=======
                throw new OrderNotFounDException();
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
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
<<<<<<< HEAD
            throw new NoOrderFounDException();
=======
            throw new OrderNotFounDException();
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
        }

        async Task<IEnumerable<Orders>> IRepository<int, Orders>.GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

<<<<<<< HEAD
        async Task<int> IRepository<int, Orders>.SaveChangesAsync()
        {
            return await _context.SaveChangesAsync(); 
        }
=======
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
    }
}
