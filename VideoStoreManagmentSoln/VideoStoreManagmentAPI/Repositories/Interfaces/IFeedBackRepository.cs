using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Repositories.Interfaces
{
    public interface IFeedBackRepository
    {
        Task<List<FeedBack>> GetAllFeedbacks();
        Task AddFeedback(FeedBack feedback);
        Task UpdateFeedback(FeedBack feedback);
        Task DeleteFeedback(int id);
    }
}
