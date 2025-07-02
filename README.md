# TaskManagerPro API

A secure, full-stack-ready task management REST API built with **C#**, **ASP.NET Core**, and **PostgreSQL**. Designed for task tracking, filtering, sorting, and user authentication with modern best practices like **JWT-based authorization** and **DTO separation**.

---

## 🚀 Features

- ✅ User Registration & Secure Password Hashing
- ✅ JWT Authentication with Role-Based API Access
- ✅ Full CRUD for Task Management
- ✅ Filtering, Sorting & Pagination Support
- ✅ Clean DTO-based Request & Response Model
- ✅ Modular, Testable Code with AutoMapper
- ✅ Environment-Safe Secret Handling (via `appsettings.Development.json` & Environment Variables)
- ✅ Ready for Docker & Cloud Deployment (future enhancements planned)

---

## 🔧 Tech Stack

- **Backend:** C#, ASP.NET Core, .NET 8
- **Database:** PostgreSQL
- **Authentication:** JWT (HMAC SHA-512)
- **ORM:** Entity Framework Core
- **Object Mapping:** AutoMapper
- **API Docs:** Swagger UI
- **Security:** Environment variable support for sensitive keys

---

## 🛠️ Setup & Run

**Requirements:**\
✔️ [.NET 8 SDK](https://dotnet.microsoft.com/download)\
✔️ [PostgreSQL](https://www.postgresql.org/download/)

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/TaskManagerPro.API.git
cd TaskManagerPro.API
```

### 2. Set Up Environment Variables

For local development:

**Windows CMD**

```bash
set Jwt__Key=YourSuperLongSecureJwtKeyAtLeast64Characters
```

**PowerShell**

```powershell
$env:Jwt__Key="YourSuperLongSecureJwtKeyAtLeast64Characters"
```

**Linux/macOS**

```bash
export Jwt__Key=YourSuperLongSecureJwtKeyAtLeast64Characters
```

### 3. Configure Database

Update `appsettings.Development.json` with your local database credentials:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=TaskManagerProDb;Username=postgres;Password=YourPassword"
}
```

Create the database and apply migrations:

```bash
dotnet ef database update
```

### 4. Run the API

```bash
dotnet run
```

Swagger UI available at: [https://localhost](https://localhost\:PORT/swagger)[:PORT](https://localhost\:PORT/swagger)[/swagger](https://localhost\:PORT/swagger)

---

## 🔒 Security Notes

- Never commit real secrets. The `.gitignore` prevents accidental leaks of `appsettings.Development.json`.
- Production deployments should use secure environment variables for all sensitive keys.

---

## 🛠️ Planned Improvements

- Docker containerization
- Unit & Integration Tests
- Role-Based Authorization Enhancements
- Frontend Integration Example

---

## 📫 Contact

*Developed by Nicholas Roehl*\
*Open to feedback, collaboration, and contributions.*

