using interworks_assignment.Models.Base;

namespace interworks_assignment.Models.CustomerManagement
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;


        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public string Phone { get; set; } = String.Empty;
    }
}
