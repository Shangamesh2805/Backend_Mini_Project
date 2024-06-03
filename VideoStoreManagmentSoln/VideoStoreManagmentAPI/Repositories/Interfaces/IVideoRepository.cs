using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs;

namespace VideoStoreManagmentAPI.Repositories.Interfaces
{
    public interface IVideoRepository
    {
        Task<List<Videos>> GetAllVideos();
        Task<Videos> GetVideoById(int id);
        Task AddVideo(VideoDTO videoDto, int publisherId);
        Task UpdateVideo(VideoDTO videoDto);
        Task DeleteVideo(int id);
    }
}
