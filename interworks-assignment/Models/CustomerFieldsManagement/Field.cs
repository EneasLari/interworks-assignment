using interworks_assignment.Models.Base;

namespace interworks_assignment.Models.CustomerFieldsManagement
{
    public class Field:BaseEntity
    {
        public string FieldName { get; set; }=string.Empty;
    }
}
