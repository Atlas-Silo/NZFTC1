MockServices project
- Provides in-memory implementations of service interfaces used by the UI while DB work is in progress.
- Use UseMocks = true in appsettings.Development.json to wire these into DI.
- Implement additional stub methods as the API contract grows.