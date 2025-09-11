using CSharpAdvanceTopics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.LambdaExpressions
{
    public class UserRepository
    {
        public List<User> GetUsers()
        {
            return new List<User>
            {
                new User() { Id = 1, Name = "JP" },
                new User() { Id = 2, Name = "Sandi" },
                new User() { Id = 3, Name = "Jaine" },
                new User() { Id = 4, Name = "Sathi" }
            };
        }
    }
}
