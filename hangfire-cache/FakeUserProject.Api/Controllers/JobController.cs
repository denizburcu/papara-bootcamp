using FakeUserProject.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace FakeUserProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IRecurringUserFakeJob _recurringUserFakeJob;

        public JobController(IRecurringUserFakeJob recurringUserFakeJob)
        {
            _recurringUserFakeJob = recurringUserFakeJob;
        }
        // we start job by calling this api
        [HttpGet("/trigger")]
        public IActionResult RetriveFakeUserData()
        {
            _recurringUserFakeJob.TriggerRetrieveRecurringJob();
            return Ok("Retrieving data Job 5 seconds started");
        }

    }

}