﻿using Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Common.Interfaces
{
    public interface IEmployeeContext
    {
        DbSet<User> User { get; }
        DbSet<Department> Departments { get; }
        DbSet<UserDepartment> UserDepartments { get; }
    }
}
