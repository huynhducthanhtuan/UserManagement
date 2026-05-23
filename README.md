# UserManagement — Simple SDK and Web API (updated)

Short summary (VI):

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
dotnet run --project src/UserMgmt.Api/UserMgmt.Api.csproj
```

The API listens on `https://localhost:44394` by default (see [src/UserMgmt.Api/Program.cs](src/UserMgmt.Api/Program.cs)).

**Endpoints**

- **GET** `https://localhost:44394/api/v1/users`
- **GET** `https://localhost:44394/api/v1/products`

**Notes about DI / BaseAddress**

- The SDK client is registered via `AddUserMgmtSdk(string baseUrl)` in [src/UserMgmt.Sdk/Extensions/ServiceCollectionExtensions.cs](src/UserMgmt.Sdk/Extensions/ServiceCollectionExtensions.cs).
- `UserMgmt.Api` currently configures the SDK base URL to `https://dummyjson.com/` in [src/UserMgmt.Api/Program.cs](src/UserMgmt.Api/Program.cs), so the SDK calls `users` and `products` paths relative to that base address.

**Models**

- **User DTOs:** see [src/UserMgmt.Sdk/Models/UserDto.cs](src/UserMgmt.Sdk/Models/UserDto.cs) — includes nested types (`AddressDto`, `HairDto`, `BankDto`, `CompanyDto`, `CryptoDto`, ...).
- **Product DTOs:** see [src/UserMgmt.Sdk/Models/ProductDto.cs](src/UserMgmt.Sdk/Models/ProductDto.cs) and [src/UserMgmt.Sdk/Models/ProductsResponse.cs](src/UserMgmt.Sdk/Models/ProductsResponse.cs) — includes `ProductFullDto`, `ReviewDto`, `MetaDto`, etc.

**Behavior**

- The SDK deserializes wrapper responses from the external APIs (`{ users: [...], total, skip, limit }` and `{ products: [...], total, skip, limit }`) into `UsersResponse` / `ProductsResponse` and returns the inner collections.
