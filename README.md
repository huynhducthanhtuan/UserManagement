# UserManagement — Simple SDK and Web API

**Short summary**

- This project have two main parts:
  - `UserMgmt.Sdk` — HTTP SDK client that calls external data sources
  - `UserMgmt.Api` — Web API that consumes the SDK client

**Why**

- Demonstrates an SDK client injected into the Web API and how to map external JSON APIs into local DTOs.

**Quick Run**

- **Restore & build:**

```bash
dotnet restore
dotnet build
```

- **Run Web API:**

```bash
dotnet run --project UserMgmt.Api/UserMgmt.Api.csproj
```

The API listens on `https://localhost:44394` by default (see [UserMgmt.Api/Program.cs](UserMgmt.Api/Program.cs)).

**Endpoints**

- **GET** `https://localhost:44394/api/v1/users`
- **GET** `https://localhost:44394/api/v1/products`

**Notes about DI / BaseAddress**

- The SDK client is registered via `AddUserMgmtSdk(string baseUrl)` in [UserMgmt.Sdk/Extensions/ServiceCollectionExtensions.cs](UserMgmt.Sdk/Extensions/ServiceCollectionExtensions.cs).
- `UserMgmt.Api` currently configures the SDK base URL to `https://dummyjson.com/` in [UserMgmt.Api/Program.cs](UserMgmt.Api/Program.cs), so the SDK calls `users` and `products` paths relative to that base address.

**Behavior**

- The SDK deserializes wrapper responses from the external APIs (`{ users: [...], total, skip, limit }` and `{ products: [...], total, skip, limit }`) into `UsersResponse` / `ProductsResponse` and returns the inner collections.
