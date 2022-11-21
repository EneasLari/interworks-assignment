using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Models.DiscountManagement;

namespace interworks_assignment.Repositories
{
    public interface IDiscountTypeRepository:IRepository<DiscountType>
    {
        public void DeleteDiscountType(int id);
    }
}
