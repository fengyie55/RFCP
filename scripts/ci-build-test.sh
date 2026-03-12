#!/usr/bin/env bash
set -euo pipefail

ROOT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
SOLUTION_FILE="$ROOT_DIR/RFCP.sln"

if ! command -v dotnet >/dev/null 2>&1; then
  echo "Error: dotnet SDK is not installed or not in PATH." >&2
  exit 1
fi

echo "==> Restoring dependencies"
dotnet restore "$SOLUTION_FILE"

echo "==> Building solution (Release)"
dotnet build "$SOLUTION_FILE" --configuration Release --no-restore

echo "==> Running tests"
mapfile -t test_projects < <(find "$ROOT_DIR" -type f -name '*.csproj' \
  | grep -E '(Test|Tests)\.csproj$' || true)

if (( ${#test_projects[@]} == 0 )); then
  echo "No test projects found (*Test.csproj / *Tests.csproj). Skipping tests."
  exit 0
fi

for project in "${test_projects[@]}"; do
  echo "Running tests: ${project#"$ROOT_DIR/"}"
  dotnet test "$project" --configuration Release --no-build --logger "trx;LogFileName=test-results.trx"
done
