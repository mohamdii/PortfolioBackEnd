using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Portfolio.API.Data.Experience
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Experience>? Experiences { get; set; }
    }
}
