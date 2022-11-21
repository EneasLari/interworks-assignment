namespace interworks_assignment.Repositories.Interfaces
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }

        ICustomerRepository Customer { get; }

        IDiscountRepository Discount { get; }

        IDiscountTypeRepository DiscountType { get; }

        IDiscountTypeTemplateRepository DiscountTypeTemplate { get; }

        IOrderRepository Order { get; }

        IFieldRepository Field { get; }

        ICustomerFieldRepository CustomerField { get; }
        void Save();
    }
}
