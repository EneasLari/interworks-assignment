using interworks_assignment.Models.CustomerFieldsManagement;
using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Models.DiscountManagement;
using interworks_assignment.Models.OrderManagement;
using interworks_assignment.Models.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace interworks_assignment.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.UseSerialColumns();
        //}

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<DiscountType> DiscountTypes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Field> Fields { get; set; }

        public DbSet<CustomerField> CustomerFields { get; set; }


    }
}
