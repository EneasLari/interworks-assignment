using interworks_assignment.Data;

namespace interworks_assignment.Repositories
{
    
    public class RepositoryManager : IRepositoryManager
    {
        private DataContext _dataContext;
        private IUserRepository _userRepository;
        private ICustomerRepository _customerRepository;
        private IDiscountRepository _discountRepository;
        private IDiscountTypeRepository _discountTypeRepository;
        private IOrderRepository _orderRepository;
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

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}
