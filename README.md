# Modernization & Migration Guides

This repository helps teams migrate from **ASP.NET Web Forms (Framework 4.8)** to **ASP.NET Core (.NET 8)** and a **modern SPA (Angular)**.

It contains:
- `LegacyWebFormsApp/` — a tiny Web Forms sample app to serve as the *source*.
- `ModernizedApi/` — a modern **.NET 8** Web API using **minimal hosting**, **EF Core InMemory** (so it runs without DB setup), and **DTOs**.
- `AngularClient/` — a lightweight folder with structure & instructions to scaffold Angular.
- `Docs/` — practical **playbook**, **mapping guide**, and **checklists**.

> Goal: Give you a **clear reference** and **executable modern baseline** that you can expand.

---

## Quick Start

### Run the Modern API (no DB required)
1. Install **.NET 8 SDK**.
2. In a terminal:
   ```bash
   cd ModernizedApi
   dotnet run
   ```
3. Browse API:
   - `GET http://localhost:5178/api/users`
   - `POST http://localhost:5178/api/users` (JSON body)

### (Optional) Try the Legacy Web Forms sample
Open `LegacyWebFormsApp` as an **ASP.NET Web Site** in Visual Studio (Framework 4.8) and run with IIS Express.

### (Optional) Angular Client
See `AngularClient/README.md` to scaffold Angular 17+ quickly and connect to the API.

---

## Highlights in the Modern API
- **Controllers** with clean **DTOs** (no EF entities over the wire).
- **EF Core InMemory** for demo simplicity.
- **Repository/Service pattern** for testability.
- **Automapper-lite** mapping (handwritten) to keep dependencies minimal.
- **CORS** enabled for local Angular dev.

---

## Migration Artifacts
- `Docs/Migration-Playbook.md` — step-by-step modernization plan.
- `Docs/WebForms-to-Core-Mapping.md` — examples mapping Web Forms pages/events → REST endpoints + Angular views.
- `Docs/Checklist.md` — modernization readiness & cutover checklist.

---

## License
MIT
