# Module and Dependency Overview

Related Stories: [Story ID]

## Module Map

- {ProjectName}.Api
- {ProjectName}.Application
- {ProjectName}.Domain
- {ProjectName}.Infrastructure

## Dependency Rules

- Api depends on Application and Infrastructure
- Application depends on Domain
- Domain has no dependencies
- Infrastructure depends on Domain and Application

