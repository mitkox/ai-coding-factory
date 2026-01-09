#!/bin/bash

# AI Coding Factory Setup Script
# This script sets up the AI Coding Factory environment

set -e

echo "🚀 Setting up AI Coding Factory..."

# Check if OpenCode is installed
if ! command -v opencode &> /dev/null; then
    echo "❌ OpenCode is not installed. Installing now..."
    curl -fsSL https://opencode.ai/install | bash
else
    echo "✅ OpenCode is already installed"
fi

# Create required directories
echo "📁 Creating directory structure..."
mkdir -p .opencode/agent .opencode/skill .opencode/plugin .opencode/prompts projects templates scripts

# Check if Node.js is installed for plugins
if ! command -v npm &> /dev/null; then
    echo "⚠️  Warning: npm is not installed. Required for some plugins."
    echo "   Install Node.js from https://nodejs.org/"
else
    echo "✅ Node.js is installed"
fi

# Check if Python is installed for vLLM
if ! command -v python3 &> /dev/null; then
    echo "⚠️  Warning: Python is not installed. Required for vLLM."
    echo "   Install Python from https://python.org/"
else
    echo "✅ Python is installed"
fi

# Create example configuration
if [ ! -f .opencode/opencode.json ]; then
    echo "📝 Creating example configuration..."
    cat > .opencode/opencode.json << 'EOF'
{
  "$schema": "https://opencode.ai/config.json",
  "model": {
    "default": "local-inference/GLM-4.7",
    "reasoning": "local-inference/GLM-4.7"
  },
  "provider": {
    "local-inference": {
      "type": "openai-compatible",
      "baseUrl": "http://localhost:8000/v1",
      "apiKey": "local-inference-key",
      "timeout": 120000
    }
  },
  "permission": {
    "bash": {
      "git *": "allow",
      "dotnet *": "allow",
      "docker *": "ask",
      "rg *": "allow",
      "find *": "allow",
      "sed *": "allow",
      "mkdir *": "allow",
      "ls *": "allow",
      "cat *": "allow",
      "*": "deny"
    },
    "edit": "ask",
    "write": "ask"
  },
  "agent": {
    "ideation": {
      "mode": "primary",
      "description": "Gathers requirements, creates user stories, defines architecture, implements Scrum practices",
      "model": "local-inference/GLM-4.7",
      "temperature": 0.7,
      "tools": {
        "write": true,
        "edit": true,
        "bash": false
      },
      "permission": {
        "skill": {
          "net-*": "allow",
          "net-agile": "allow",
          "net-scrum": "allow",
          "*": "deny"
        }
      }
    },
    "prototype": {
      "mode": "primary",
      "description": "Creates rapid MVP prototypes with minimal architecture, follows Scrum story format",
      "model": "local-inference/GLM-4.7",
      "temperature": 0.3,
      "tools": {
        "write": true,
        "edit": true,
        "bash": true
      },
      "permission": {
        "skill": {
          "net-*": "allow",
          "net-agile": "allow",
          "net-scrum": "allow",
          "*": "deny"
        }
      }
    },
    "poc": {
      "mode": "primary",
      "description": "Builds production-focused PoC with security, testing, and Scrum Definition of Done compliance",
      "model": "local-inference/GLM-4.7",
      "temperature": 0.2,
      "tools": {
        "write": true,
        "edit": true,
        "bash": true
      },
      "permission": {
        "skill": {
          "net-*": "allow",
          "net-agile": "allow",
          "net-scrum": "allow",
          "*": "deny"
        }
      }
    },
    "pilot": {
      "mode": "primary",
      "description": "Creates production-ready code with testing, docs, CI/CD, and Scrum sprint readiness",
      "model": "local-inference/GLM-4.7",
      "temperature": 0.1,
      "tools": {
        "write": true,
        "edit": true,
        "bash": true
      },
      "permission": {
        "skill": {
          "net-*": "allow",
          "net-agile": "allow",
          "net-scrum": "allow",
          "*": "deny"
        }
      }
    },
    "product": {
      "mode": "primary",
      "description": "Maintains, scales, monitors production applications, and conducts Scrum retrospectives",
      "model": "local-inference/GLM-4.7",
      "temperature": 0.1,
      "tools": {
        "write": true,
        "edit": true,
        "bash": true
      },
      "permission": {
        "skill": {
          "net-*": "allow",
          "net-agile": "allow",
          "net-scrum": "allow",
          "*": "deny"
        }
      }
    },
    "product-owner": {
      "mode": "primary",
      "description": "Owns story IDs, backlog priorities, and acceptance criteria",
      "model": "local-inference/GLM-4.7",
      "temperature": 0.3,
      "tools": {
        "write": true,
        "edit": true,
        "bash": false
      },
      "permission": {
        "skill": {
          "net-agile": "allow",
          "net-scrum": "allow",
          "*": "deny"
        }
      }
    },
    "scrum-master": {
      "mode": "primary",
      "description": "Enforces DoR/DoD, flow, and traceability compliance",
      "model": "local-inference/GLM-4.7",
      "temperature": 0.2,
      "tools": {
        "write": true,
        "edit": true,
        "bash": false
      },
      "permission": {
        "skill": {
          "net-agile": "allow",
          "net-scrum": "allow",
          "*": "deny"
        }
      }
    },
    "developer": {
      "mode": "primary",
      "description": "Implements stories with tests, docs, and traceability",
      "model": "local-inference/GLM-4.7",
      "temperature": 0.2,
      "tools": {
        "write": true,
        "edit": true,
        "bash": true
      },
      "permission": {
        "skill": {
          "net-*": "allow",
          "*": "deny"
        }
      }
    },
    "qa": {
      "mode": "primary",
      "description": "Ensures test linkage, coverage, and quality gates",
      "model": "local-inference/GLM-4.7",
      "temperature": 0.1,
      "tools": {
        "write": true,
        "edit": true,
        "bash": true
      },
      "permission": {
        "skill": {
          "net-testing": "allow",
          "*": "deny"
        }
      }
    },
    "security": {
      "mode": "primary",
      "description": "Performs threat modeling and security review",
      "model": "local-inference/GLM-4.7",
      "temperature": 0.1,
      "tools": {
        "write": true,
        "edit": true,
        "bash": true
      },
      "permission": {
        "skill": {
          "net-*": "allow",
          "*": "deny"
        }
      }
    },
    "devops": {
      "mode": "primary",
      "description": "Maintains CI/CD, releases, and deployment readiness",
      "model": "local-inference/GLM-4.7",
      "temperature": 0.1,
      "tools": {
        "write": true,
        "edit": true,
        "bash": true
      },
      "permission": {
        "skill": {
          "net-docker": "allow",
          "net-github-actions": "allow",
          "net-kubernetes": "allow",
          "*": "deny"
        }
      }
    }
  },
  "share": "disabled",
  "network": {
    "proxy": null
  }
}
EOF
    echo "✅ Configuration created"
else
    echo "✅ Configuration already exists"
fi

# Display next steps
echo ""
echo "✅ Setup complete!"
echo ""
echo "📋 Next steps:"
echo ""
echo "1. Configure your local inference server:"
echo "   Edit .opencode/opencode.json and update:"
echo "   - provider.local-inference.baseUrl (your inference server URL)"
echo "   - model.default (your preferred model)"
echo ""
echo "2. Start your local inference server:"
echo "   vLLM:"
echo "     pip install vllm"
echo "     vllm serve GLM-4.7 --dtype auto --api-key token-abc123"
echo ""
echo "   LM Studio:"
echo "     Download from https://lmstudio.ai"
echo "     Enable OpenAI-compatible server"
echo ""
echo "3. Create your first project:"
echo "   cd projects"
echo "   mkdir my-first-app"
echo "   cd my-first-app"
echo "   opencode"
echo "   /agent ideation"
echo ""
echo "4. Learn more:"
echo "   Read README.md for complete documentation"
echo ""
echo "🎉 Happy coding with AI Coding Factory!"
echo ""
