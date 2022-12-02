using interworks_assignment.Data;
using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Models.DiscountManagement;
using interworks_assignment.Models.OrderManagement;
using interworks_assignment.Repositories.Interfaces;

namespace interworks_assignment.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private DataContext _datacontext;
        public OrderRepository(DataContext dataContext) : base(dataContext)
        {
            this._datacontext = dataContext;
        }

        public void CreateNewOrder(NewOrderDto newOrder) {
            Order order =new Order(newOrder);
            Create(order);
        }
        //Sets final price of an order by creating some discount types(choosing from availables templates),
        //and adds some percentage of discount to the type(random dor demonstartional porposes),then creates a discount for every type.
        //The discount takes as foreign key the current order id. 
        public void SetFinalPriceOfOrder(int orderId) {
            Order orderdb = GetById(orderId);
            orderdb.Finalprice = orderdb.IntialPrice;

            Repository<Discount> discountrepo = new Repository<Discount>(_dataContext);
            IEnumerable<Discount> discountstodelete = discountrepo.GetAll().Where(x => x.OrderId == orderId);
            _datacontext.RemoveRange(discountstodelete);
            _datacontext.SaveChanges();

            //get all discounttypetemplates and choose one random
            Repository<DiscountTypeTemplate> discountTypeTemplaterepo = new Repository<DiscountTypeTemplate>(_dataContext);
            List<DiscountTypeTemplate> templates = discountTypeTemplaterepo.GetAll().ToList();
            Random rand = new Random();
            
            int randomnumberofdiscounts = rand.Next(1, templates.Count());
            for (int i = 0; i < randomnumberofdiscounts; i++)
            {
                //choose a random discount type template
                int randomtemplateindex = rand.Next(0, templates.Count());
                DiscountTypeTemplate templatechosen = templates[randomtemplateindex];

                //create new discounttype
                DiscountType discountType = new DiscountType();
                discountType.DiscountTypeTemplateId = templatechosen.Id;
                double percentage = rand.NextDouble();
                discountType.DiscountPercentage = (float)percentage;
                Repository<DiscountType> discountTyperepo = new Repository<DiscountType>(_dataContext);
                discountTyperepo.Create(discountType);
                _datacontext.SaveChanges();

                //create new discount
                Discount discount = new Discount();
                discount.DiscountTypeId = discountType.Id;
                discount.OrderId = orderdb.Id;
                //get discount price from final price(which is the same as initial at the begining)
                //The discounted price is the price that get the discount applied to the last final price
                discount.DiscountedPrice = orderdb.Finalprice*discountType.DiscountPercentage;

                
                discountrepo.Create(discount);
                _datacontext.SaveChanges();
                //abstract final price by discount price
                orderdb.Finalprice-=discount.DiscountedPrice;
            }       
        }
        public void DeleteOrder(int id)
        {
            Order order = GetById(id);
            Delete(order);
        }
    }
}
