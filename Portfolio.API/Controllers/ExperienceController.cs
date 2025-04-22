using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Portfolio.API.BaseRepositoy;
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
    private readonly IBaseRepository<Experience> _baseRepositoy;
    public ExperienceController(IBaseRepository<Experience> baseRepository)
    {
        _baseRepositoy = baseRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetExperienceAsync()
    {
        var experiences = await _baseRepositoy.FindAll().Where(e => e.EmployeeId ==1).Include(e => e.Employee).ToListAsync();
        if (experiences.Any())
            return Ok(experiences);

        return Ok("No experiences found");

    }
}
