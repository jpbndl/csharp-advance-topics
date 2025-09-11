using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string ToCapitalize(this String str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }
    }
}
