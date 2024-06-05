<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs;
using VideoStoreManagmentAPI.Repositories;
using VideoStoreManagmentAPI.Repositories.Interfaces;
using VideoStoreManagmentAPI.Services.Interfaces;
<<<<<<< HEAD
=======
=======
﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74

namespace VideoStoreManagmentAPI.Services
{
    public class VideoService : IVideoService
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
        private readonly IVideoRepository _videoRepository;
        private readonly IUserRepository _userRepository;
        public VideoService(IVideoRepository videoRepository, IUserRepository userRepository)
        {
            _videoRepository = videoRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Videos>> GetAllVideos()
        {
            try
            {
                return await _videoRepository.GetAllVideos();
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error occurred while getting all videos", ex);
            }
        }

        public async Task<Videos> GetVideoById(int id)
        {
            try
            {
                return await _videoRepository.GetVideoById(id);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error occurred while getting video by Id", ex);
            }
        }

        public async Task AddVideo(VideoDTO videoDto, int publisherId)
        {
            if (!await IsUserPublisher(publisherId))
            {
                throw new ServiceAccessException("Only users with the Publisher role can add videos.");
            }
            try
            {
                await _videoRepository.AddVideo(videoDto, publisherId);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error occurred while adding video", ex);
            }
        }

        public async Task UpdateVideo(int id, VideoDTO videoDto)
        {

            try
            {
                await _videoRepository.UpdateVideo(videoDto);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error occurred while updating video", ex);
            }
        }

        public async Task DeleteVideo(int id)
        {
            try
            {
                await _videoRepository.DeleteVideo(id);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error occurred while deleting video", ex);
            }
        }
        private async Task<bool> IsUserPublisher(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            return user != null && user.Role == Role.Publisher;
        }
    }

<<<<<<< HEAD
=======
=======
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
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
}
