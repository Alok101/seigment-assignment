using System.Text.Json.Serialization;

namespace Data.Contracts.Models
{
    public class UserLoginDetails
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
