﻿
using global::VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs.VideoDTOs;

namespace VideoStoreManagmentAPI.Services
{
    public interface IVideoService
    {

        Task<List<VideoDTO>> GetAllVideos();
        Task<VideoDTO> GetVideoById(int id);
        Task AddVideo(VideoDTO videoDto, int publisherId);
        Task UpdateVideo(int id, VideoDTO videoDto);
        Task DeleteVideo(int id);
    }
 }
