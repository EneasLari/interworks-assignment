using interworks_assignment.Models.CustomerFieldsManagement;
using interworks_assignment.Models.OrderManagement;

namespace interworks_assignment.Repositories.Interfaces
{
    public interface ICustomerFieldRepository : IRepository<CustomerField>
    {
        public void CreateNewCustomerField(NewCustomerFieldDto newCustomer);
        public void DeleteCustomerField(int id);
    }
}
