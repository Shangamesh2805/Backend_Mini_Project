using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs.VideoDTOs;
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

        /// <summary>
        /// Retrieves all videos.
        /// </summary>
        /// <returns>A list of videos.</returns>
        /// <exception cref="ServiceException">Thrown when an error occurs while getting all videos.</exception>


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

        /// <summary>
        /// Retrieves a video by its ID.
        /// </summary>
        /// <param name="id">The ID of the video.</param>
        /// <returns>The video with the specified ID.</returns>
        /// <exception cref="ServiceException">Thrown when an error occurs while getting the video by ID.</exception>


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

        /// <summary>
        /// Adds a new video.
        /// </summary>
        /// <param name="videoDto">The video data transfer object.</param>
        /// <param name="publisherId">The ID of the publisher.</param>
        /// <exception cref="ServiceAccessException">Thrown when the user is not a publisher.</exception>
        /// <exception cref="ServiceException">Thrown when an error occurs while adding the video.</exception>


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
        /// <summary>
        /// Updates an existing video.
        /// </summary>
        /// <param name="id">The ID of the video to update.</param>
        /// <param name="videoDto">The video data transfer object.</param>
        /// <exception cref="ServiceException">Thrown when an error occurs while updating the video.</exception>



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
        /// <summary>
        /// Deletes a video by its ID.
        /// </summary>
        /// <param name="id">The ID of the video to delete.</param>
        /// <exception cref="ServiceException">Thrown when an error occurs while deleting the video.</exception>

        private async Task<bool> IsUserPublisher(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            return user != null && user.Role == Role.Publisher;
        }

        /// <summary>
        /// Checks if the user is a publisher.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>True if the user is a publisher; otherwise, false.</returns>
    }

}
