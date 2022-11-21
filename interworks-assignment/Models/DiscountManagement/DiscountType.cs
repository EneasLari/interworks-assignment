using interworks_assignment.Models.Base;

namespace interworks_assignment.Models.DiscountManagement
{
    public class DiscountType : BaseEntity
    {
        public int DiscountTypeTemplateId { get; set; } 

        public DiscountTypeTemplate? DiscountTypeTemplate { get; set; }

        public float DiscountPercentage { get; set; }
    }
}
