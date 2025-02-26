# UTKTSession: Enhancing Code Testability in C# and .NET

## Overview

**UTKTSession** is a repository dedicated to improving code testability in C# and .NET. It focuses on refactoring existing code to make it more modular, maintainable, and test-friendly using best practices and design patterns. 

## Why Testability Matters

Testable code is essential for building reliable applications. It enables:

- Easier debugging and maintenance
- Faster feedback in development cycles
- Improved code quality and design
- Seamless integration with CI/CD pipelines

## Key Concepts

This repository demonstrates various strategies for improving testability, including:

- **Dependency Injection**: Decoupling dependencies for easier mocking and testing
- **Interface Segregation**: Breaking down large classes into smaller, more manageable interfaces
- **Refactoring Legacy Code**: Transforming tightly coupled code into test-friendly components
- **Unit Testing with xUnit and Moq**: Writing effective unit tests with popular frameworks

## Code Examples

### Before: Hard-to-Test Code
```csharp
public class UserService
{
    private readonly Database _database;
    
    public UserService()
    {
        _database = new Database(); // Hardcoded dependency
    }

    public User GetUserById(int id)
    {
        return _database.FetchUser(id); // Direct dependency on Database class
    }
}
```

### After: Refactored for Testability
```csharp
public interface IDatabase
{
    User FetchUser(int id);
}

public class UserService
{
    private readonly IDatabase _database;
    
    public UserService(IDatabase database)
    {
        _database = database; // Injected dependency
    }

    public User GetUserById(int id)
    {
        return _database.FetchUser(id);
    }
}
```

### Writing a Unit Test
```csharp
using Moq;
using Xunit;

public class UserServiceTests
{
    [Fact]
    public void GetUserById_ReturnsUser_WhenUserExists()
    {
        // Arrange
        var mockDatabase = new Mock<IDatabase>();
        mockDatabase.Setup(db => db.FetchUser(1)).Returns(new User { Id = 1, Name = "Test User" });
        var userService = new UserService(mockDatabase.Object);

        // Act
        var user = userService.GetUserById(1);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(1, user.Id);
        Assert.Equal("Test User", user.Name);
    }
}
```

## Tools & Frameworks Used

- **C#** (.NET 6/7+ recommended)
- **xUnit** (Unit Testing)
- **Moq** (Mocking dependencies)
- **Dependency Injection (DI)** (For managing dependencies in a testable way)
- **SOLID Principles** (Ensuring maintainable and scalable design)

## How to Use

1. Clone the repository:
   ```sh
   git clone https://github.com/baez/UTKTSession.git
   cd UTKTSession
   ```
2. Install dependencies if needed:
   ```sh
   dotnet restore
   ```
3. Run tests:
   ```sh
   dotnet test
   ```

## Contributing

Contributions are welcome! Feel free to submit PRs with improvements, refactorings, or additional testability patterns.

## License

This project is licensed under **Apache 2.0 License**.

---

Let's write code that's **clean, maintainable, and testable**! 🚀
