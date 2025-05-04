using Microsoft.AspNetCore.Mvc;
using Portfolio.API.BaseRepositoy.Interfaces;
using Portfolio.API.Data.Experience;
using Portfolio.API.DTO;
using Portfolio.API.Mappers;
namespace Portfolio.API.Controllers;



[Route("/experience")]
[ApiController]
public class ExperienceController : ControllerBase
{
    private readonly IBaseRepository<Experience> _baseRepositoy;
    public ExperienceController(IBaseRepository<Experience> baseRepository)
    {
        _baseRepositoy = baseRepository;
    }
    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetExperienceByIdAsync([FromQuery] int id)
    {
        List<Experience> experiences = new List<Experience>();
        var experience = await _baseRepositoy.FindByConditionAsync(e => e.EmployeeId == id, c => c.Company, e => e.Employee);
        if (experience is not null)
        {
            foreach (var exp in experience)
            {
                experiences.Add(exp.ToAddExperienceDTO());
            }
            return Ok(experiences);
        }
        return NotFound("Experience not found");
    }

    [HttpPost("remove-experience")]
    public IActionResult RemoveExperience([FromBody] int id)
    {
        var find = _baseRepositoy.RemoveById(e => e.Id == id);
        if (!find)
        {
            return BadRequest("Experience Cant Be empty");
        }
        return Ok(new { Message = "Success" });
    }
    
    [HttpPost("add-experience")]
    public IActionResult AddExperience([FromBody] AddExperienceDTO obj)
    {
        if (obj == null)
        {
            return BadRequest("Experience Cant Be empty");
        }
        var experience = obj.ToAddExperienceDTO();
        var find = _baseRepositoy.Add(experience);
        return Ok(new { obj });
    }
}
