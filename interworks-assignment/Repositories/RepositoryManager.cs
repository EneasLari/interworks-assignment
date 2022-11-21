using interworks_assignment.Data;
using interworks_assignment.Repositories.Interfaces;

namespace interworks_assignment.Repositories
{

    public class RepositoryManager : IRepositoryManager
    {
        private DataContext _dataContext;
        private IUserRepository _userRepository;
        private ICustomerRepository _customerRepository;
        private IDiscountRepository _discountRepository;
        private IDiscountTypeRepository _discountTypeRepository;
        private IDiscountTypeTemplateRepository _discountTypeTemplateRepository;
        private IOrderRepository _orderRepository;
        private IFieldRepository _fieldRepository;
        private ICustomerFieldRepository _customerFieldRepository;
        public RepositoryManager(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IUserRepository User
        {
            get {
                if (_userRepository == null) {
                    _userRepository = new UserRepository(_dataContext);
                }
                return _userRepository;
            }
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_dataContext);
                }
                return _customerRepository;
            }
        }

        public IDiscountRepository Discount
        {
            get
            {
                if (_discountRepository == null)
                {
                    _discountRepository = new DiscountRepository(_dataContext);
                }
                return _discountRepository;
            }
        }

        public IDiscountTypeRepository DiscountType
        {
            get
            {
                if (_discountTypeRepository == null)
                {
                    _discountTypeRepository = new DiscountTypeRepository(_dataContext);
                }
                return _discountTypeRepository;
            }
        }

        public IDiscountTypeTemplateRepository DiscountTypeTemplate
        {
            get
            {
                if (_discountTypeTemplateRepository == null)
                {
                    _discountTypeTemplateRepository = new DiscountTypeTemplateRepository(_dataContext);
                }
                return _discountTypeTemplateRepository;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_dataContext);
                }
                return _orderRepository;
            }
        }

        public IFieldRepository Field
        {
            get
            {
                if (_fieldRepository == null)
                {
                    _fieldRepository = new FieldRepository(_dataContext);
                }
                return _fieldRepository;
            }
        }

        public ICustomerFieldRepository CustomerField
        {
            get
            {
                if (_customerFieldRepository == null)
                {
                    _customerFieldRepository = new CustomerFieldRepository(_dataContext);
                }
                return _customerFieldRepository;
            }
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}
