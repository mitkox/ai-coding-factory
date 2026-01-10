<div align="center">

# AI Coding Factory

Enterprise-grade internal software delivery platform for private, traceable, and governed .NET development. Open source and GitHub-ready, with optional Azure DevOps support.

Repository: https://github.com/mitkox/ai-coding-factory

[Features](#features) | [Quick Start](#quick-start) | [Governance](#governance-and-traceability) | [How To Verify](#how-to-verify)

</div>

---

## Overview

AI Coding Factory turns local inference into an **internal delivery platform** that replaces outsourcing with auditable, automated, and private software delivery. The platform enforces **quality, security, traceability, and governance by default** while staying fully offline-capable.

## Features

### Privacy-First AI Delivery
- Local inference with vLLM or LM Studio (OpenAI-compatible API)
- `.env.example` for configuration; no secrets in repo
- Air-gapped deployment guidance and least-privilege agent permissions

### Enterprise Governance and Traceability
- Definition of Done/Ready templates with explicit traceability rules
- Story -> Test -> Commit -> Release enforcement
- Automated traceability reports and release notes
- Governance policy covering branching, reviews, ownership, and risk

### Enterprise DevOps Choice (GitHub or Azure DevOps)
- GitHub Issues/Projects or Azure Boards for backlog and story tracking
- GitHub or Azure Repos for PRs and code review
- GitHub Actions or Azure Pipelines for CI quality gates and release readiness

### .NET 8+ Clean Architecture Templates
- Clean Architecture solution template with DDD/CQRS ready structure
- Microservice template with Kubernetes manifests
- Documentation and testing requirements baked in

### Agile-Native Delivery with AI Scrum Teams
- Scrum Team as Code: PO, Scrum Master, Dev, QA, Security, DevOps agents
- Sprint planning, execution, review, and retrospective workflows
- Traceability and quality gates enforced by agents

### Agents and Skills

**Stage agents**: `ideation`, `prototype`, `poc`, `pilot`, `product`  
**Scrum team agents**: `product-owner`, `scrum-master`, `developer`, `qa`, `security`, `devops`  
**Skills**: 12 reusable .NET skills in `.opencode/skill`

## Repository Map

```
ai-coding-factory/
├── .opencode/                      # Agents, skills, prompts, templates
├── docs/                           # Governance, traceability, testing, Scrum
├── templates/                      # Clean Architecture + microservice templates
├── scripts/                        # Validation, traceability, scaffold verification
├── artifacts/                      # Traceability outputs (sample + generated)
├── azure-pipelines.yml             # Azure DevOps CI pipeline
├── .github/workflows/quality-gates.yml # GitHub Actions CI pipeline (optional)
└── README.md
```

## Governance and Traceability

- Corporate R&D Development Policy (authoritative): `CORPORATE_RND_POLICY.md`
- Governance policy: `docs/governance/GOVERNANCE.md`
- Traceability model: `docs/traceability/TRACEABILITY.md`
- Scrum Team as Code: `docs/agile/SCRUM-TEAM-AS-CODE.md`
- Testing strategy: `docs/testing/TESTING-STRATEGY.md`
- Documentation requirements: `docs/documentation/DOCUMENTATION-REQUIREMENTS.md`

## Quick Start

### Prerequisites

- .NET 8 SDK
- Python 3
- Docker (for container verification)
- Local inference server (vLLM or LM Studio)
- GitHub or Azure DevOps project (Issues/Boards, Repos, Actions/Pipelines)

### 0) Clone the Repository (GitHub)

```bash
git clone https://github.com/mitkox/ai-coding-factory.git
cd ai-coding-factory
```

### 1) Configure Local Inference

Update `.opencode/opencode.json` or set values in `.env.example`:

```json
{
  "provider": {
    "local-inference": {
      "type": "openai-compatible",
      "baseUrl": "http://localhost:8000/v1",
      "apiKey": "your-api-key"
    }
  }
}
```

### 2) Start Inference Server

**vLLM:**
```bash
vllm serve GLM-4.7 --dtype auto --api-key your-api-key
```

**LM Studio:**
- Load a model
- Enable OpenAI-compatible server

### 3) Run OpenCode

```bash
opencode
/agent product-owner
```

### 4) Connect to GitHub or Azure DevOps

- Create a GitHub or Azure DevOps project
- Use GitHub Issues/Projects or Azure Boards for story tracking
- Configure GitHub Actions or Azure Pipelines to run CI checks

## How To Verify

Run the full lifecycle verification (build, test, coverage, traceability, container):

```bash
chmod +x scripts/scaffold-and-verify.sh
./scripts/scaffold-and-verify.sh
```

Additional checks:

```bash
./scripts/validate-project.sh
./scripts/validate-documentation.sh
./scripts/validate-rnd-policy.sh
python3 scripts/traceability/traceability.py validate --commit-range origin/main..HEAD
```

If you use Azure DevOps, the same checks run in `azure-pipelines.yml`. For GitHub, use `.github/workflows/quality-gates.yml`.

## Security and Offline Guidance

- No secrets committed; use `.env` locally
- Inference endpoints should bind to localhost or a protected subnet
- Use least-privilege permissions in `.opencode/opencode.json`
- Air-gapped use: mirror dependencies and disable external MCP integrations

## License

MIT License. See `LICENSE`.

## Made with ❤️

Made with ❤️ by Mitko X.
