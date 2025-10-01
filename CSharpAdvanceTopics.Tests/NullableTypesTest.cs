using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.Tests
{
    public class NullableTypesTest
    {
        [Fact]
        public void GetNullAge_ShouldReturnErrorWhenUsingValuel()
        {
            // Arrange
            var nullableTypes = new CSharpAdvanceTopics.NullableTypes.NullableTypes();
           
            // Act
            var result = nullableTypes.GetNullAge();
             
            try
            {
                if (result.HasValue)
                {
                    Console.WriteLine("Should throw an error when using Value because it has not been initialized:" + result.GetValueOrDefault());
                } else
                {
                    Console.WriteLine("Should throw an error when using Value because it has not been initialized:" + result.Value);
                }
            }
            catch (InvalidOperationException ex)
            {
                // Assert
                Assert.Equal("Nullable object must have a value.", ex.Message);
            }
            Assert.Null(result);
        }

    }
}
 