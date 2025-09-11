using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.Tests
{
    public class LambdaExpressionsTest
    {
        [Fact]
        public void ShouldTestLambdaExpressions()
        {
            var lambdaExpressions = new CSharpAdvanceTopics.LambdaExpressions.LambdaExpressions();
            lambdaExpressions.Express();

            var result = lambdaExpressions.SquareWithoutLambdaExpression(5);
            Assert.Equal(25, result);
        }

        [Fact]
        public void ShouldTestUserRepositoryWithLambdas()
        {
            var userRepository = new CSharpAdvanceTopics.LambdaExpressions.UserRepository();
            var users = userRepository.GetUsers();
            var user = users.Find(u => u.Name == "JP");

            Assert.NotNull(user);
        }
    }
}
