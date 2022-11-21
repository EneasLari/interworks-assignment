using interworks_assignment.Models.Base;
using interworks_assignment.Models.CustomerManagement;
using System.Text.Json.Serialization;

namespace interworks_assignment.Models.CustomerFieldsManagement
{
    public class CustomerField : BaseEntity
    {
        public CustomerField()
        {
            this.Guid = System.Guid.NewGuid().ToString();
        }

        public CustomerField(NewCustomerFieldDto newCustomerFieldDto)
        {
            this.Guid = System.Guid.NewGuid().ToString();
            this.CustomerId = newCustomerFieldDto.CustomerId;
            this.FieldId = newCustomerFieldDto.FieldId;
        }

        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }
        public int FieldId { get; set; }

        public Field? Field { get; set; }

        public int Version { get; set; } = 1;

        public string Guid { get; set; }
    }
}
