using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Services.Interfaces
{
    public interface IFeedBackService
    {
        Task<List<FeedBack>> GetAllFeedbacks();
        Task AddFeedback(FeedBack feedback);
        Task DeleteFeedback(int id);
    }
}
