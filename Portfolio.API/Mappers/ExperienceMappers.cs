using Microsoft.IdentityModel.Protocols;
using Portfolio.API.Data.Experience;
using Portfolio.API.DTO;
using System.Runtime.CompilerServices;

namespace Portfolio.API.Mappers
{
    public static class ExperienceMappers
    {
        public static ExperienceDTO ToExperienceDTO(this Experience experienceModel)
        {
            return new ExperienceDTO
            {
                Id = experienceModel.Id,
                CompanyId = experienceModel.CompanyId,
                StartDate = experienceModel.StartDate,
                EndDate = experienceModel.EndDate,
                JobTitle = experienceModel.JobTitle,
                CompanyName = experienceModel.Company?.Name
            };
        }
        public static Experience ToAddExperienceDTO(this Experience dto)
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
