using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Models.OrderManagement;

namespace interworks_assignment.Repositories
{
    public interface IOrderRepository:IRepository<Order>
    {

        public void DeleteOrder(int id);
    }
}
