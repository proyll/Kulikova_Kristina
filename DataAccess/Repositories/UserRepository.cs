﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using DataAccess.Models;
using Domain.Models;


namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<Userss>, IUserRepository
    {
        public UserRepository(magazContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
