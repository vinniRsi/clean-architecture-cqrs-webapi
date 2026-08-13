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

---

## 🧰 Tech Stack

| Layer          | Technology                          |
|----------------|--------------------------------------|
| Language        | C# 12 / .NET 8                      |
| Web Framework  | ASP.NET Core 8 Web API               |
| CQRS           | MediatR 12                           |
| Validation     | FluentValidation 11                  |
| ORM            | Entity Framework Core 8              |
| Database       | SQL Server                           |
| API Docs       | Swagger / OpenAPI (Swashbuckle)      |

---

## 🗂️ Project Structure

```text
src/
├── Core/
│   ├── Domain/
│   │   ├── Common/
│   │   │   └── BaseEntity.cs
│   │   ├── Entities/
│   │   │   └── Product.cs
│   │   └── Enums/
│   │       └── ProductStatus.cs
│   └── Application/
│       ├── Common/
│       │   ├── Behaviours/
│       │   │   └── ValidationBehaviour.cs   # MediatR pipeline behaviour
│       │   ├── Exceptions/
│       │   │   ├── NotFoundException.cs
│       │   │   └── ValidationException.cs
│       │   └── Interfaces/
│       │       └── IProductRepository.cs
│       ├── DTOs/
│       │   └── ProductDto.cs
│       ├── Products/
│       │   ├── Commands/
│       │   │   ├── CreateProduct/
│       │   │   ├── UpdateProduct/
│       │   │   └── DeleteProduct/
│       │   └── Queries/
│       │       ├── GetAllProducts/
│       │       └── GetProductById/
│       └── DependencyInjection/
│           └── ApplicationServiceRegistration.cs
└── Infrastructure/
    ├── Infrastructure/
    │   ├── Persistence/
    │   │   ├── ApplicationDbContext.cs
    │   │   └── Configurations/
    │   │       └── ProductConfiguration.cs
    │   ├── Repositories/
    │   │   └── ProductRepository.cs
    │   └── DependencyInjection/
    │       └── InfrastructureServiceRegistration.cs
    └── WebApi/
        ├── Controllers/
        │   └── ProductsController.cs
        ├── Middleware/
        │   └── ExceptionHandlingMiddleware.cs
        └── Program.cs
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)

### Configuration

Edit `src/Infrastructure/WebApi/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CleanArchCqrsDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### Run Migrations

```bash
dotnet ef migrations add InitialCreate \
  --project src/Infrastructure/Infrastructure \
  --startup-project src/Infrastructure/WebApi

dotnet ef database update \
  --project src/Infrastructure/Infrastructure \
  --startup-project src/Infrastructure/WebApi
```

### Run the API

```bash
cd src/Infrastructure/WebApi
dotnet run
```

The API will be available at `https://localhost:5001` (or `http://localhost:5000`).
Swagger UI: `https://localhost:5001/swagger`

---

## 📡 API Endpoints

| Method | Endpoint              | Description         |
|--------|-----------------------|---------------------|
| GET    | `/api/products`       | Get all products    |
| GET    | `/api/products/{id}`  | Get product by ID   |
| POST   | `/api/products`       | Create a product    |
| PUT    | `/api/products/{id}`  | Update a product    |
| DELETE | `/api/products/{id}`  | Delete a product    |

### Example: Create Product

```http
POST /api/products
Content-Type: application/json

{
  "name": "Widget Pro",
  "description": "A high-quality widget",
  "price": 29.99,
  "stockQuantity": 100
}
```

---

## 🧩 CQRS Pattern

Commands (write) and Queries (read) are separated using **MediatR**:

```
Controller → IMediator.Send(Command/Query)
                 ↓
           MediatR Pipeline
                 ↓
          ValidationBehaviour  ← FluentValidation
                 ↓
          CommandHandler / QueryHandler
                 ↓
          IRepository → DbContext → SQL Server
```

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).
