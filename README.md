# Abilities API (.NET 9 Preview)

This repository contains a minimal ASP.NET Core **9.0** Web API that exposes a single `/test` endpoint and an accompanying integration-test project.

---

## Prerequisites

* [.NET 9 SDK (preview)](https://dotnet.microsoft.com/download/dotnet/9.0) installed and available on your `PATH`.

> ⚠️  .NET 9 is currently in preview. Make sure to install a preview SDK that matches the target framework `net9.0` used in the project files.

---

## Getting Started

```bash
# Restore dependencies
$ dotnet restore

# Build the application & tests
$ dotnet build -c Release

# Run the API (from the repository root)
$ dotnet run --project src/Abilities.Api
```

The API will start (by default) at `https://localhost:5001` and expose Swagger UI at `/swagger`.

### Test the Endpoint

```bash
curl https://localhost:5001/test --insecure
```

Expected response:

```json
{"message":"Endpoint is working"}
```

---

## Running the Automated Tests

```bash
# From the repository root
$ dotnet test
```

The test suite exercises the `/test` endpoint end-to-end using `WebApplicationFactory` from `Microsoft.AspNetCore.Mvc.Testing`.

---

## Project Layout

```
src/Abilities.Api               # Minimal API project
└── Program.cs                  # Defines the /test endpoint

test/Abilities.Api.Tests        # xUnit integration tests
└── TestEndpointTests.cs
```

---

## License

This project is released under the MIT license. 