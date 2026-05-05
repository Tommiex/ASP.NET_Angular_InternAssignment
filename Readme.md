### Prerequisites

Installed:
* .NET SDK
* Node.js and npm
* SQL Server (Required for the Entity Framework Core database connection).
* Angular CLI (This project was generated using version 21.2.7).

---

## 🛠️ Backend Setup (ASP.NET Core)

1. **Database Configuration:** The project uses Entity Framework Core with SQL Server. Ensure you configure the `CodePulseConnectionString`
2. **Run the Application:** Start the application using `dotnet watch` The application is configured for the Development environment and will listen on `https://localhost:7106` and `http://localhost:5148`.
3. **API Documentation:** you can access the Swagger UI by navigating to `/swagger` to explore the API endpoints.

---

## 🅰️ Frontend Setup (Angular)

1. **Install Dependencies:** Navigate to ./UI and run `npm install`.
2. **Development Server:** To start a local development server, run `ng serve`. 
3. **Access the Application:** Once the server is running, open your browser and navigate to `http://localhost:4200/`. 

### Angular CLI Commands

* **Code Scaffolding:** To generate a new component, run `ng generate component component-name`. For a complete list of available schematics, run `ng generate --help`.
* **Building:** To build the project run `ng build`. 
* **Running Unit Tests:** To execute unit tests with the Vitest test runner, use the `ng test` command.
* **Running End-to-End Tests:** For end-to-end (e2e) testing, run `ng e2e`.