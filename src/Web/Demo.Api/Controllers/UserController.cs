using Demo.Application.Common.Dtos;
using Demo.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }


        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] UserRegisterationDto userRegisterationDto)
        {
            var result = await _userService.SaveUser(userRegisterationDto);
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteUser(id);
            return Ok(result);
        }
    }
}
