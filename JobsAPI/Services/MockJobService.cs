using JobsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Service
{
    public class MockJobService : IJobService
    {
        private List<Job> _jobs { get; set; }

        public MockJobService()
        {
            _jobs = new List<Job>()
            {
                new Job
                {
                    Id = 1,
                    Title = "Baker",
                    DegreeRequirements = "Culinary Degree or Comparible Experience",
                    ContactNumber = "555-123-1234",
                    RequiredSkills = "5+ years baking experience. Experience running commercial kitchen. Works well under pressure",
                    Description = "As a baker you will be responsible for making pies and reporting to the head chef.",
                    Salary = "45-50k a year depending on experience",
                    StartDate = "Immediate",
                    EmailAddress = "recruitment@baker.com",
                    Location = "London, UK"
                },
                new Job()
                {
                    Id = 2,
                    Title = "HR Specialist",
                    DegreeRequirements = "Business or Communications Degree",
                    ContactNumber = "555-123-1234",
                    RequiredSkills = "Great communication skills, strong sense of ethics, administrative experience.",
                    Description = "As an HR specialist you will be responsible for developing and enforcing HR policies.",
                    Salary = "40-60k depending on experience",
                    StartDate = "Spring 2020",
                    EmailAddress = "info@mail.com",
                    Location ="Lisbon, Portugal"
                },
                new Job()
                {
                    Id = 3,
                    Title = "Marketing Assistant",
                    Description = "Help develop ad campaigns, raise social media awareness, targeted advertising.",
                    Salary = "Negotiable",
                    StartDate = "Summer 2020",
                    RequiredSkills = "Strong social media and design skills a must.",
                    DegreeRequirements = "Marketing, design or similar.",
                    ContactNumber = "555-123-1234",
                    EmailAddress="hr@ma.com",
                    Location="Seattle, United States"
                }
            };
        }

        public void CreateJob(Job job)
        {
            job.Id = _jobs.Max(x => x.Id) + 1;
            _jobs.Add(job);
        }

        public void DeleteJob(int id)
        {
            Job job = _jobs.FirstOrDefault(x => x.Id == id);
            if (job != null)
            {
                _jobs.Remove(job);
            }
        }

        public List<Job> GetAllJobs()
        {
            return _jobs;
        }

        public Job GetJobById(int id)
        {
            return _jobs.Find(x => x.Id == id);
        }

        public void UpdateJob(Job job)
        {
            Job jobChanges = _jobs.FirstOrDefault(x => x.Id == job.Id);
            if (jobChanges != null)
            {
                jobChanges.Title = job.Title;
                jobChanges.Description = job.Description;
                jobChanges.Salary = job.Salary;
                jobChanges.StartDate = job.StartDate;
                jobChanges.RequiredSkills = job.RequiredSkills;
                jobChanges.DegreeRequirements = job.DegreeRequirements;
                jobChanges.ContactNumber = job.ContactNumber;
                jobChanges.EmailAddress = job.EmailAddress;
                jobChanges.Location = job.Location;
            }
        }
    }
}
