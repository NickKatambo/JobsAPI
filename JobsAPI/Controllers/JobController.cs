using JobsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Controllers
{
    [Route("[controller]")]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet("/AllJobs")]
        public IActionResult Get()
        {
            return Ok(_jobService.GetAllJobs());
        }

        [HttpGet("/Job/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_jobService.GetJobById(id));
        }

        [HttpDelete("/Job/{id}")]
        public IActionResult DeleteJob(int id)
        {
            _jobService.DeleteJob(id);
            return NoContent();
        }

        [HttpPost("/Job")]
        public IActionResult CreateJob([FromBody]Job newJob)
        {
            _jobService.CreateJob(newJob);
            return Created("job", newJob);
        }

        [HttpPut("/jobs")]
        public IActionResult UpdateJob([FromBody]Job updateJob)
        {
            _jobService.UpdateJob(updateJob);
            return Ok(updateJob);
        }
    }
}
