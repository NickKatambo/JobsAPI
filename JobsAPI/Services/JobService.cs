using JobsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Service
{
    public class JobService : IJobService
    {
        private readonly AppDbContext _context;

        public JobService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateJob(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }

        public void DeleteJob(int id)
        {
            Job job = _context.Jobs.FirstOrDefault(x => x.Id == id);
            if (job != null)
            {
                _context.Remove(job);
            }
        }

        public List<Job> GetAllJobs()
        {
            return _context.Jobs.ToList();
        }

        public Job GetJobById(int id)
        {
            return _context.Jobs.Find(id);
        }

        public void UpdateJob(Job job)
        {
            var jobChanges = _context.Jobs.Attach(job);
            jobChanges.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
