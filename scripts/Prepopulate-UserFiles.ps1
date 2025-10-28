<#
  scripts/Prepopulate-UserFiles.ps1
  Usage:
    .\Prepopulate-UserFiles.ps1 -PersonName "Victor" -DevRoot ".\NZFTC.Victor"
#>

param(
  [Parameter(Mandatory=$true)][string]$PersonName,
  [Parameter(Mandatory=$true)][string]$DevRoot
)

if (-not (Test-Path $DevRoot)) {
  Write-Error "DevRoot not found: $DevRoot. Run Generate-ProjectStructure.ps1 first."
  exit 1
}

$target = Join-Path (Resolve-Path $DevRoot) "src/Contributions/$PersonName"
if (-not (Test-Path $target)) { New-Item -ItemType Directory -Path $target -Force | Out-Null; Write-Host "Created contribution folder: $target" } else { Write-Host "Contribution folder exists: $target" }

# README for contributor
$cn = Join-Path $target "README.$PersonName.md"
@"
# Contributions by $PersonName

Follow naming:
- Branch: feature/<initials>-short-description
- File names: PascalCase.cs
Place your completed work here and add a short integration note.
"@ | Out-File -FilePath $cn -Encoding UTF8

# Placeholder files
$notes = Join-Path $target "Notes.$PersonName.md"
@"
Notes for $PersonName
"@ | Out-File -FilePath $notes -Encoding UTF8

$config = Join-Path $target "$PersonName.Config.json"
@"
{
  ""Author"": ""$PersonName""
}
"@ | Out-File -FilePath $config -Encoding UTF8

Write-Host "Prepopulation complete for $PersonName"