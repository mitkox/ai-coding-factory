# Documentation Requirements

## Required Documentation (Generated Projects)

Each generated project must include:

- Architecture overview
- Module and dependency overview
- API documentation (OpenAPI)
- Deployment and operations docs

## Required Paths

- `docs/architecture/architecture.md`
- `docs/modules/modules.md`
- `docs/api/openapi.md`
- `docs/operations/deployment.md`

## Traceability in Docs

When a document is updated due to a story, include a reference in the document header:

```
Related Stories: ACF-123
```

## Validation

`./scripts/validate-documentation.sh` enforces presence of required documentation.

