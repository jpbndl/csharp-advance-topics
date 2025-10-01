using CSharpAdvanceTopics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.LINQ
{
    public class Linq
    {
        private IEnumerable<User> GetSampleUsers()
        {
            var users = new List<User>
            {
                new User { Id = 1, Name = "Alice", Age = 30 },
                new User { Id = 2, Name = "Bob", Age = 25 },
                new User { Id = 3, Name = "Charlie", Age = 35 },
                new User { Id = 4, Name = "David", Age = 28 },
                new User { Id = 5, Name = "Eve", Age = 22 }
            };
            return users;
        }

        public User? GetUserById(int id)
        {
            var users = GetSampleUsers();
            // LINQ Query Syntax
            var user = (from u in users
                        where u.Id == id
                        select u).FirstOrDefault();
            return user;
        }

        public IEnumerable<User> GetUsersAboveAge(int age)
        {
            var users = GetSampleUsers();

            // LINQ Method Syntax
            var filteredUsers = users.Where(u => u.Age > age)
                                      .OrderBy(u => u.Age);

            return filteredUsers;
        }
    }
}
