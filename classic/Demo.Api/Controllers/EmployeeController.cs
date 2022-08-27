using Demo.Api.Data;
using Demo.Api.Models;
using Demo.Api.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext context;

        public EmployeeController(EmployeeContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRegisterDto user)
        {
            var response = new SaveResponse();

            var userModel = new User()
            {
                Address = user.Address,
                CreatedName = DateTime.UtcNow,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActive = true,
                Password = user.Password
            };

            context.User.Add(userModel);

            await context.SaveChangesAsync();

            response.IsSuccess = true;
            response.Message = "Use created succesfully.";

            return Ok(response);
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var user = context.User.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound(new SaveResponse() { IsSuccess = false, Message = "User not found" });
            }

            var userDto = new UserDto()
            {
                Id = user.Id,
                Address = user.Address,
                CreatedDate = DateTime.UtcNow,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActive = user.IsActive,
            };

            return Ok(userDto);
        }


        [HttpGet]

        public IActionResult Get()
        {
            var response = new List<UserDto>();

            var users = context.User.ToList();


            foreach (var user in users)
            {
                var userDto = new UserDto()
                {
                    Id = user.Id,
                    Address = user.Address,
                    CreatedDate = DateTime.UtcNow,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsActive = user.IsActive,
                };

                response.Add(userDto);
            }


            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserDto user)
        {
            var response = new SaveResponse();

            var userModel = context.User.FirstOrDefault(x => x.Id == user.Id);

            userModel.FirstName = user.FirstName;
            userModel.LastName = user.LastName;
            userModel.Address = user.Address;

            context.Update(userModel);

            await context.SaveChangesAsync();

            response.IsSuccess = true;
            response.Message = "User Updated succesfully.";

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new SaveResponse();

            var user = context.User.FirstOrDefault(x => x.Id == id);

            context.Remove(user);

            await context.SaveChangesAsync();

            response.IsSuccess = true;
            response.Message = "User Deleted succesfully.";

            return Ok(response);

        }
    }
}
