# TODO-APP

This is a full-stack project using **Vue 3** for the frontend and **.NET 9** for the backend.
The project is designed for task management with APIs hosted by the backend and a responsive user interface on the frontend.

---

## Prerequisites

1. **Frontend Requirements**:
   - Node.js
   - NPM

2. **Backend Requirements**:
   - .NET SDK 9.0
   - SQLite

3. **General Tools**:
   - Docker (for database)
   - Git (for version control)
   - Text editor or IDE
     - VS Code (for frontend)
     - Visual Studio (for backend)

---

## Cloning the Repository

Clone the repository and navigate into the project directory:

```bash
git clone https://github.com/WilloS88/todo-app.git
cd TODO-APP
```

---

## Installation
1. **Frontend**:
```bash
    cd todo-client
    npm install
    npm run dev
```

2. **Database**:
```bash
    cd api
    docker-compose up --build
```
make sure your Docker desktop app is on

3. **Backend**:
in Visual Studio open the api.sln file
```bash
    dotnet restore
```
if that command does not help, dowload NuGet packages manually

 - Dapper 
 - Microsoft.AspNetCore.Cors 
 - MySql.Data 
 - Swashbuckle.AspNetCore 
 - System.Data.SQLite

then simply press F5 to start the Backend

---

### Application

Make sure the FE, BE and DB is started then the app can be used without any issues.
