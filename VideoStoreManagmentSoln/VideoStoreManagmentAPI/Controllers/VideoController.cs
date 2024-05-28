using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Services;

namespace VideoStoreManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        // Accessible by all users
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Videos>>> GetAll()
        {
            return Ok(await _videoService.GetAllVideosAsync());
        }

        // Accessible by all users
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Videos>> GetById(int id)
        {
            var video = await _videoService.GetVideoByIdAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            return Ok(video);
        }

        // Accessible only by publishers
        [HttpPost]
        [Authorize(Policy = "RequirePublisherRole")]
        public async Task<ActionResult<Videos>> Add(Videos video)
        {
            var createdVideo = await _videoService.AddVideoAsync(video);
            return CreatedAtAction(nameof(GetById), new { id = createdVideo.VideoId }, createdVideo);
        }

        // Accessible only by publishers
        [HttpDelete("{id}")]
        [Authorize(Policy = "RequirePublisherRole")]
        public async Task<ActionResult<Videos>> Delete(int id)
        {
            var video = await _videoService.DeleteVideoAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            return Ok(video);
        }

        // Accessible only by publishers
        [HttpPut("{id}")]
        [Authorize(Policy = "RequirePublisherRole")]
        public async Task<ActionResult<Videos>> Update(int id, Videos video)
        {
            var updatedVideo = await _videoService.UpdateVideoAsync(id, video);
            if (updatedVideo == null)
            {
                return NotFound();
            }
            return Ok(updatedVideo);
        }
    }
}