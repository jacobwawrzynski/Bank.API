using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ActionResult> Get(string id)
        {
            return Ok();
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(Register register)
        {
            var user = new User()
            {
                Email = register.Email,
                PasswordHash = register.Password,
                UserName = $"{register.Forename} {register.Surname}",
                PhoneNumber = register.Phone,
                Address = register.Address,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
            };
            var result = await _userManager.CreateAsync(user, user.PasswordHash);
            return result.Succeeded ?
                CreatedAtAction(nameof(Get), new { id = user.Id }, user) :
                BadRequest(result);
        }
    }
}
