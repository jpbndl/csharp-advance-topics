using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.Tests
{
    public class LinqTest
    {
        [Fact]
        public void GetUserById_ShouldReturnCorrectUser()
        {
            // Arrange
            var linq = new CSharpAdvanceTopics.LINQ.Linq();
            int userId = 3;
            // Act
            var user = linq.GetUserById(userId);
            // Assert
            Assert.NotNull(user);
            Assert.Equal("Charlie", user?.Name);
        }

        [Fact]
        public void GetUsersAboveAge_ShouldReturnFilteredUsers()
        {
            // Arrange
            var linq = new CSharpAdvanceTopics.LINQ.Linq();
            int ageThreshold = 25;
            // Act
            var users = linq.GetUsersAboveAge(ageThreshold);
            // Assert
            Assert.NotEmpty(users);
            Assert.All(users, u => Assert.True(u.Age > ageThreshold));
        }
    }
}
