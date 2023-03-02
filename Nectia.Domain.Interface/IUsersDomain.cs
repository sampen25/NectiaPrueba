using Nectia.Domain.Entity;
using System.Collections.Generic;

namespace Nectia.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username, string password);
        bool Insert(Users user);
        IEnumerable<Users> GetAll();
    }
}
