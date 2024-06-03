<<<<<<< HEAD
﻿// VideoRepository.cs

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs;
=======
﻿using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
using VideoStoreManagmentAPI.Repositories.Interfaces;

namespace VideoStoreManagmentAPI.Repositories
{
<<<<<<< HEAD
    public class VideoRepository : IVideoRepository
=======
    public class VideoRepository : IRepository<int, Videos>
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
    {
        private readonly VideoStoreManagementContext _context;

        public VideoRepository(VideoStoreManagementContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
        public async Task<List<Videos>> GetAllVideos()
=======
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
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
        {
            return await _context.Videos.ToListAsync();
        }

<<<<<<< HEAD
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
=======
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
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
        }
    }
}
