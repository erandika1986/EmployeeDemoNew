namespace Demo.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime CreatedName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<UserDepartment> UserDepartments { get; set; }
    }
}
