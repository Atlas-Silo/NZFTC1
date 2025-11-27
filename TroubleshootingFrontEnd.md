# Front-End Troubleshooting Guide

Notes for changes made during troubleshooting connecting Frontend

- Added root redirect to Login: In `src/NZFTC.Server/Program.cs`, we map `/` to `/Account/Login` so the app lands on the login page instead of the default Index. Line added: `app.MapGet("/", () => Results.Redirect("/Account/Login"));`.

- Default page context: The framework still has `Pages/Index.cshtml`, but the explicit redirect ensures unauthenticated access goes to `Account/Login` first.

- Updated LoginModel to use custom Identity types: `Login.cshtml.cs` now injects `SignInManager<User>` and `UserManager<User>`, matching the Identity registration `AddIdentity<User, Role>` in `Program.cs`.

- Fixed namespace to match project root: `Login.cshtml.cs` namespace changed to `NZFTC.Server.Pages.Account` to align with `RootNamespace` (`NZFTC.Server`). The view uses a fully qualified model: `@model NZFTC.Server.Pages.Account.LoginModel`.

- Razor view model directive updated: In `Pages/Account/Login.cshtml`, set `@model NZFTC.Server.Pages.Account.LoginModel` so Razor’s generated code resolves the PageModel correctly.

## File References
- `src/NZFTC.Server/Program.cs`
- `src/NZFTC.Server/Pages/Account/Login.cshtml`
- `src/NZFTC.Server/Pages/Account/Login.cshtml.cs`

## Notes
- Identity must consistently use the custom `User` and `Role` entities across DI registrations, PageModels, and injected services.
- If hot reload or builds fail with `LoginModel not found`, verify the namespace and the `@model` directive are in sync with the project root.


