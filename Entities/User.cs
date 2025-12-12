using System.Text.Json.Serialization;

namespace TeamTasker.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [JsonIgnore]
        public List<JobTask> JobTasks { get; set; } = new();
    }
}