namespace interworks_assignment.Models.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;

        public DateTime Updated { get; set; } = DateTime.UtcNow;

        public DateTime? Deleted { get; set; } = null;

    }
}
