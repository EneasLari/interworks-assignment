using interworks_assignment.Models.CustomerFieldsManagement;
using interworks_assignment.Models.OrderManagement;

namespace interworks_assignment.Repositories.Interfaces
{
    public interface IFieldRepository : IRepository<Field>
    {
        public void DeleteField(int id);
    }
}
