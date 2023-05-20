# Wall sticker shop

The project is written in web api ASP.Net 7 based rest api.
Includes: server-side and client-side validations, password strength check for added security.
The project is built according to the layer model and uses Dependency Injection (DI).
Using async-await throughout the process for scalability.
Entity Framework ORM is used, using DB first.
Use of swagger
A DTO was used in the project in order to avoid circular dependencies and in addition to maintain a compactness between the layers, the conversion of the objects was done using the AutoMapper library.
Built-in handling of errors by middelWare designated handling by writing to a log file and sending an email.

## Technologies Used

- C#
- .NET Core

## Installation

1. Clone the repository to your local machine.
2. Open the project in your preferred IDE.
3. Build and run the application.

## Usage

1. Open a web browser or use swagger
2. Navigate to the API endpoints to interact with the application.

## API Endpoints
### Users

| HTTP Method | Endpoint                | Description                   |
|-------------|-------------------------|-------------------------------|
| GET         | /api/users/{id}         | Get a specific user by ID     |
| POST        | /api/users              | logIn                         |
| POST        | /api/users              | register                      |
| PUT         | /api/users/{id}         | Update an existing user       |

### Products

| HTTP Method | Endpoint                | Description                   |
|-------------|-------------------------|-------------------------------|
| GET         | /api/Products           | Get all products              |
| GET         | /api/Products/search    | Get products by search        |
| POST        | /api/Products           | Create a new product          |

### Categories

| HTTP Method | Endpoint                | Description                   |
|-------------|-------------------------|-------------------------------|
| GET         |/api/Categories          | Get all categories            |
| POST        |/api/Categories          | Create a new category         |

### Orders


| HTTP Method | Endpoint                | Description                   |
|-------------|-------------------------|-------------------------------|
| GET         |/api/Orders/{id}         |Get a specific order by ID     |
| POST        |/api/Orders              | Create a new order            |

### passwords

| HTTP Method | Endpoint                | Description                   |
|-------------|-------------------------|-------------------------------|
| POST        |/api/passwords           | Create a new password         |

## Dependencies

- ASP.NET Core 
- Entity Framework Core 


## Configuration

The configuration for the project can be found in the `appsettings.json` file. It includes the following settings:

- connection string: Defining the database connection statement

