using interworks_assignment.Models.Base;
using interworks_assignment.Models.OrderManagement;

namespace interworks_assignment.Models.DiscountManagement
{
    public class Discount : BaseEntity
    {
        public int DiscountTypeId { get; set; }
        public DiscountType? DiscountType { get; set; }
        public float DiscounPrice { get; set; }
        public Order  Order { get; set; }

        public int OrderId { get; set; }
     }
}
