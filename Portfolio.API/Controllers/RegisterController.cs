using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Data;
using Portfolio.API.Model;
using Portfolio.API.Services;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("Api/Register")]
    public class RegisterController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtService _jwtService;

        public RegisterController(JwtService jwtService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
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

            var user = new ApplicationUser  { UserName = model.UserName, Email = model.Email, EmployeeId = 1 };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {

                return Ok(new { Message = "User registered Successfully"});
            }

            return BadRequest(result.Errors);
        }
    }
}
