using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Models.OrderManagement;

namespace interworks_assignment.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        public void CreateNewOrder(NewOrderDto newOrder);

        public void SetFinalPriceOfOrder(int orderId);
        public void DeleteOrder(int id);
    }
}
