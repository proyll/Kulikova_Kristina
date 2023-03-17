﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<Userss>, IUserRepository
    {
        public UserRepository(OdezdaContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
