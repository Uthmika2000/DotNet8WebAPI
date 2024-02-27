using System.Text.Json.Serialization;

namespace DotNet8WebAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Dob { get; set; }
        public required string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public bool isActive { get; set; }
    }
}
