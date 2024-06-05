using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs;
using VideoStoreManagmentAPI.Repositories;
using VideoStoreManagmentAPI.Repositories.Interfaces;
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI.Services
{
    public class VideoService : IVideoService
    {
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

}
