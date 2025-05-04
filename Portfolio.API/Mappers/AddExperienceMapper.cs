using Portfolio.API.Data.Experience;
using Portfolio.API.DTO;

namespace Portfolio.API.Mappers
{
    public static class AddExperienceMapper
    {
        public static Experience ToAddExperienceDTO(this AddExperienceDTO dto)
        {
            return new Experience
            {
                CompanyId = dto.CompanyId,
                EmployeeId = dto.EmployeeId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                JobTitle = dto.JobTitle,
                Description = dto.Description,
                Company = null!, // Assuming you will set this later
                Employee = null! // Assuming you will set this later
            };

        }
    }
}
