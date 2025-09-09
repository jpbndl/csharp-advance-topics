using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpAdvanceTopics.Entities;
using CSharpAdvanceTopics.Generics;

namespace CSharpAdvanceTopics.Tests
{
    public class GenericTests
    {
        [Fact]
        public void ShouldCreateAListOfUsers()
        {
            var jp = new User { Id = 1, Name = "JP"};
            var sandi = new User { Id = 1, Name = "Sandi" };
            var jaine = new User { Id = 1, Name = "Jaine" };

            var users = new GenericList<User>();
            users.Add(jp);
            users.Add(sandi);
            users.Add(jaine);

            Assert.Equal(3, users.Count);
            Assert.Equal("JP", users[0].Name);
            Assert.Equal("Sandi", users[1].Name);
            Assert.Equal("Jaine", users[2].Name);

        }

        [Fact]
        public void ShouldTestNullable()
        {
            var number = new Generics.Nullable<int>(4);
            Assert.Equal(4, number.GetValueOrDefault());
        }
    }
}
