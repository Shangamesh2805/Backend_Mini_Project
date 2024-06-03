using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs;
using VideoStoreManagmentAPI.Services;
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        // Accessible by all users
        [HttpGet("Get_AllVideos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Videos>>> GetAll()
        {
            try
            {
                var videos = await _videoService.GetAllVideos();
                return Ok(videos);
            }
            catch (ServiceException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // Accessible by all users
        [HttpGet("{id}/Get_Video")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<Videos>> GetById(int id)
        {
            try
            {
                var video = await _videoService.GetVideoById(id);
                if (video == null)
                {
                    return NotFound();
                }
                return Ok(video);
            }
            catch (ServiceException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // Accessible only by publishers
        [HttpPost("Add_Video")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Policy = "RequirePublisherRole")]
        public async Task<ActionResult<Videos>> Add(VideoDTO videoDto, int publisherId)
        {
            try
            {
                
                await _videoService.AddVideo(videoDto, publisherId);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (ServiceException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // Accessible only by publishers
        [HttpDelete("{id}/Delete_Video")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Policy = "RequirePublisherRole")]
        public async Task<ActionResult<Videos>> Delete(int id)
        {
            try
            {
                await _videoService.DeleteVideo(id);
                return Ok();
            }
            catch (ServiceException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // Accessible only by publishers
        [HttpPut("{id}/Update_Video")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Policy = "RequirePublisherRole")]
        public async Task<ActionResult<Videos>> Update(int id, VideoDTO videoDto)
        {
            try
            {
                await _videoService.UpdateVideo(id, videoDto);
                return Ok();
            }
            catch (ServiceException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
