using Microsoft.AspNetCore.Mvc;
using TripApplication.Common;
using TripApplication.Data.DTO.UserDTO;
using TripApplication.Data.Entities;
using TripApplication.Services;

namespace TripApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO user)
        {
            return Ok(await _userService.CreateUser(user));
        }

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUser(UserLoginDTO user)
        {
            return Ok(await _userService.LoginUser(user));
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserInfoDTO user)
        {
            return Ok(await _userService.UpdateUser(user));
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return Ok(await _userService.DeleteUser(id));
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<Result<List<UserInfoDTO>>> GetUser()
        {
            return await _userService.GetUser();
        }
    }
}
