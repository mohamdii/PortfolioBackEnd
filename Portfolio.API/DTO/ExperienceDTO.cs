using Microsoft.AspNetCore.Authorization;
using Portfolio.API.Data.Experience;

namespace Portfolio.API.DTO
{
    public class ExperienceDTO
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int EmployeeId { get; set; } // Foreign key to IdentityUser
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string JobTitle { get; set; }


    }
}
