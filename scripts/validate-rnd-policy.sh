#!/bin/bash
set -euo pipefail

echo "Validating Corporate R&D Policy artifacts..."

require_file() {
  local file="$1"
  if [[ ! -f "$file" ]]; then
    echo "ERROR: Missing required file: $file"
    exit 1
  fi
  echo "OK: $file"
}

require_file "../CORPORATE_RND_POLICY.md"
require_file "../docs/governance/GOVERNANCE.md"
require_file "../docs/traceability/TRACEABILITY.md"
require_file "../docs/testing/TESTING-STRATEGY.md"
require_file "../docs/documentation/DOCUMENTATION-REQUIREMENTS.md"

require_file "../.opencode/templates/agile/definition-of-done.md"
require_file "../.opencode/templates/agile/definition-of-ready.md"
require_file "../.opencode/templates/artifacts/ADR-template.md"
require_file "../.opencode/templates/artifacts/security-review-checklist.md"
require_file "../.opencode/templates/artifacts/threat-model-checklist.md"
require_file "../.opencode/templates/artifacts/release-readiness-checklist.md"

require_file "./traceability/traceability.py"
require_file "./coverage/check-coverage.py"

require_file "./traceability/traceability-report.md"
require_file "./traceability/release-notes.md"
echo "Corporate R&D Policy artifact validation passed"
