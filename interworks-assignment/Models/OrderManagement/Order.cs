using interworks_assignment.Models.Base;
using interworks_assignment.Models.CustomerManagement;

namespace interworks_assignment.Models.OrderManagement
{
    public class Order:BaseEntity
    {
        public float IntialPrice { get; set; }
        public float Finalprice { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }
    }
}
