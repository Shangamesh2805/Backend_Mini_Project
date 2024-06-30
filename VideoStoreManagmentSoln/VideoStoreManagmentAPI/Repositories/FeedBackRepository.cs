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
            try
            {
                return await _context.FeedBacks.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Couldn't get Feedbacks",ex);
            }
        }

        public async Task AddFeedback(FeedBack feedback)
        {
            try
            {
                _context.FeedBacks.Add(feedback);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception($"Failed to add feedback: {feedback}"); 
            }
        }

        public async Task UpdateFeedback(FeedBack feedback)
        {
            try
            {
                _context.FeedBacks.Update(feedback);
                await _context.SaveChangesAsync();
            }
            catch {
                throw new Exception("Couldn't update the feedback ");
            }
        }

        public async Task DeleteFeedback(int id)
        {
            try
            {
                var feedback = await _context.FeedBacks.FindAsync(id);
                if (feedback != null)
                {
                    _context.FeedBacks.Remove(feedback);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("No feedback found with given FeedbackID");
                }
            }
            catch(Exception ex)
            {
                throw new Exception("An exception occured ", ex);
            }
        }

       
    }
}
