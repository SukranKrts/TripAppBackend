using Microsoft.AspNetCore.Mvc;
using TripApplication.Data.DTO.FollowDTO;
using TripApplication.Services;

namespace TripApplication.Controllers
{
    public class FollowControllers: ControllerBase
    {
        private readonly FollowService _follow;

        public FollowControllers(FollowService follow)
        {
            _follow = follow;
        }

        [HttpPost]
        [Route("CreateFollow")]
        public async Task<IActionResult> CreateFollow([FromBody] FollowInfoDTO follow)
        {
            return Ok(await _follow.CreateFollow(follow));
        }
    }
}
