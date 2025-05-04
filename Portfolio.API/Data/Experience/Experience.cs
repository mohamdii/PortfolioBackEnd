namespace Portfolio.API.Data.Experience
{
    public class Experience
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; } // Foreign key to IdentityUser
        public Company Company { get; set; }  // Navigation property
        public Employee Employee { get; set; } // Navigation property
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string JobTitle { get; set; }
        public List<string> Description { get; set; } = null!;
    }
}
