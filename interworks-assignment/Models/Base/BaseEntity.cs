using System.Text.Json.Serialization;

namespace interworks_assignment.Models.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [JsonIgnore]
        public DateTime Created { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public DateTime Updated { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public DateTime? Deleted { get; set; } = null;

    }
}
