# Lambda Expressions in C#

An anonymous function

- No access modifier
- No name 
- No return statement

## Why do we usLambda Expressions?

For convenience

```chsarp
public int LambdaExpressionExample()
{
	// args => expression
	
	// If we dont need an argument
	// () => ....
	// If we have one argument
	// arg => ...
	// If we have multiple arguments
	// (arg1, arg2) => ...

	Func<int, int> square = number => number * number;
	return square(5);
}

public int Square(int number)
{
	return number * number;
}
```