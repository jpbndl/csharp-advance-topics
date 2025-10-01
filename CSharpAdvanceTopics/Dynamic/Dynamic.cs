using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.Dynamic
{
    public class Dynamic
    {
        public void DynamicSamples() { 
            object obj = "This is a string";
            obj.GetHashCode(); // This works because GetHashCode is a method of object

            var methodInfo = obj.GetType().GetMethod("GetHashCode");
            methodInfo?.Invoke(null, null); // This works because we are using reflection to call GetHashCode

            dynamic tempObj = "This is a dynamic string";
            tempObj.GetHashCode(); // This works because tempObj is dynamic and resolved at runtime
            tempObj.NonExistentMethod(); // This will compile but throw a RuntimeBinderException at runtime because the method does not exist

            dynamic name = "John"
            name = 10; // This works because name is dynamic and can change type at runtime
            
            dynamic address = "123 Main St";
            address++; // This will compile but throw a RuntimeBinderException at runtime because the ++ operator is not defined for string

            dynamic a = 3;
            dynamic b = 4;
            var c = a + b; // "c" becomes dynamic and will be 7 at runtime
        }
    }
}
