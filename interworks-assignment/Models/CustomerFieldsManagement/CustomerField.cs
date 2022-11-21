using interworks_assignment.Models.Base;
using interworks_assignment.Models.CustomerManagement;
using System.Text.Json.Serialization;

namespace interworks_assignment.Models.CustomerFieldsManagement
{
    public class CustomerField : BaseEntity
    {
        public CustomerField()
        {

        }

        public CustomerField(NewCustomerFieldDto newCustomerFieldDto)
        {
            this.CustomerId = newCustomerFieldDto.CustomerId;
            this.FieldId = newCustomerFieldDto.FieldId;
        }
        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }
        public int FieldId { get; set; }

        public Field? Field { get; set; }
    }
}
