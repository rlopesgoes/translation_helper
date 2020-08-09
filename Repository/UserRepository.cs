using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMLEditor.Models;
using Dapper;

namespace XMLEditor.Repository
{
    public class UserRepository : IUserRepository
    {
        public User GetUserByLoginName(String login)
        {
            var command = "SELECT * FROM users WHERE Login=@Login";
            using (var myconn = MySqlConnString.GetConnection())
            {
                return myconn.Query<User>(command, new { Login = login }).FirstOrDefault();
            }
        }

    }
}
