
using global::VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Services
{
    public interface IVideoService
    {
        Task<IEnumerable<Videos>> GetAllVideosAsync();
        Task<Videos> GetVideoByIdAsync(int id);
        Task<Videos> AddVideoAsync(Videos video);
        Task<Videos> DeleteVideoAsync(int id);
        Task<Videos> UpdateVideoAsync(int id, Videos video);
    }
 }
