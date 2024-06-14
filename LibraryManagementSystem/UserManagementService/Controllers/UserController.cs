using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace UserManagementService.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet]
        public async Task<IActionResult> GetUserName([FromQuery] string userName)
        {
            //if (!ModelState.IsValid)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            //}
            userName = "API Name";
            var data = await _userService.GetUsername(userName);
            return Ok(data);
        }
    }
}
