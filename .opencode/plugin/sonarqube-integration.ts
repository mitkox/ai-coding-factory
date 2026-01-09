import type { Plugin } from "@opencode-ai/plugin";

export const SonarQubePlugin: Plugin = async ({ project, client, $ }) => {
  return {
    "tool.execute.after": async (input, output) => {
      if (input.tool === "bash" && output.args.command.includes("dotnet test")) {
        console.log("Running SonarQube scan...");
        try {
          await $`dotnet sonarscanner begin /k:${project.name} /d:sonar.host.url=${process.env.SONARQUBE_URL}`;
          await $`dotnet build`;
          await $`dotnet sonarscanner end`;
        } catch (error) {
          console.error("SonarQube scan failed:", error);
        }
      }
    },
  };
};