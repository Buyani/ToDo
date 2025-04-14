
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Dto;
using ToDo.Application.Services.Users.Interfaces;

namespace ToDo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userServvice = userService;

        [HttpPost(Name ="User")]
        public async Task< IActionResult> Post(CreateUserRequest createUserRequest)
        {
            var createUserResults = await _userServvice.CreateUserOrUpdate(createUserRequest);

            if(createUserResults != null)
            {
                return Created();
            }

            return BadRequest();
        }
    }
}
