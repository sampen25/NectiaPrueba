using Nectia.Application.DTO;
using Nectia.Transversal.Common;
using System.Collections.Generic;

namespace Nectia.Application.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDto> Authenticate(string username, string password);
        Response<bool> Insert(UsersDto userdto);
        Response<IEnumerable<UsersDto>> GetAll();
    }
}
