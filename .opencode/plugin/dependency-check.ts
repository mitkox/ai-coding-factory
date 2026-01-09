import type { Plugin } from "@opencode-ai/plugin";

export const DependencyCheckPlugin: Plugin = async ({ project, client, $ }) => {
  return {
    "tool.execute.after": async (input, output) => {
      if (input.tool === "bash" && output.args.command.includes("dotnet restore")) {
        console.log("Running dependency vulnerability check...");
        try {
          await $`dotnet list package --vulnerable --include-transitive`;
        } catch (error) {
          console.error("Dependency check failed:", error);
        }
      }
    },
  };
};