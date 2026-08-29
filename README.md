# InspoBoard

InspoBoard is a RESTful ASP.NET Core Web API for creating and managing inspiration boards and the items associated with them.

This project is primarily focused on learning and demonstrating API development with **ASP.NET Core**, **Entity Framework Core**, and **SQLite**, including CRUD operations, DTOs, routing, model relationships, and database migrations. 

The concept of inspiration boards was ✨inspired✨ by my personal project workflow.

## Technologies

- **C#**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQLite**
- **LINQ**
## Features

- Create, retrieve, update, and delete boards
- Add inspiration items to boards
- Retrieve items belonging to a specific board
- Update and delete individual items
- Board → Item one-to-many relationship
- DTOs for API request and response models
- Entity Framework Core for data access
- SQLite database
- EF Core migrations
- RESTful HTTP endpoints

## API Structure

Items belong to a board and cannot exist independently of one.

The API therefore uses nested routes for item operations:

```
/api/boards/{boardId}/items
/api/boards/{boardId}/items/{itemId}
```
### Boards

| Method | Endpoint | Description |
|:---:|---|---|
| `GET` | `/api/boards` | Get all boards |
| `GET` | `/api/boards/{boardId}` | Get a specific board |
| `POST` | `/api/boards` | Create a board |
| `PUT` | `/api/boards/{boardId}` | Update a board |
| `DELETE` | `/api/boards/{boardId}` | Delete a board |

### Items

| Method | Endpoint | Description |
|:---:|---|---|
| `GET` | `/api/boards/{boardId}/items` | Get all items for a board |
| `GET` | `/api/boards/{boardId}/items/{itemId}` | Get a specific item |
| `POST` | `/api/boards/{boardId}/items` | Add an item to a board |
| `PUT` | `/api/boards/{boardId}/items/{itemId}` | Update an item |
| `DELETE` | `/api/boards/{boardId}/items/{itemId}` | Delete an item |

Run the API
```
dotnet run
```
The application will display the address it is listening on, for example:
```
Now listening on: http://localhost:5000
```

### Testing
The API can be tested using the .http file included with the project.

For instance:
```
### Get all boards
GET {{baseUrl}}/api/boards

### Create a board
POST {{baseUrl}}/api/boards
Content-Type: application/json
{
    "name": "Travel"
}

### Get a board
GET {{baseUrl}}/api/boards/1

### Create an item
POST {{baseUrl}}/api/boards/1/items
Content-Type: application/json

{
    "description": "Places I want to visit",
    "imageUrl": "https://example.com/image.jpg"
}

### Get board items
GET {{baseUrl}}/api/boards/1/items
```

### Database Migrations
When making changes to the Entity Framework Core models, create a migration:
```
dotnet ef migrations add <MigrationName>
```
Then apply the migration to the database:
```
dotnet ef database update
```
For example:
```
dotnet ef migrations add AddItemsToBoards
dotnet ef database update
```

### Apply Database Migrations
Create or update the local database using the existing EF Core migrations:

```
dotnet ef database update
```
