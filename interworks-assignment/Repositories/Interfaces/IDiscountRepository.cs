using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Models.DiscountManagement;

namespace interworks_assignment.Repositories.Interfaces
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        public IEnumerable<Discount> GetDiscountsByOrderId(int orderId);
        public void DeleteDiscount(int id);
    }
}
