using Demo.Domain.Common;
using Demo.Domain.Enums;

namespace Demo.Domain.Entities
{
    public class User : BaseAuditEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public Role Role { get; set; }



        public virtual ICollection<UserDepartment> UserDepartments { get; set; }
    }
}
