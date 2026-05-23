# BookStore API

A RESTful API built with ASP.NET Core 9 and Clean Architecture.

## Architecture
- **Domain** - Entities and business logic
- **Application** - DTOs, Interfaces, Services
- **Infrastructure** - EF Core, Repository, Database
- **API** - Controllers, Endpoints

## Technologies
- ASP.NET Core 9
- Entity Framework Core 9
- SQL Server
- Clean Architecture
- Repository Pattern
- Soft Delete

## Endpoints
- GET /api/books - Get all books
- GET /api/books/{id} - Get book by ID
- POST /api/books - Add new book
- PUT /api/books/{id} - Update book
- DELETE /api/books/{id} - Delete book (Soft Delete)

> This project is a sample API for learning purposes.
