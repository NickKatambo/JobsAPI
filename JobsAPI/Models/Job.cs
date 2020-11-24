using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Salary { get; set; }
        public string StartDate { get; set; }
        public string RequiredSkills { get; set; }
        public string DegreeRequirements { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Location { get; set; }
    }
}
