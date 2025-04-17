using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Portfolio.API.BaseRepositoy.Interfaces;
using Portfolio.API.Data.Experience;
using Portfolio.API.DbContext;
using Portfolio.API.Model;
using Portfolio.API.Services;
namespace Portfolio.API.Controllers;

[Route("Experience")]

[ApiController]
public class ExperienceController : ControllerBase
{
    private readonly IBaseRepository<Employee> _baseRepositoy;
    public ExperienceController(IBaseRepository<Employee> baseRepository)
    {
        _baseRepositoy = baseRepository;
    }
    [HttpPost]
    public IActionResult Post([FromBody] Employee obj)
    {
        if (obj == null)
        {
            return BadRequest("Employee Cant Be empty");
        }
        var find = _baseRepositoy.AddEmployee(obj);
        return Ok(new { obj });

    }

    [HttpGet]
    public async Task<IActionResult> GetExperienceAsync()
    {
        var experiences = await _baseRepositoy.FindAllAsync();
        if (experiences.Count() > 0)
            return Ok(experiences);

        return Ok("No experiences found");

    }
}
