# Running Unit Tests

This project uses the [xUnit](https://xunit.net/) framework for unit testing.

## How to Run the Tests

### Using Visual Studio
1. Open the solution in Visual Studio 2022 or later.
2. Build the solution to restore dependencies.
3. Open the **Test Explorer** (`Test > Test Explorer`).
4. Click **Run All** to execute all tests.

### Using .NET CLI
1. Open a terminal or command prompt.
2. Navigate to the test project directory:
   ```sh
   cd CSharpAdvanceTopics.Tests
   ```
3. Run the tests with:
   ```sh
   dotnet test
   ```

## Notes
- Tests are located in the `CSharpAdvanceTopics.Tests` project.
- The project targets .NET 9 and uses xUnit for test cases.
- Test results will be displayed in the terminal or Test Explorer.

## Example Output
```
Passed!  - Failed: 0, Passed: X, Skipped: 0, Total: X, Duration: X s
```
