﻿
namespace Portfolio.API.Data.Experience
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Experience>? Experiences { get; set; }
    }
}