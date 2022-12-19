using FakeUserProject.Service.Contract;
using FakeUserProject.Service.Models;
using Hangfire;
using Newtonsoft.Json;

namespace FakeUserProject.Service.Concrete
{
    public class RecurringUserFakeJob : IRecurringUserFakeJob
    {
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IUserService _userService;

        public RecurringUserFakeJob(IRecurringJobManager recurringJobManager, IUserService userService)
        {
            _recurringJobManager = recurringJobManager;
            _userService = userService;
        }

        //trigger recurring job, running every 5 seconds
        public void TriggerRetrieveRecurringJob()
        {
            _recurringJobManager.AddOrUpdate("JobI-213", () => RetrieveUserFakeDataAndSave(), "*/5 * * * * *");
        }

        //Retrieves user data from api and save it to database
        public async Task RetrieveUserFakeDataAndSave()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
                if (result != null)
                {
                    var userDtoList = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(result);
                    foreach (var userDto in userDtoList)
                    {
                        await _userService.AddUserAsync(userDto);
                    }
                }
            }
        }
    }
}