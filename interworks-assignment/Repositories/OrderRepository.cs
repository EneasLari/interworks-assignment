using interworks_assignment.Data;
using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Models.DiscountManagement;
using interworks_assignment.Models.OrderManagement;

namespace interworks_assignment.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DataContext dataContext) : base(dataContext)
        {

        }
        public void DeleteOrder(int id)
        {
            Order order = GetById(id);
            Delete(order);
        }
    }
}
