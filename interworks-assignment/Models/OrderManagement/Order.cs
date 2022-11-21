using interworks_assignment.Models.Base;
using interworks_assignment.Models.CustomerManagement;

namespace interworks_assignment.Models.OrderManagement
{
    public class Order:BaseEntity
    {
        public Order() {
            //this.IntialPrice = neworder.IntialPrice;
            //this.CustomerId = neworder.CustomerId;
            //this.Finalprice = -1;
        }

        public Order(NewOrderDto newOrder)
        {
            this.IntialPrice = newOrder.IntialPrice;
            this.CustomerId = newOrder.CustomerId;
            this.Finalprice = -1;
        }
        public float IntialPrice { get; set; }
        public float Finalprice { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
