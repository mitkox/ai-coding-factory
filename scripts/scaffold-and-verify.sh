#!/bin/bash
set -euo pipefail

ROOT="$(cd "$(dirname "$0")/.." && pwd)"
TEMPLATE="$ROOT/templates/clean-architecture-solution"
DEST="$ROOT/artifacts/scaffold/Acf.Sample"
PROJECT_NAME="Acf.Sample"

if [[ ! -d "$TEMPLATE" ]]; then
  echo "Template not found: $TEMPLATE"
  exit 1
fi

rm -rf "$DEST"
mkdir -p "$DEST"
cp -R "$TEMPLATE"/. "$DEST"

python3 - <<PY
import pathlib
import re

project_name = "${PROJECT_NAME}"
root = pathlib.Path("${DEST}")

for path in root.rglob("*"):
    if path.is_dir():
        continue
    if path.name.startswith("."):
        continue
    try:
        text = path.read_text(encoding="utf-8")
    except Exception:
        continue
    text = text.replace("ProjectName", project_name)
    text = text.replace("{ProjectName}", project_name)
    path.write_text(text, encoding="utf-8")

for path in sorted(root.rglob("*ProjectName*"), reverse=True):
    new_name = path.name.replace("ProjectName", project_name)
    path.rename(path.with_name(new_name))
PY

pushd "$DEST" > /dev/null

dotnet restore

dotnet build -c Release

dotnet test -c Release --collect:"XPlat Code Coverage"

popd > /dev/null

mkdir -p "$ROOT/artifacts/coverage"
COVERAGE_FILE=$(find "$DEST/tests" -type f -path "*UnitTests*/TestResults/*/coverage.cobertura.xml" | head -n 1 || true)
if [[ -z "$COVERAGE_FILE" ]]; then
  COVERAGE_FILE=$(find "$DEST" -type f -name "coverage.cobertura.xml" | head -n 1 || true)
fi
if [[ -z "$COVERAGE_FILE" ]]; then
  echo "Coverage file not found"
  exit 1
fi

cp "$COVERAGE_FILE" "$ROOT/artifacts/coverage/coverage.cobertura.xml"

python3 "$ROOT/scripts/coverage/check-coverage.py" \
  --coverage-file "$ROOT/artifacts/coverage/coverage.cobertura.xml" \
  --min-line 0.8 \
  --min-branch 0.8 \
  --package-pattern "\\.Domain(\\.|$)" \
  --package-pattern "\\.Application(\\.|$)"

python3 "$ROOT/scripts/traceability/traceability.py" validate \
  --stories-dir "$ROOT/artifacts/stories" \
  --tests-root "$DEST/tests" \
  --skip-commits

python3 "$ROOT/scripts/traceability/traceability.py" report \
  --stories-dir "$ROOT/artifacts/stories" \
  --tests-root "$DEST/tests" \
  --skip-commits \
  --output "$ROOT/artifacts/traceability/traceability-report.md"

python3 "$ROOT/scripts/traceability/traceability.py" release-notes \
  --stories-dir "$ROOT/artifacts/stories" \
  --tests-root "$DEST/tests" \
  --skip-commits \
  --output "$ROOT/artifacts/traceability/release-notes.md" \
  --coverage-file "$ROOT/artifacts/coverage/coverage.cobertura.xml"

if command -v docker >/dev/null 2>&1; then
  docker build -t acf-sample -f "$DEST/docker/Dockerfile" "$DEST"
else
  echo "Docker not installed; skipping container build"
fi
