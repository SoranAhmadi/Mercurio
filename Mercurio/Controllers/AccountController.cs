using Application.DTOs.Category;
using Application.DTOs.ContactComment;
using Application.DTOs.Users;
using Application.IServices;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Mercurio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDTO userCreateDTO)
        {
            if (ModelState.IsValid)
            {
                await _userService.Create(userCreateDTO);
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthenticateDTO authenticateDTO)
        {
            var result = await _userService.Autonticate(authenticateDTO);
            if (string.IsNullOrEmpty(result))
                return BadRequest("The username or Password is incorrect");
            return Ok(result);
        }
    }
}