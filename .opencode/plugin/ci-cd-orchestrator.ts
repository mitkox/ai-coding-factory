import type { Plugin } from "@opencode-ai/plugin";

export const CICDOrchestratorPlugin: Plugin = async ({ project, client, $ }) => {
  return {
    "file.edited": async (input, output) => {
      const criticalFiles = [
        "src/", "Program.cs", "appsettings.json", "Dockerfile"
      ];

      if (criticalFiles.some(f => input.filePath.includes(f))) {
        console.log("Critical file modified. Consider triggering CI/CD pipeline.");
      }
    },
  };
};