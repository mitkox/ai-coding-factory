#!/bin/bash
set -e

ERRORS=0

check_file() {
  local file=$1
  if [[ -f "$file" ]]; then
    echo "✓ $file"
  else
    echo "✗ Missing $file"
    ((ERRORS++))
  fi
}

echo "📄 Validating required documentation..."

check_file "docs/governance/GOVERNANCE.md"
check_file "docs/traceability/TRACEABILITY.md"
check_file "docs/agile/SCRUM-TEAM-AS-CODE.md"
check_file "docs/testing/TESTING-STRATEGY.md"
check_file "docs/documentation/DOCUMENTATION-REQUIREMENTS.md"

check_file "templates/clean-architecture-solution/docs/architecture/architecture.md"
check_file "templates/clean-architecture-solution/docs/modules/modules.md"
check_file "templates/clean-architecture-solution/docs/api/openapi.md"
check_file "templates/clean-architecture-solution/docs/operations/deployment.md"

check_file "templates/microservice-template/docs/architecture/architecture.md"
check_file "templates/microservice-template/docs/modules/modules.md"
check_file "templates/microservice-template/docs/api/openapi.md"
check_file "templates/microservice-template/docs/operations/deployment.md"

echo ""
if [[ $ERRORS -eq 0 ]]; then
  echo "✅ Documentation validation passed"
else
  echo "❌ Documentation validation failed: $ERRORS missing files"
fi

exit $ERRORS
