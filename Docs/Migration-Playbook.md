# Migration Playbook (Web Forms → .NET 8 + SPA)

## 1) Inventory & Assess
- List all Web Forms pages (aspx), code-behind, user controls, HTTP Handlers.
- Identify shared libraries, data access patterns, and authentication model.
- Classify features: Keep, Replace, Retire.

## 2) Strangle the Monolith
- Introduce a **modern API** alongside the legacy app.
- Route new features to the API + SPA, keep legacy pages running.
- Gradually replace legacy endpoints (facade or reverse proxy if needed).

## 3) Data & Contracts
- Define **DTOs** independent of EF/database Schema.
- Use **versioned** endpoints for compatibility.

## 4) Security
- Centralize auth (OAuth2/OIDC with Azure AD/MS Entra).
- Apply OWASP best practices; enable security headers and proper logging.

## 5) UI Modernization
- Recreate essential views in Angular/Blazor with reusable components.
- Follow design system and accessibility standards.

## 6) Cutover
- Feature flags; dark launch; parallel run for critical paths.
- Telemetry (App Insights) and rollback plan.

## 7) Decommission
- Turn off unused pages; archive or delete dead code.
