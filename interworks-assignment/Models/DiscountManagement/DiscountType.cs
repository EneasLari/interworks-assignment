using interworks_assignment.Models.Base;

namespace interworks_assignment.Models.DiscountManagement
{
    public class DiscountType : BaseEntity
    {
        public string Name { get; set; } = String.Empty;

        public float DiscountPercentage { get; set; }
    }
}
