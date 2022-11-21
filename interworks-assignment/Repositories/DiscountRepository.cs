using interworks_assignment.Data;
using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Models.DiscountManagement;
using interworks_assignment.Repositories.Interfaces;
using System;

namespace interworks_assignment.Repositories
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public IEnumerable<Discount> GetDiscountsByOrderId(int orderId) {
            List<Discount> discounts = _dbSet.Where(x => x.OrderId == orderId).ToList();
            return discounts;
        }
        public void DeleteDiscount(int id)
        {
            Discount discount = GetById(id);
            Delete(discount);
        }
    }
}
