using CSharpAdvanceTopics.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.Tests
{
    public class ExtensionMethodsTest
    {
        [Fact]
        public void StringToCapitalize_ShouldCapitalizeTheString()
        {
            try
            {
                string name = "john";
                var capitalizedName = name.ToCapitalize();
                Assert.Equal("John", capitalizedName);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }
    }
}
