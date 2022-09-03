using Demo.Domain.Entities;
using Demo.Domain.Repositories;
using Demo.Infrastructure.Data;
using Demo.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Repositories
{
    public class UserReposioty : BaseRepository<User>,IUserReposioty
    {
        public UserReposioty(EmployeeContext employeeContext):base(employeeContext) 
        {

        }
    }
}
