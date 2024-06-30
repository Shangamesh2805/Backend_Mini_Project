using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Services.Interfaces;
using VideoStoreManagmentAPI.Models.DTOs.FeedBackDTOs;

namespace VideoStoreManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FeedBackController : ControllerBase
    {
        private readonly IFeedBackService _feedbackService;

        public FeedBackController(IFeedBackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [HttpPost("/Add_FeedBack")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<FeedBack>> Add(FeedbackDTO feedbackDto)
        {
            try
            {
                
                var feedback = new FeedBack
                {
                    Rating = feedbackDto.Rating,
                    Comments = feedbackDto.Comments,
                    UserId = feedbackDto.UserId,
                    VideoId = feedbackDto.VideoId
                };

                await _feedbackService.AddFeedback(feedback);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (ServiceException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("/FeedBacks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<FeedBack>>> GetAll()
        {
            try
            {
                var feedbacks = await _feedbackService.GetAllFeedbacks();
                return Ok(feedbacks);
            }
            catch (ServiceException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
