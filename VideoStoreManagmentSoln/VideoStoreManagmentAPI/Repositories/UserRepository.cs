using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;

namespace VideoStoreManagmentAPI.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        protected readonly VideoStoreManagementContext _context;

        public UserRepository(VideoStoreManagementContext context)
        {
            _context = context;
        }
        public async Task<User> AddAsync(User item)
        {
            _context.Users.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> Delete(int key)
        {
            var item = await GetByIdAsync(key);
            if (item != null)
            {
                _context.Users.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
            throw new OrderNotFoundException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int key)
        {
            var item = await GetByIdAsync(key);
            if (item != null)
            {
                return item;
            }
            throw new OrderNotFoundException();
        }
    

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<User> Update(User item)
        {
        var existinguser = await GetByIdAsync(item.UserId);
        if (existinguser != null)
        {
            _context.Entry(existinguser).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return existinguser;
        }
        throw new OrderNotFoundException();
    }
}
}
