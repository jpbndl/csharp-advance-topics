using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.NullableTypes
{
    public class NullableTypes
    {
        public int? Age { get; set; }
        public NullableTypes() { 
            Age = null;

            // Below will throw a compile-time error because Age is null and we are trying to assign it to a non-nullable int
            // int TempAge = Age; 
            // Correct way to assign a nullable int to a non-nullable int with a default value if null
            // int TempAge = Age ?? 0 
            // or 
            // int TempAge = Age.GetValueOrDefault(); // Default is 0 if Age is null
        }

        public float? GetNullAge()
        {
            return Age;
        }
    }
}
