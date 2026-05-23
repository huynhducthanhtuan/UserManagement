# UserManagement — Simple User Management with SDK, DAL, and Web API

Short summary (VI):

- Đây là một project demo gồm 3 dịch vụ/assembly chính:
  - `UserMgmt.Sdk` — HTTP SDK
  - `UserMgmt.Dal` — simple DAL HTTP service (runs on port 3000)
  - `UserMgmt.Api` — Web API that consumes the SDK client (runs on port 5000)

Why this layout

- Demonstrates an internal SDK client (`IUserMgmtClient`) injected into `UserMgmt.Api` and a separate mock SDK HTTP server that exposes the same endpoints.

Quick run (in three terminals)

```bash
dotnet restore
dotnet build

# DAL server (mock HTTP server)
dotnet run --project src/UserMgmt.Dal/UserMgmt.Dal.csproj

# Web API (uses SDK client)
dotnet run --project src/UserMgmt.Api/UserMgmt.Api.csproj
```

Endpoints

- DAL server:
  - GET http://localhost:3000/api/Users
  - GET http://localhost:3000/api/Users/{name}

- Web API (forwards to SDK via injected client):
  - GET http://localhost:5000/api/Employees
  - GET http://localhost:5000/api/Employees/{name}

Notes about `BaseUrl` and DI

- The SDK client is registered via `AddUserMgmtSdk(string baseUrl)` implemented in [src/UserMgmt.Sdk/Extensions/ServiceCollectionExtensions.cs](src/UserMgmt.Sdk/Extensions/ServiceCollectionExtensions.cs).
- `UserMgmt.Api` sets the SDK base URL when registering the client in [src/UserMgmt.Api/Program.cs](src/UserMgmt.Api/Program.cs):

```csharp
// example in Program.cs
builder.Services.AddUserMgmtSdk("http://localhost:3000");
```
