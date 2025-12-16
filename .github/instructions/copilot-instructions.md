# BookStore API - Global Coding Standards

This document defines the general coding standards applicable to all layers of the BookStore project (API, Tests, UI). Custom agents must produce code that adheres to these standards.

## Project Context

BookStore is a .NET 10.0-based book management REST API and React frontend application. The project is being developed using custom agents, with emphasis on test coverage, clean architecture, and modern best practices.

## Code Standards

### C# Conventions

- **Brace Style**: Allman style (braces on new line)
  ```csharp
  public ActionResult<Book> GetBook(int id)
  {
      return Ok(book);
  }
  ```

- **Indentation**: 4 spaces (no tabs)

- **Naming Conventions**:
  - Classes, Interfaces, Methods, Properties: `PascalCase`
  - Local variables, parameters: `camelCase`
  - Private fields: `_camelCase` (underscore prefix)
  - Constants: `PascalCase`
  - Interfaces: `I` prefix (e.g., `IBookService`)

- **Nullable Reference Types**: Enabled
  - String properties: Initialize with `string.Empty`
  - Nullable types: Use `?` operator (e.g., `int? CategoryId`)

- **Implicit Usings**: Enabled (global usings automatic)

### TypeScript/React Conventions

- **Component Files**: `PascalCase.tsx` (e.g., `BookList.tsx`, `BookForm.tsx`)
- **Service Files**: `camelCase.ts` (e.g., `bookService.ts`, `apiClient.ts`)
- **Type Files**: `PascalCase.ts` (e.g., `Book.ts`, `ApiResponse.ts`)
- **Functional Components**: Use hooks, class components forbidden
- **Props**: Define with interface, prefer prop destructuring

## Language Policy

### XML Documentation (C#)
Use **Turkish** for user-facing descriptions:
```csharp
/// <summary>
/// Tüm kitapları getirir
/// </summary>
/// <returns>Kitap listesi</returns>
[HttpGet]
public ActionResult<IEnumerable<Book>> GetAllBooks()
```

### Code Identifiers
Use **English** (variables, methods, classes):
```csharp
private readonly IBookService _bookService;
public async Task<Book> CreateBookAsync(Book book)
```

### User-Facing Messages
Use **Turkish** (error messages, validation, logs):
```csharp
return NotFound($"Kitap bulunamadı: {id}");
throw new ValidationException("ISBN alanı 13 karakter olmalıdır");
logger.LogInformation("Kitap eklendi: {BookId}", bookId);
```

## Architecture

### Project Structure
```
BookStoreAPI/
├── Controllers/          # API endpoints
├── Models/              # Entity models
│   └── Common/          # Shared models (PagedResult, etc.)
├── Services/            # Business logic
│   └── Interfaces/      # Service interfaces
├── Data/                # EF Core DbContext
├── Validators/          # FluentValidation validators
└── Middleware/          # Custom middleware

BookStoreAPI.Tests/
├── Controllers/         # Controller tests
├── Services/            # Service tests
└── Helpers/             # Test utilities

BookStoreUI/
├── src/
│   ├── components/      # React components
│   │   └── books/       # Book-related components
│   ├── services/        # API services
│   │   └── api/         # API client
│   ├── types/           # TypeScript types
│   ├── hooks/           # Custom hooks
│   └── utils/           # Utility functions
```

### Namespace Convention
```csharp
BookStoreAPI.Models
BookStoreAPI.Controllers
BookStoreAPI.Services
BookStoreAPI.Services.Interfaces
BookStoreAPI.Data
BookStoreAPI.Validators
BookStoreAPI.Tests.Controllers
BookStoreAPI.Tests.Services
```

### Dependency Injection
Use constructor injection:
```csharp
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly ILogger<BooksController> _logger;

    public BooksController(IBookService bookService, ILogger<BooksController> logger)
    {
        _bookService = bookService;
        _logger = logger;
    }
}
```

## Error Handling

### Error Message Format
```csharp
// 404 Not Found
return NotFound($"{EntityName} bulunamadı: {id}");

// 400 Bad Request
return BadRequest($"{EntityName} eklenirken hata oluştu: {error.Message}");

// Validation errors
return BadRequest(new { errors = validationErrors, message = "Validasyon hatası" });
```

### HTTP Status Codes
- `200 OK`: Successful GET, PUT
- `201 Created`: Successful POST, with `Location` header
- `204 NoContent`: Successful DELETE, PUT (without body)
- `400 BadRequest`: Validation error
- `404 NotFound`: Entity not found, with Turkish message
- `500 InternalServerError`: Unexpected error

### Logging Pattern
```csharp
// Information
logger.LogInformation("{Action} başlatıldı: {EntityId}", "CreateBook", bookId);

// Warning
logger.LogWarning("{Action} başarısız: {Reason}", "UpdateBook", reason);

// Error
logger.LogError(ex, "{Action} sırasında hata: {EntityId}", "DeleteBook", id);
```

## API Conventions

### Async/Await
Use `async/await` for all I/O operations:
```csharp
public async Task<ActionResult<Book>> GetBookByIdAsync(int id)
{
    var book = await _bookService.GetByIdAsync(id);
    if (book == null)
    {
        return NotFound($"Kitap bulunamadı: {id}");
    }
    return Ok(book);
}
```

### Return Types
```csharp
// API Controllers
ActionResult<T>           // Single object
ActionResult<IEnumerable<T>>  // Collection
ActionResult              // No content (204, 404)

// Services
Task<T>                   // Single object
Task<IEnumerable<T>>      // Collection
Task<PagedResult<T>>      // Paged result
```

### Route Naming
```csharp
[ApiController]
[Route("api/[controller]")]  // /api/books
public class BooksController : ControllerBase
{
    [HttpGet]                     // GET /api/books
    [HttpGet("{id}")]             // GET /api/books/5
    [HttpGet("search")]           // GET /api/books/search?query=term
    [HttpPost]                    // POST /api/books
    [HttpPut("{id}")]             // PUT /api/books/5
    [HttpDelete("{id}")]          // DELETE /api/books/5
}
```

## Configuration

### Connection Strings
Use `appsettings.json` and `appsettings.Development.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=bookstore.db"
  }
}
```

### Environment Variables (Frontend)
```bash
VITE_API_URL=http://localhost:5134/api
```

## Instructions Priority

**Agent-Specific Instructions > Global Instructions**

If a rule defined in an agent's own instruction file conflicts with a rule in this global instruction, the agent-specific rule takes precedence.

Example: If Test Agent's own file has a "use in-memory data" rule, it overrides the global "use mocks" rule.

## Git Commit Convention

```bash
# Format
<type>: <subject>

# Types
feat: Yeni özellik
fix: Hata düzeltme
test: Test ekleme/düzeltme
refactor: Kod iyileştirme
docs: Dokümantasyon
style: Kod formatı

# Örnek
feat: Add search endpoint for books
test: Add unit tests for BooksController
refactor: Extract service layer from controller
```
