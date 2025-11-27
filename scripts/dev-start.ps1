# Run from repo root: ./scripts/dev-start.ps1
param()
$env:ASPNETCORE_ENVIRONMENT = "Development"

# Ensure dev cert is trusted if you want HTTPS (optional)
# dotnet dev-certs https --trust

# Start the app with hot reload on HTTP port 3000
dotnet watch --project src\NZFTC.Server run --urls "http://0.0.0.0:5000"

