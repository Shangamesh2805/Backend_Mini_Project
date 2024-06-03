using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Contexts;
=======
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Exceptions;
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;

namespace VideoStoreManagmentAPI.Repositories
{
<<<<<<< HEAD
    public class FeedBackRepository : IFeedBackRepository
    {
        private readonly VideoStoreManagementContext _context;

        public FeedBackRepository(VideoStoreManagementContext context)
=======
    public class FeedbackRepository : IRepository<int, FeedBack>
    {
        private readonly VideoStoreManagementContext _context;

        public FeedbackRepository(VideoStoreManagementContext context)
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
        {
            _context = context;
        }

<<<<<<< HEAD
        public async Task<List<FeedBack>> GetAllFeedbacks()
=======
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
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
        {
            return await _context.FeedBacks.ToListAsync();
        }

<<<<<<< HEAD
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

       
=======
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
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
    }
}
