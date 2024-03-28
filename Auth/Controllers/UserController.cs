using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        //private readonly ILogger<UserController> _logger;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return Ok(user);
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
                CreatedAtAction(nameof(GetById), new { id = user.Id }, user) :
                BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(
                userName: email,
                password: password,
                isPersistent: false,
                lockoutOnFailure: false
                );
            return result.Succeeded ?
                Ok("User signed in successfully") :
                BadRequest(result);
        }

        [Authorize]
        [HttpPut]       //TODO
        public async Task<ActionResult> Update(string id, User user)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpDelete]    //TODO
        public async Task<ActionResult> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
