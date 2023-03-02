using Nectia.Domain.Entity;
using Nectia.Domain.Interface;
using Nectia.Infrastructure.Interface;
using System.Collections.Generic;

namespace Nectia.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;
        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public Users Authenticate(string userName, string password)
        {
            return _usersRepository.Authenticate(userName, password);
        }
        public bool Insert(Users users)
        {
            return _usersRepository.Insert(users);
        }
        public IEnumerable<Users> GetAll()
        {
            return _usersRepository.GetAll();
        }
    }
}
