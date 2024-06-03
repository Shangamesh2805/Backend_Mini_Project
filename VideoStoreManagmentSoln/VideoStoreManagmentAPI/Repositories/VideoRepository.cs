// VideoRepository.cs

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs;
using VideoStoreManagmentAPI.Repositories.Interfaces;

namespace VideoStoreManagmentAPI.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly VideoStoreManagementContext _context;

        public VideoRepository(VideoStoreManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Videos>> GetAllVideos()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task<Videos> GetVideoById(int id)
        {
            return await _context.Videos.FindAsync(id);
        }

        public async Task AddVideo(VideoDTO videoDto, int publisherId)
        {
            var video = new Videos
            {
                Title = videoDto.Title,
                Description = videoDto.Description,
                Genre = videoDto.Genre,
                Availability = videoDto.Availability,
                VideoFormat = videoDto.VideoFormat,
                Price = videoDto.Price,
                VideoCount = videoDto.VideoCount,
                PublisherId = publisherId
            };

            _context.Videos.Add(video);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVideo(VideoDTO videoDto)
        {
            var video = await _context.Videos.FindAsync(videoDto.VideoId);
            if (video != null)
            {
                video.Title = videoDto.Title;
                video.Description = videoDto.Description;
                video.Genre = videoDto.Genre;
                video.Availability = videoDto.Availability;
                video.VideoFormat = videoDto.VideoFormat;
                video.Price = videoDto.Price;
                video.VideoCount = videoDto.VideoCount;

                _context.Videos.Update(video);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteVideo(int id)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video != null)
            {
                _context.Videos.Remove(video);
                await _context.SaveChangesAsync();
            }
        }
    }
}
