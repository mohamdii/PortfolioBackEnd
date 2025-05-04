namespace Portfolio.API.DTO
{
    public class AddExperienceDTO
    {
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string JobTitle { get; set; }
        public List<string> Description { get; set; }
    }
}
