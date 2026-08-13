# 🚀 Clean Architecture + CQRS + Web API (.NET 8 & SQL Server)

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Architecture](https://img.shields.io/badge/Architecture-Clean%20%2B%20CQRS-blue)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

A robust, enterprise-grade RESTful API built with **.NET 8**, following **Clean Architecture** principles and the **CQRS (Command Query Responsibility Segregation)** pattern with **MediatR** and **Entity Framework Core**.

---

## 🏗️ Architecture & Layers

This project follows Uncle Bob's Clean Architecture pattern to separate concerns and maintain loose coupling:

```text
src/
├── Core/
│   ├── Domain/          # Core Business Logic, Entities, Enums, Value Objects
│   └── Application/     # Use Cases, CQRS (Commands, Queries), Interfaces, DTOs
└── Infrastructure/
    ├── Infrastructure/  # EF Core, DbContext, Migrations, Repositories
    └── WebApi/          # Controllers, Middleware, API Configurations
```

### Layer Dependencies

```
WebApi → Application → Domain
   ↓
Infrastructure
```

- **Domain**: No dependencies (innermost layer)
- **Application**: Depends only on Domain
- **Infrastructure**: Depends on Application (implements interfaces)
- **WebApi**: Depends on Application and Infrastructure (composition root)

---

## 🛠️ Technologies & Packages

| Layer          | Technologies                                      |
|----------------|---------------------------------------------------|
| **Domain**     | C# 12, .NET 8                                     |
| **Application**| MediatR, FluentValidation                         |
| **Infrastructure** | Entity Framework Core 8, SQL Server            |
| **WebApi**     | ASP.NET Core 8, Swagger/OpenAPI                  |

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB, Express, or full version)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Setup & Run

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd clean-architecture-cqrs-webapi
   ```

2. **Update the connection string** (if needed)
   
   Edit `src/Infrastructure/WebApi/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CleanArchitectureDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Apply database migrations**
   ```bash
   dotnet ef database update --project src/Infrastructure/Infrastructure --startup-project src/Infrastructure/WebApi
   ```

4. **Run the application**
   ```bash
   dotnet run --project src/Infrastructure/WebApi
   ```

5. **Open Swagger UI**
   
   Navigate to: `https://localhost:5001/swagger` or `http://localhost:5000/swagger`

---

## 📂 Project Structure

```
CleanArchitecture.slnx
├── src/
│   ├── Core/
│   │   ├── Domain/
│   │   │   ├── Common/           # Base classes (BaseEntity, IAuditableEntity)
│   │   │   ├── Entities/         # Domain entities (Product)
│   │   │   └── Enums/            # Domain enums (ProductStatus)
│   │   │
│   │   └── Application/
│   │       ├── Behaviors/        # MediatR pipeline behaviors (ValidationBehavior)
│   │       ├── Common/           # Shared models (Result)
│   │       ├── DTOs/             # Data Transfer Objects
│   │       ├── Features/         # CQRS Commands & Queries
│   │       │   └── Products/
│   │       │       ├── Commands/ # Create, Update, Delete
│   │       │       └── Queries/  # GetById, GetAll
│   │       ├── Interfaces/       # Repository contracts
│   │       └── Mappings/         # Entity-to-DTO mappings
│   │
│   └── Infrastructure/
│       ├── Infrastructure/
│       │   ├── Persistence/      # DbContext, Configurations, Migrations
│       │   └── Repositories/     # Repository implementations
│       │
│       └── WebApi/
│           ├── Controllers/      # API Controllers
│           └── Middleware/       # Exception handling
│
└── README.md
```

---

## 🔌 API Endpoints

### Products

| Method | Endpoint              | Description            |
|--------|-----------------------|------------------------|
| GET    | `/api/products`       | Get all products       |
| GET    | `/api/products/{id}`  | Get product by ID      |
| POST   | `/api/products`       | Create a new product   |
| PUT    | `/api/products/{id}`  | Update a product       |
| DELETE | `/api/products/{id}`  | Delete a product       |

### Sample Request - Create Product

```json
POST /api/products
{
  "name": "Sample Product",
  "description": "A sample product description",
  "price": 29.99,
  "stockQuantity": 100,
  "category": "Electronics"
}
```

---

## 🧪 Adding New Features

### 1. Add a New Entity

1. Create entity in `Domain/Entities/`
2. Add DbSet in `ApplicationDbContext`
3. Create configuration in `Infrastructure/Persistence/Configurations/`

### 2. Add a New Command/Query

1. Create Command/Query record in `Application/Features/{Entity}/Commands/` or `Queries/`
2. Create corresponding Handler
3. (Optional) Create Validator using FluentValidation
4. Add endpoint in Controller

### 3. Add a New Repository

1. Define interface in `Application/Interfaces/`
2. Implement in `Infrastructure/Repositories/`
3. Register in `Infrastructure/DependencyInjection.cs`

---

## ✅ Design Patterns Used

- **Clean Architecture** - Separation of concerns, dependency inversion
- **CQRS** - Command Query Responsibility Segregation
- **Repository Pattern** - Abstract data access
- **Unit of Work** - Manage transactions
- **Mediator Pattern** - Decouple request handling (MediatR)
- **Result Pattern** - Explicit success/failure handling

---

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details...
