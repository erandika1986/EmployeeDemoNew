using Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Infrastructure.Data.Configurations
{
    public class UserDepartmentConfiguration : IEntityTypeConfiguration<UserDepartment>
    {
        public void Configure(EntityTypeBuilder<UserDepartment> builder)
        {
            builder.ToTable("UserDepartment");

            builder.HasKey(x => x.Id);

            builder.HasOne<User>(s => s.User)
                .WithMany(x => x.UserDepartments)
                .HasForeignKey(x => x.UserId);

            builder.HasOne<Department>(s => s.Department)
                .WithMany(x => x.UserDepartments)
                .HasForeignKey(x => x.DepartmentId);
        }
    }
}
