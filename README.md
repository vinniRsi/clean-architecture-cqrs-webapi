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
