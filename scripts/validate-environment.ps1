# Run from repo root
Write-Host "=== dotnet version ==="
dotnet --version
Write-Host "=== dotnet sdks ==="
dotnet --list-sdks
Write-Host "=== dotnet runtimes ==="
dotnet --list-runtimes
Write-Host "=== git ==="
git --version
Write-Host "=== git lfs ==="
git lfs version 2>$null
Write-Host "=== dotnet-ef ==="
dotnet ef --version 2>$null

