using interworks_assignment.Data;
using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Models.DiscountManagement;
using interworks_assignment.Repositories.Interfaces;

namespace interworks_assignment.Repositories
{
    public class DiscountTypeTemplateRepository : Repository<DiscountTypeTemplate>, IDiscountTypeTemplateRepository
    {
        public DiscountTypeTemplateRepository(DataContext dataContext) : base(dataContext)
        {

        }
        public void DeleteDiscountTypeTemplate(int id)
        {
            DiscountTypeTemplate discounttypetemplate = GetById(id);
            Delete(discounttypetemplate);
        }
    }
}
