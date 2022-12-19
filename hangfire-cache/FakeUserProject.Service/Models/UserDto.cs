using Newtonsoft.Json;

namespace FakeUserProject.Service.Models
{
    public class UserDto
    {
        public int Guid { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public string? UserTitle { get; set; }

        [JsonProperty("body")]
        public string? UserBody { get; set; }

    }
}