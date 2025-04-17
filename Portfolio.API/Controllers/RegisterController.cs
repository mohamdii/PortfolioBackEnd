using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Model;
using Portfolio.API.Services;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("Api/Register")]
    public class RegisterController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtService _jwtService;

        public RegisterController(JwtService jwtService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _jwtService = jwtService;
            _userManager = userManager;
            _signInManager = signInManager; 
        }

        
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var token = _jwtService.GenerateToken(user.Id, user.UserName, new List<string> { "Admin" });
                return Ok(new { Message = "User registered Successfully"});
            }

            return BadRequest(result.Errors);
        }
    }
}
