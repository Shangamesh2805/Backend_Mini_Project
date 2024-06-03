
using global::VideoStoreManagmentAPI.Models;
<<<<<<< HEAD
using VideoStoreManagmentAPI.Models.DTOs;
=======
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7

namespace VideoStoreManagmentAPI.Services
{
    public interface IVideoService
    {
<<<<<<< HEAD

        Task<List<Videos>> GetAllVideos();
        Task<Videos> GetVideoById(int id);
        Task AddVideo(VideoDTO videoDto, int publisherId);
        Task UpdateVideo(int id, VideoDTO videoDto);
        Task DeleteVideo(int id);
=======
        Task<IEnumerable<Videos>> GetAllVideosAsync();
        Task<Videos> GetVideoByIdAsync(int id);
        Task<Videos> AddVideoAsync(Videos video);
        Task<Videos> DeleteVideoAsync(int id);
        Task<Videos> UpdateVideoAsync(int id, Videos video);
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
    }
 }
