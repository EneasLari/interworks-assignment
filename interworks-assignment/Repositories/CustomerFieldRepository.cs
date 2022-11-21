using interworks_assignment.Data;
using interworks_assignment.Models.CustomerFieldsManagement;
using interworks_assignment.Repositories.Interfaces;

namespace interworks_assignment.Repositories
{
    public class CustomerFieldRepository : Repository<CustomerField>, ICustomerFieldRepository
    {
        public CustomerFieldRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public void CreateNewCustomerField(NewCustomerFieldDto newCustomer)
        {
            CustomerField customerField = new CustomerField(newCustomer);
            Create(customerField);
        }

        public void DeleteCustomerField(int id)
        {
            CustomerField CustomerField = GetById(id);
            Delete(CustomerField);
        }
    }
}
