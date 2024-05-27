using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Repositories.Interfaces;
using VideoStoreManagmentAPI.Exceptions;

namespace VideoStoreManagmentAPI.Repositories
{
    public class PublisherRepository : IRepository<int, Publisher>
    {
        private readonly VideoStoreManagementContext _context;

        public PublisherRepository(VideoStoreManagementContext context)
        {
            _context = context;
        }

        public async Task<Publisher> AddAsync(Publisher item)
        {
            await _context.Publisher.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Publisher> Delete(int key)
        {
            var item = await _context.Publisher.FindAsync(key);
            if (item != null)
            {
                _context.Publisher.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
           throw new PublisherNotFoundException();
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await _context.Publisher.ToListAsync();
        }

        public async Task<Publisher> GetByIdAsync(int key)
        {
            return await _context.Publisher.FindAsync(key);
        }

        public async Task<Publisher> Update(Publisher item)
        {
            var existingPublisher = await _context.Publisher.FindAsync(item.PublisherId);
            if (existingPublisher != null)
            {
                _context.Entry(existingPublisher).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return existingPublisher;
            }
            throw new PublisherNotFoundException();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

       
    }
}
