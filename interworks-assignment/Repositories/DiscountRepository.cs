using interworks_assignment.Data;
using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Models.DiscountManagement;
using interworks_assignment.Repositories.Interfaces;

namespace interworks_assignment.Repositories
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository(DataContext dataContext) : base(dataContext)
        {

        }
        public void DeleteDiscount(int id)
        {
            Discount discount = GetById(id);
            Delete(discount);
        }
    }
}
