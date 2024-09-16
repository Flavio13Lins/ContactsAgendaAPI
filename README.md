# ContactsAgendaAPI

ContactsAgendaAPI is a web API built using ASP.NET Core that provides CRUD (Create, Read, Update, Delete) operations for managing contacts in an agenda. The project uses a MySQL database for data storage and integrates various modern development tools and practices such as Entity Framework Core, AutoMapper, and Swagger.

## Features

- **CRUD Operations**: Create, read, update, and delete contacts.
- **Swagger Integration**: Interactive API documentation.
- **AutoMapper Integration**: Simplified object-to-object mapping.
- **Entity Framework Core**: Database operations using MySQL.
- **Dependency Injection**: Decoupled and testable code.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL](https://www.mysql.com/downloads/) database server
- [Visual Studio Code](https://code.visualstudio.com/) or any other code editor
- [Postman](https://www.postman.com/) or any other API testing tool

### Install dependencies:

```sh
dotnet restore
```

Configure the database connection string: Update the appsettings.json file with your MySQL connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MyAgendaDB;User=root;Password=yourpassword;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Run database migrations:

```sh
dotnet ef database update
```

### Running the API

1. **Build and run the project**:

```sh
dotnet run
```

### Run unit tests for this API:

See the MyAgendaAPI.Tests folder

### Running the API

Access the API: The API will be available at https://localhost:8181 (or http://localhost:8081).

Access Swagger UI: Navigate to https://localhost:8181/swagger to explore the API endpoints interactively.

### API Endpoints

- **GET /contacts**: Retrieve all contacts.
- **GET /contacts/{id}**: Retrieve a specific contact by ID.
- **POST /contacts**: Create a new contact.
- **PUT /contacts/{id}**: Update an existing contact.
- **DELETE /contacts/{id}**: Delete a contact by ID.

### Technologies Used

- **ASP.NET Core 8.0**: Web framework
- **Entity Framework Core**: ORM for database access
- **MySQL**: Database server
- **AutoMapper**: Object-to-object mapping
- **Swagger**: API documentation
