# CodePulse

A full-stack web application featuring an ASP.NET Core backend and an Angular frontend

## 🚀 Getting Started

Follow these instructions to get the project up and running on your local machine for development and testing purposes.

### Prerequisites

Ensure you have the following installed:
* .NET SDK
* Node.js and npm
* SQL Server (Required for the Entity Framework Core database connection).
* Angular CLI (This project was generated using version 21.2.7).

---

## 🛠️ Backend Setup (ASP.NET Core)

The backend features endpoints for various services, including a Category Repository and a User Repository.

1. **Database Configuration:** The project uses Entity Framework Core with SQL Server. Ensure you configure the `CodePulseConnectionString` to point to your local SQL Server instance.
2. **Run the Application:** Start the application using `dotnet watch` The application is configured for the Development environment and will listen on `https://localhost:7106` and `http://localhost:5148`.
3. **API Documentation:** Once the server is running, you can access the Swagger UI by navigating to `/swagger` to explore the API endpoints.
4. **CORS:** The backend is configured to allow any header, any origin, and any method, making frontend integration straightforward during development.

---

## 🅰️ Frontend Setup (Angular)

1. **Install Dependencies:** Navigate to your frontend directory and run `npm install`.
2. **Development Server:** To start a local development server, run `ng serve`. 
3. **Access the Application:** Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

### Angular CLI Commands

* **Code Scaffolding:** To generate a new component, run `ng generate component component-name`. For a complete list of available schematics, run `ng generate --help`.
* **Building:** To build the project run `ng build`. This will compile your project and store the build artifacts in the `dist/` directory.
* **Running Unit Tests:** To execute unit tests with the Vitest test runner, use the `ng test` command.
* **Running End-to-End Tests:** For end-to-end (e2e) testing, run `ng e2e`.