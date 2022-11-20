namespace interworks_assignment.Repositories
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }

        ICustomerRepository Customer { get; }

        IDiscountRepository Discount { get; }
        void Save();
    }
}
