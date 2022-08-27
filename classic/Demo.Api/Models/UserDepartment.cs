namespace Demo.Api.Models
{
    public class UserDepartment
    {
        public int Id { get; set; }

        public int  UserId { get; set; }
        public int DepartmentId { get; set; }

        public virtual User User { get; set; }
        public virtual Department Department { get; set; }
    }
}
