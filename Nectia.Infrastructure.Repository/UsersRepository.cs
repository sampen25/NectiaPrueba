using Dapper;
using Nectia.Domain.Entity;
using Nectia.Infrastructure.Interface;
using Nectia.Transversal.Common;
using System.Collections.Generic;
using System.Data;

namespace Nectia.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UsersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public Users Authenticate(string userName, string password)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", userName);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return user;
            }
        }

        public bool Insert(Users user)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UsersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("UserID", user.UserId);
                parameters.Add("FirstName", user.FirstName);
                parameters.Add("LastName", user.LastName);
                parameters.Add("UserName", user.UserName);
                parameters.Add("Password", user.Password);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public IEnumerable<Users> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UsersList";

                var users = connection.Query<Users>(query, commandType: CommandType.StoredProcedure);
                return users;
            }
        }
    }
}
