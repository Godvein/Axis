# Axis

**Axis** is a web-based task and user management system built with **ASP**.**NET** **MVC** and **SQL** Server. It provides role-based administration, task assignment and tracking, user management, and secure authentication.

The project was developed to practice and demonstrate enterprise-style .**NET** application architecture, database-driven development, and secure web application development.

---

## Features

### User Management

- Create, edit, view, and delete users
- Role-based user management
- User dashboard
- Session-based authentication

### Task Management

- Create and assign tasks
- Edit and delete tasks
- Task details and status tracking
- Task priorities and due dates
- Mark tasks as completed
- Pending and overdue task tracking
- User-specific task dashboard

### Role Management

- Create roles
- Edit roles
- Delete roles
- Assign roles to users

### Security

- Session-based authentication
- Server-side and client-side validation

---

## Architecture

Axis follows a layered architecture that separates the application's responsibilities into different projects.

```text
    Axis.Web
    │
    ▼
    Axis.Services
    │
    ▼
    Axis.Repositories
    │
    ▼
    Axis.Models
```

### Axis.Web

The presentation layer responsible for:

- **MVC** Controllers
- Razor Views
- **HTTP** requests and responses
- Model binding
- Client-side validation
- Application configuration
- Authentication and web-specific attributes

### Axis.Services

The service layer contains application and business logic.

Responsibilities include:

- Processing application operations
- Coordinating repositories
- Applying business rules
- Acting as the intermediary between controllers and repositories

### Axis.Repositories

The data access layer responsible for communication with **SQL** Server.

Responsibilities include:

- Executing stored procedures
- Querying and modifying database data
- Dapper-based data access
- Mapping database results to application models

### Axis.Models

Contains shared application models and ViewModels used throughout the application.

---

## Technology Stack

### Backend

- C#
- **ASP**.**NET** **MVC**
- **ASP**.**NET** Web **API**
- .**NET**
- Razor

### Database

- Microsoft **SQL** Server
- T-**SQL**
- Stored Procedures

### Data Access

- Dapper
- **ADO**.**NET** / `SqlConnection`

### Frontend

- **HTML**
- **CSS**
- Bootstrap
- JavaScript
- jQuery

### Development Tools

- Visual Studio
- Git
- GitHub / GitLab

---

## Database

Axis uses **Microsoft **SQL** Server** as its primary database.

Database operations are primarily implemented using stored procedures.

Examples of database operations include:

- User management
- Task management
- Role management
- Dashboard statistics
- Authentication
- Data retrieval and reporting

Database initialization and **SQL** scripts are located in:

```text Axis.Web/Database ```

---

## Data Access with Dapper

Axis uses **Dapper** as its primary data-access library.

Dapper is used to execute stored procedures and map returned database records to C# models.

For example:

```csharp
var tasks = connection.Query<TaskListViewModel>(
    *usp_GetTasks*,
    commandType: CommandType.StoredProcedure
).ToList();
```

Dapper provides lightweight object mapping while allowing **SQL** and stored procedures to remain under direct control of the application.

---

## Repository Pattern

The application uses the Repository Pattern to separate database access from the rest of the application.

For example:

```text
Controller
    ↓
Service
    ↓
Repository
    ↓
**SQL** Server
```

Controllers do not directly execute database queries. Instead, they communicate with services, which use repositories for data access.

This improves:

- Separation of concerns
- Maintainability
- Testability
- Code organization

---
# Run Axis Without Building using docker

You can run Axis using the pre-built Docker images without installing the .**NET** **SDK**, **SQL** Server, or building the project locally.

### Install Docker Desktop

Download and install Docker Desktop from the official Docker website:

[https://docs.docker.com/get-started/get-docker/](https://docs.docker.com/get-started/get-docker/)

Make sure Docker Desktop is running before continuing.

### Download docker-compose.yml

Download the docker-compose.yml file from this repository and place it in an empty folder.

You only need this file to run the pre-built application.

### Start Axis

Open a terminal in the folder containing docker-compose.yml and run:

docker compose up

Docker will automatically download the required images and start Axis

### Open Axis

Once the containers have started, open:

[http://localhost:**8080**](http://localhost:8080) 

### Default Login 
- Username: Admin 
- Password: admin123 

### Stop Axis

Press Ctrl + C, or run:

docker compose down

## Build Axis

### Prerequisites

Make sure the following are installed:

- Visual Studio
- .**NET** **SDK**
- Microsoft **SQL** Server
- **SQL** Server Management Studio or another **SQL** Server client

### 1. Clone the Repository

```bash
git clone <repository-url> cd Axis 
```

### 2. Configure the Database

Update the connection string in:

``` Axis.Web/appsettings.json ```

Example:

```json
{
    *ConnectionStrings*: {
    *DefaultConnection*: "Server=localhost;Database=AxisDB;Trusted_Connection=True;TrustServerCertificate=True;"
    }
}
```

### 3. Initialize the Database

Run the **SQL** scripts located in:

``` Axis.Web/Database ```

These scripts create the required database objects and stored procedures.

### 4. Build the Solution

Open:

``` Axis.slnx ```

in Visual Studio and build the solution.

### 5. Run the Application

Set **Axis.Web** as the startup project and run the application from Visual Studio.

---

## Development Goals

Axis was developed with the following goals:

- Practice **ASP**.**NET** **MVC** development
- Understand layered application architecture
- Implement the Repository and Service Layer patterns
- Work with **SQL** Server and stored procedures
- Learn Dapper-based data access
- Implement authentication and authorization
- Apply secure coding practices
- Build and maintain a multi-project .**NET** solution

---

## Future Improvements

Potential future improvements include:

- Automated unit and integration testing
- Improved authorization policies
- Pagination and advanced task filtering
- Centralized exception handling
- Logging and monitoring
- Improved **API** documentation
- Docker containerization
- CI/CD pipeline
- **IIS** deployment

---

## Author

**Ankit Dware**

Software Development / .**NET** Developer

---

## License

This project is intended for educational and development purposes.