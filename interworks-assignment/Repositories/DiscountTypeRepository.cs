using interworks_assignment.Data;
using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Models.DiscountManagement;

namespace interworks_assignment.Repositories
{
    public class DiscountTypeRepository : Repository<DiscountType>, IDiscountTypeRepository
    {
        public DiscountTypeRepository(DataContext dataContext) : base(dataContext)
        {

        }
        public void DeleteDiscountType(int id)
        {
            DiscountType discounttype = GetById(id);
            Delete(discounttype);
        }
    }
}
