using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Models.DiscountManagement;

namespace interworks_assignment.Repositories.Interfaces
{
    public interface IDiscountTypeTemplateRepository : IRepository<DiscountTypeTemplate>
    {
        public void DeleteDiscountTypeTemplate(int id);
    }
}
