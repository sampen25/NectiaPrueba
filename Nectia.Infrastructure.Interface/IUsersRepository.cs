using Nectia.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nectia.Infrastructure.Interface
{
    public interface IUsersRepository
    {
        Users Authenticate(string username, string password);
        bool Insert(Users user);
        IEnumerable<Users> GetAll();
    }
}
    