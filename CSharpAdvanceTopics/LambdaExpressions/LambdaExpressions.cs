using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.LambdaExpressions
{
    /** args => expression
     * 
     * 
     * If we dont need an argument
     * () => ....
     * If we have one argument
     * arg => ...
     * If we have multiple arguments
     * (arg1, arg2) => ...
    */
    public class LambdaExpressions
	{
		public void Express()
		{
			Func<int, int> square = number => number * number;
			Console.WriteLine(square(5));
            Func<int, int> multiplier = n => n * 5;
            Console.WriteLine(multiplier(5));
        }

        public int SquareWithoutLambdaExpression(int number)
		{
			return number * number;
        }
    }
}
