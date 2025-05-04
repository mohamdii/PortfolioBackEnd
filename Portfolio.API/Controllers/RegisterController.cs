using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.API.BaseRepositoy.Interfaces;
using Portfolio.API.Data;
using Portfolio.API.Data.Experience;
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
        private readonly IBaseRepository<Employee> _baseRepository;
        public RegisterController( UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IBaseRepository<Employee> baseRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _baseRepository = baseRepository;
        }

        
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = new Employee
            {
                Name = model.UserName,
            };

            var employeeAdded = _baseRepository.Add(employee);

            if(employeeAdded is null)
            {
                return BadRequest("Failed to create employee record");
            }

            var user = new ApplicationUser  { UserName = model.UserName, Email = model.Email, EmployeeId = employee.Id };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                _baseRepository.Add(new Employee
                {
                    Name = model.UserName
                });
                return Ok(new { Message = "User registered Successfully"});
            }

            return BadRequest(result.Errors);
        }
    }
}
