namespace Demo.Api.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }

        public virtual ICollection<UserDepartment> UserDepartments { get; set; }
    }
}
