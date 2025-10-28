#!/usr/bin/env bash
echo "=== dotnet --version ==="
dotnet --version
echo "=== dotnet --list-sdks ==="
dotnet --list-sdks
echo "=== git --version ==="
git --version
echo "=== git lfs version ==="
git lfs version || true
echo "=== dotnet ef --version ==="
dotnet ef --version || true