# GitHub Copilot Instructions for RimWorld Modding - DecorativeTrees

## Mod Overview and Purpose

**DecorativeTrees** is a RimWorld mod that introduces two unique trees that can only be grown in special pods. These decorative trees enhance the aesthetic appeal of the colony and offer additional benefits such as silver production and the ability to throw parties.

## Key Features and Systems

- **Decorative Tree Pot**: A special pot made of alien soil suitable only for growing modified trees. It's expensive and unsuitable for regular plants.
- **Silver Tree**: An unusual decorative tree that raises beauty and produces silver over its lifetime.
- **Party Tree**: A soft fir tree with a pleasant smell that can be used to throw parties.

## Coding Patterns and Conventions

- **C# File Structure**: The mod is organized into C# files, each containing specific classes and methods related to the functionality of the decorative trees. For example, `CompProperties_DecorativeTrees.cs` contains properties for the decorative trees, and `JobDriver_GoToThrowParty.cs` contains the job driver for throwing parties.
- **XML Integration**: The mod uses XML files to define various aspects of the decorative trees, such as their job definitions, thing definitions, and research project definitions. These files are located in the `Defs` directory.
- **Harmony Patching**: The mod uses Harmony patching to modify vanilla RimWorld behavior and integrate with other mods. Harmony patches are located in the `Patches` directory.

## XML Integration

The mod uses XML files to define various aspects of the decorative trees, including:

- **JobDefs/Jobs_Custom.xml**: Contains custom job definitions for the decorative trees, such as the job to throw a party.
- **ThingDefs/DecorativeTree.xml**: Contains thing definitions for the decorative trees, including their harvested thing definition, minified definition, and research project definition.

## Harmony Patching

The mod uses Harmony patching to modify vanilla RimWorld behavior and integrate with other mods. Specifically, it uses Harmony patches to:

- **Modify Job Definitions**: Modify existing job definitions to include new job drivers for the decorative trees.
- **Modify Thing Definitions**: Modify existing thing definitions to include new thing definitions for the decorative trees.

## Suggestions for Copilot

Here are some suggestions for using GitHub Copilot to develop and maintain the DecorativeTrees mod:

- **Code Completion and Suggestion**: Use Copilot to complete and suggest code snippets for new features and bug fixes. For example, when adding a new job driver for throwing parties, Copilot can suggest code snippets for the `MakeNewToils` and `TryMakePreToilReservations` methods.
- **Code Review**: Use Copilot to review code and suggest improvements. For example, when reviewing a Harmony patch, Copilot can suggest improvements to the patch code to ensure it works correctly.
- **Documentation**: Use Copilot to generate documentation for the mod, including code comments and README files. For example, when adding a new feature, Copilot can generate code comments explaining the purpose and functionality of the code.

## Conclusion

The DecorativeTrees mod is a popular RimWorld mod that adds unique decorative trees to the game. By following the coding patterns and conventions outlined in this document, and using GitHub Copilot to assist with code completion, suggestion, review, and documentation, developers can effectively maintain and enhance the mod.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

