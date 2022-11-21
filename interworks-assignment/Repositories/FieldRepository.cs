using interworks_assignment.Data;
using interworks_assignment.Models.CustomerFieldsManagement;
using interworks_assignment.Repositories.Interfaces;

namespace interworks_assignment.Repositories
{
    public class FieldRepository : Repository<Field>, IFieldRepository
    {
        public FieldRepository(DataContext dataContext) : base(dataContext)
        {

        }
        public void DeleteField(int id)
        {
            Field field = GetById(id);
            Delete(field);
        }
    }
}
