# create-db.ps1 - creates data folder and an empty app.db for local dev
\ = Join-Path (Split-Path -Parent \F:\NZFTC\scripts) '..\data'
if (-not (Test-Path \)) { New-Item -ItemType Directory -Path \ -Force | Out-Null }
\ = Join-Path \ 'app.db'
if (-not (Test-Path \)) { New-Item -ItemType File -Path \ -Force | Out-Null; Write-Host 'Created empty DB file: ' \ } else { Write-Host 'DB already exists: ' \ }
