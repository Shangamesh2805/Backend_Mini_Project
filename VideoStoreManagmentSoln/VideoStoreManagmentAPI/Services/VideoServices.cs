using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;

namespace VideoStoreManagmentAPI.Services
{
    public class VideoService : IVideoService
    {
        private readonly IRepository<int, Videos> _videoRepository;

        public VideoService(IRepository<int, Videos> videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<IEnumerable<Videos>> GetAllVideosAsync()
        {
            return await _videoRepository.GetAllAsync();
        }

        public async Task<Videos> GetVideoByIdAsync(int id)
        {
            var video = await _videoRepository.GetByIdAsync(id);
            if (video != null)
            {
                return video;
            }
            throw new VideoNotFoundException();
        }

        public async Task<Videos> AddVideoAsync(Videos video)
        {
            return await _videoRepository.AddAsync(video);
        }

        public async Task<Videos> DeleteVideoAsync(int id)
        {
            var item = await _videoRepository.GetByIdAsync(id);
            if (item != null)
            {
                _videoRepository.Delete(id);
                await _videoRepository.SaveChangesAsync();
                return item;
            }
            throw new VideoNotFoundException() ;
        }

        public async Task<Videos> UpdateVideoAsync(int id, Videos video)
        {
            var existingVideo = await _videoRepository.GetByIdAsync(id);
            if (existingVideo == null)
            {
                throw new VideoNotFoundException();
            }

            existingVideo.Title = video.Title;
            existingVideo.Genre = video.Genre;
            existingVideo.VideoFormat = video.VideoFormat;
            existingVideo.Price = video.Price;
            existingVideo.Availability = video.Availability;
            existingVideo.Description = video.Description;
            existingVideo.PublisherId = video.PublisherId;

            await _videoRepository.SaveChangesAsync();
            return existingVideo;
        }
    }
}
