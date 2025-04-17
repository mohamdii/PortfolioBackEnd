using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data.Experience;

namespace Portfolio.API.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Experience>()
                .HasData(new Experience
                {
                    Id = 1,
                    CompanyId = 1,
                    StartDate = new DateTime(2020, 1, 1),
                    EndDate = new DateTime(2022, 12, 31),
                    JobTitle = "Software Engineer"
                });
            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = 1,
                Name = "Tech Corp",
                Address = "123 Software Street"
            });
        }
    }
}