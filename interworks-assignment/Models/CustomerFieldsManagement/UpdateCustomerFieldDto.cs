using interworks_assignment.Models.CustomerManagement;
using Microsoft.Data.SqlClient.DataClassification;

namespace interworks_assignment.Models.CustomerFieldsManagement
{
    public class UpdateCustomerFieldDto
    {
        public string Guid { get; set; }
        public int CustomerId { get; set; }

        public int FieldId { get; set; }

    }
}
