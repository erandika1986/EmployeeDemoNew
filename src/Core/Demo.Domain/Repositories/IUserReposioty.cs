﻿using Demo.Domain.Entities;
using Demo.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Repositories
{
    public interface IUserReposioty : IBaseRepository<User>
    {
    }
}
