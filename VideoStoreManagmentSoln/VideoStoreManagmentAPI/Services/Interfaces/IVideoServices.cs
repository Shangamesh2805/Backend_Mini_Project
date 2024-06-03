
using global::VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs;

namespace VideoStoreManagmentAPI.Services
{
    public interface IVideoService
    {

        Task<List<Videos>> GetAllVideos();
        Task<Videos> GetVideoById(int id);
        Task AddVideo(VideoDTO videoDto, int publisherId);
        Task UpdateVideo(int id, VideoDTO videoDto);
        Task DeleteVideo(int id);
    }
 }
