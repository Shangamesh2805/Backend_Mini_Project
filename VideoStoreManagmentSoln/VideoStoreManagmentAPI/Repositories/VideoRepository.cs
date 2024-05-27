using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;

namespace VideoStoreManagmentAPI.Repositories
{
    public class VideoRepository : IRepository<int, Videos>
    {
        private readonly VideoStoreManagementContext _context;

        public VideoRepository(VideoStoreManagementContext context)
        {
            _context = context;
        }

        public async Task<Videos> AddAsync(Videos item)
        {
            _context.Videos.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Videos> Delete(int key)
        {
            var item = await GetByIdAsync(key);
            if (item != null)
            {
                _context.Videos.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
            throw new VideoNotFoundException();
        }

        public async Task<IEnumerable<Videos>> GetAllAsync()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task<Videos> GetByIdAsync(int key)
        {
            var video = await GetByIdAsync(key);
            if (video != null)
            {
                return video;
            }
            throw new VideoNotFoundException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<Videos> Update(Videos item)
        {
            var existingVideo = await GetByIdAsync(item.VideoId);
            if (existingVideo == null)
            {
                throw new KeyNotFoundException("Video not found");
            }

            _context.Entry(existingVideo).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return existingVideo;
        }
    }
}
