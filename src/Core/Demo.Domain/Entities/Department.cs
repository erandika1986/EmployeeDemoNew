using Demo.Domain.Common;

namespace Demo.Domain.Entities
{
    public class Department : BaseAuditEntity
    {
        public string Name { get; set; }
        public int ManagerId { get; set; }

        public virtual User Manager { get; set; }

        public virtual ICollection<UserDepartment> UserDepartments { get; set; }
    }
}
