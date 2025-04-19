using Microsoft.AspNetCore.Identity;

namespace Portfolio.API.Data.Experience
{
    public class Employee : IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Experience> Experiences { get; set; }
    }
}
