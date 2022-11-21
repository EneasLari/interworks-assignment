namespace interworks_assignment.Repositories
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }

        ICustomerRepository Customer { get; }

        IDiscountRepository Discount { get; }

        IDiscountTypeRepository DiscountType { get; }

        IOrderRepository Order { get; }
        void Save();
    }
}
