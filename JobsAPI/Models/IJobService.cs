using System.Collections.Generic;

namespace JobsAPI.Models
{
    public interface IJobService
    {
        List<Job> GetAllJobs();

        Job GetJobById(int id);

        void DeleteJob(int id);

        void CreateJob(Job job);

        void UpdateJob(Job job);
    }
}
