#!/bin/bash
# AI Coding Factory Project Validation Script
# Validates project structure and configuration

set -e

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

ERRORS=0
WARNINGS=0

echo "🔍 AI Coding Factory Project Validation"
echo "========================================="
echo ""

# Function to check if file exists
check_file() {
    local file=$1
    local required=$2
    
    if [[ -f "$file" ]]; then
        echo -e "${GREEN}✓${NC} File exists: $file"
        return 0
    else
        if [[ "$required" == "required" ]]; then
            echo -e "${RED}✗${NC} Missing required file: $file"
            ((ERRORS++))
            return 1
        else
            echo -e "${YELLOW}!${NC} Optional file missing: $file"
            ((WARNINGS++))
            return 0
        fi
    fi
}

# Function to check if directory exists
check_dir() {
    local dir=$1
    local required=$2
    
    if [[ -d "$dir" ]]; then
        echo -e "${GREEN}✓${NC} Directory exists: $dir"
        return 0
    else
        if [[ "$required" == "required" ]]; then
            echo -e "${RED}✗${NC} Missing required directory: $dir"
            ((ERRORS++))
            return 1
        else
            echo -e "${YELLOW}!${NC} Optional directory missing: $dir"
            ((WARNINGS++))
            return 0
        fi
    fi
}

# Function to validate JSON file
validate_json() {
    local file=$1
    
    if [[ -f "$file" ]]; then
        if python3 -m json.tool "$file" > /dev/null 2>&1; then
            echo -e "${GREEN}✓${NC} Valid JSON: $file"
            return 0
        else
            echo -e "${RED}✗${NC} Invalid JSON: $file"
            ((ERRORS++))
            return 1
        fi
    fi
}

# Function to check skill has required frontmatter
check_skill() {
    local skill_dir=$1
    local skill_file="$skill_dir/SKILL.md"
    
    if [[ -f "$skill_file" ]]; then
        if grep -q "^---" "$skill_file" && grep -q "^name:" "$skill_file"; then
            echo -e "${GREEN}✓${NC} Valid skill: $(basename $skill_dir)"
            return 0
        else
            echo -e "${YELLOW}!${NC} Skill missing frontmatter: $(basename $skill_dir)"
            ((WARNINGS++))
            return 0
        fi
    else
        echo -e "${RED}✗${NC} Missing SKILL.md: $skill_dir"
        ((ERRORS++))
        return 1
    fi
}

echo "📁 Checking Core Structure..."
echo "-----------------------------"
check_file "README.md" "required"
check_file "ARCHITECTURE.md" "required"
check_file "AGILE-METHODOLOGY.md" "required"
check_file "CONTRIBUTING.md" "required"
check_file "CHANGELOG.md" "required"
check_file "CORPORATE_RND_POLICY.md" "required"
check_file "LICENSE" "required"
check_file ".gitignore" "required"
check_file ".github/CODEOWNERS" "required"

echo ""
echo "⚙️  Checking OpenCode Configuration..."
echo "--------------------------------------"
check_dir ".opencode" "required"
check_file ".opencode/opencode.json" "required"
validate_json ".opencode/opencode.json"
check_dir ".opencode/agent" "required"
check_dir ".opencode/skill" "required"
check_dir ".opencode/prompts" "optional"
check_dir ".opencode/templates" "required"

echo ""
echo "🤖 Checking Agents..."
echo "---------------------"
for agent in ideation prototype poc pilot product; do
    check_file ".opencode/agent/${agent}-agent.md" "required"
done

echo ""
echo "🛠️  Checking Skills..."
echo "---------------------"
for skill_dir in .opencode/skill/*/; do
    if [[ -d "$skill_dir" ]]; then
        check_skill "$skill_dir"
    fi
done

echo ""
echo "📋 Checking Templates..."
echo "------------------------"
check_dir ".opencode/templates/agile" "required"
check_file ".opencode/templates/agile/user-story-template.md" "optional"
check_file ".opencode/templates/agile/definition-of-done.md" "optional"
check_file ".opencode/templates/agile/definition-of-ready.md" "optional"
check_file ".opencode/templates/agile/sprint-planning-template.md" "optional"
check_file ".opencode/templates/agile/sprint-retrospective-template.md" "optional"
check_file ".opencode/templates/agile/sprint-review-template.md" "optional"
check_file ".opencode/templates/agile/daily-standup-template.md" "optional"
check_file ".opencode/templates/artifacts/ADR-template.md" "required"
check_file ".opencode/templates/artifacts/threat-model-checklist.md" "required"
check_file ".opencode/templates/artifacts/security-review-checklist.md" "required"
check_file ".opencode/templates/artifacts/release-readiness-checklist.md" "required"
check_file ".opencode/templates/testing/xunit-story-test-template.cs" "required"

echo ""
echo "📂 Checking Project Templates..."
echo "---------------------------------"
check_dir "templates/clean-architecture-solution" "optional"
check_dir "templates/microservice-template" "optional"

echo ""
echo "📜 Checking Scripts..."
echo "----------------------"
check_dir "scripts" "required"
check_file "scripts/setup.sh" "required"
check_file "scripts/traceability/traceability.py" "required"
check_file "scripts/coverage/check-coverage.py" "required"
check_file "scripts/validate-documentation.sh" "required"
check_file "scripts/scaffold-and-verify.sh" "required"
if [[ -f "azure-pipelines.yml" || -f ".github/workflows/quality-gates.yml" ]]; then
    if [[ -f "azure-pipelines.yml" ]]; then
        echo -e "${GREEN}✓${NC} CI pipeline exists: azure-pipelines.yml"
    fi
    if [[ -f ".github/workflows/quality-gates.yml" ]]; then
        echo -e "${GREEN}✓${NC} CI workflow exists: .github/workflows/quality-gates.yml"
    fi
else
    echo -e "${RED}✗${NC} Missing CI pipeline (azure-pipelines.yml or .github/workflows/quality-gates.yml)"
    ((ERRORS++))
fi
check_file "templates/clean-architecture-solution/azure-pipelines.yml" "required"
check_file "templates/microservice-template/azure-pipelines.yml" "required"

echo ""
echo "========================================="
echo "Validation Complete"
echo "========================================="
echo ""

if [[ $ERRORS -eq 0 ]]; then
    echo -e "${GREEN}✓ All required checks passed!${NC}"
else
    echo -e "${RED}✗ Found $ERRORS error(s)${NC}"
fi

if [[ $WARNINGS -gt 0 ]]; then
    echo -e "${YELLOW}! Found $WARNINGS warning(s)${NC}"
fi

echo ""
echo "To fix issues:"
echo "  - Run scripts/setup.sh to create missing directories"
echo "  - Check .opencode/opencode.json for JSON syntax errors"
echo "  - Ensure all skills have SKILL.md with proper frontmatter"
echo ""

exit $ERRORS
