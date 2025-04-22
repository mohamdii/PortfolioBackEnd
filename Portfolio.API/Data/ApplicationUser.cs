using Microsoft.AspNetCore.Identity;
using Portfolio.API.Data.Experience;

namespace Portfolio.API.Data
{
    public class ApplicationUser: IdentityUser
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
