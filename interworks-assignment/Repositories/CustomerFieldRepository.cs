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

        public void CreateNewCustomerField(NewCustomerFieldDto newCustomerfield)
        {
            CustomerField customerField = new CustomerField(newCustomerfield);
            Create(customerField);
        }

        //Creates new entry but updates the version so we can track history of a customer's filds
        public void UpdateCustomerField(UpdateCustomerFieldDto customerfield)
        {
            CustomerField customerfieldExisting = GetHistoryByGuid(customerfield.Guid).OrderBy(x=>x.Version).LastOrDefault();
            if (customerfield == null) { 
                return;
            }
            customerfieldExisting.CustomerId=customerfield.CustomerId;
            customerfieldExisting.FieldId=customerfield.FieldId;
            customerfieldExisting.Updated=DateTime.Now;
            customerfieldExisting.Version++;
            customerfieldExisting.Id = 0;
            Create(customerfieldExisting);
        }

        public IEnumerable<CustomerField> GetHistoryByGuid(string guid) { 
            List<CustomerField> history = _dbSet.Where(x => x.Guid == guid).ToList();
            return history;
        }

        public void DeleteCustomerField(int id)
        {
            CustomerField CustomerField = GetById(id);
            Delete(CustomerField);
        }
    }
}
