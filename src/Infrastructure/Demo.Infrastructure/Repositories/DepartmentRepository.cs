using Demo.Domain.Entities;
using Demo.Domain.Repositories;
using Demo.Infrastructure.Data;
using Demo.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>,IDepartmentRepository
    {
        public DepartmentRepository(EmployeeContext context):base(context)
        {

        }

        public async Task<Department> GetDepartmentByName(string name)
        {
            var result = await _context.Departments.FirstOrDefaultAsync(x => x.Name.Contains(name));

            return result;
        }
    }
}
