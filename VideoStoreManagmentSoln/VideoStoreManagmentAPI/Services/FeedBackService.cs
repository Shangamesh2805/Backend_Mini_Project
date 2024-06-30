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

        /// <summary>
        /// Retrieves all feedbacks.
        /// </summary>
        /// <returns>A list of feedbacks.</returns>
        /// <exception cref="ServiceException">Thrown when an error occurs while getting all feedbacks.</exception>

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

        /// <summary>
        /// Adds a new feedback.
        /// </summary>
        /// <param name="feedback">The feedback to add.</param>
        /// <exception cref="ServiceException">Thrown when an error occurs while adding feedback.</exception>

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

        /// <summary>
        /// Deletes a feedback by its ID.
        /// </summary>
        /// <param name="id">The ID of the feedback to delete.</param>
        /// <exception cref="ServiceException">Thrown when an error occurs while deleting feedback.</exception>



    }
}
