using interworks_assignment.Data;
using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Repositories.Interfaces;

namespace interworks_assignment.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext dataContext) : base(dataContext)
        {

        }
        public void DeleteCustomer(int id)
        {
            Customer customer = GetById(id);
            Delete(customer);
        }
    }
}
