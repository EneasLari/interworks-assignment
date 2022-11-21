using interworks_assignment.Models.CustomerManagement;
using Microsoft.Data.SqlClient.DataClassification;

namespace interworks_assignment.Models.CustomerFieldsManagement
{
    public class UpdateCustomerFieldDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public int FieldId { get; set; }

    }
}
