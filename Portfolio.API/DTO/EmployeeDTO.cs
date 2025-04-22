using Portfolio.API.Data.Experience;

namespace Portfolio.API.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Experience>? Experiences { get; set; }
    }
}
