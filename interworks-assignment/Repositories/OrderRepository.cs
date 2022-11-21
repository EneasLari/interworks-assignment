using interworks_assignment.Data;
using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Models.DiscountManagement;
using interworks_assignment.Models.OrderManagement;
using interworks_assignment.Repositories.Interfaces;

namespace interworks_assignment.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public void CreateNewOrder(NewOrderDto newOrder) {
            Order order =new Order(newOrder);
            Create(order);
        }
        public void DeleteOrder(int id)
        {
            Order order = GetById(id);
            Delete(order);
        }
    }
}
