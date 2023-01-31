using Microsoft.AspNetCore.Mvc;
using TripApplication.Common;
using TripApplication.Data.DTO.TripCommentDTO;
using TripApplication.Data.Entities;
using TripApplication.Services;

namespace TripApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripCommentController: ControllerBase
    {
        private readonly TripCommentsService _tripCommentsService;

        public TripCommentController(TripCommentsService tripCommentsService)
        {
            _tripCommentsService = tripCommentsService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateTripComment([FromBody] CommentInfoDTO comment)
        {
            return Ok(await _tripCommentsService.CreateComment(comment));
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<Result<List<CommentInfoDTO>>> GetComments()
        {
            return await _tripCommentsService.GetCommnet();
        }

    }
}
