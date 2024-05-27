using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;

namespace VideoStoreManagmentAPI.Repositories
{
    public class FeedbackRepository : IRepository<int, FeedBack>
    {
        private readonly VideoStoreManagementContext _context;

        public FeedbackRepository(VideoStoreManagementContext context)
        {
            _context = context;
        }

        public async Task<FeedBack> AddAsync(FeedBack item)
        {
            _context.FeedBacks.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

     
        public async Task<FeedBack> Delete(int key)
        {
            throw new KeyNotFoundException("Feedback cannot be deleted");
        }

        public async Task<IEnumerable<FeedBack>> GetAllAsync()
        {
            return await _context.FeedBacks.ToListAsync();
        }

        public async Task<FeedBack> GetByIdAsync(int key)
        {
            var item = await GetByIdAsync(key);
            if (item != null)
            {
                return item;
            }
            throw new FeedBackNotFoundException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FeedBack> Update(FeedBack item)
        {
            throw new Exception("FeedBack Cannot be updated");
        }
    }
}
