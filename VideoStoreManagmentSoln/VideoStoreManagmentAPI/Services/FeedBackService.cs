using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories;
using VideoStoreManagmentAPI.Repositories.Interfaces;
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI.Services
{
    public class FeedbackService : IFeedBackService
    {
        private readonly IFeedBackRepository _feedbackRepository;

        public FeedbackService(IFeedBackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<List<FeedBack>> GetAllFeedbacks()
        {
            try
            {
                return await _feedbackRepository.GetAllFeedbacks();
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error occurred while getting all feedbacks", ex);
            }
        }

        public async Task AddFeedback(FeedBack feedback)
        {
            try
            {
                await _feedbackRepository.AddFeedback(feedback);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error occurred while adding feedback", ex);
            }
        }

       
        public async Task DeleteFeedback(int id)
        {
            try
            {
                await _feedbackRepository.DeleteFeedback(id);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error occurred while deleting feedback", ex);
            }
        }

        
    }
}
