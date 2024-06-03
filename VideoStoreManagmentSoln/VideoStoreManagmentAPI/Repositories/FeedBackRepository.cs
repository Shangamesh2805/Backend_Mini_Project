using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;

namespace VideoStoreManagmentAPI.Repositories
{
    public class FeedBackRepository : IFeedBackRepository
    {
        private readonly VideoStoreManagementContext _context;

        public FeedBackRepository(VideoStoreManagementContext context)
        {
            _context = context;
        }

        public async Task<List<FeedBack>> GetAllFeedbacks()
        {
            return await _context.FeedBacks.ToListAsync();
        }

        public async Task AddFeedback(FeedBack feedback)
        {
            _context.FeedBacks.Add(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFeedback(FeedBack feedback)
        {
            _context.FeedBacks.Update(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFeedback(int id)
        {
            var feedback = await _context.FeedBacks.FindAsync(id);
            if (feedback != null)
            {
                _context.FeedBacks.Remove(feedback);
                await _context.SaveChangesAsync();
            }
        }

       
    }
}
