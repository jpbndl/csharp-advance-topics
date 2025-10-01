using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public int Age { get; set; }
    }
}
