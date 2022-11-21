using interworks_assignment.Models.CustomerManagement;

namespace interworks_assignment.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {

        public void DeleteCustomer(int id);
    }
}
